using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace ECR3_simulator
{

    public static class TerminalRequestBuilder
    {
        public static byte[] BuildSettlementJsonMessage(
            string ecr = "1",
            string language = "cs",
            bool printReceipt = false,
            string version = "02",
            string requestID = "1")
        {
            // 1) Pad ECR to 8 digits
            string ecrStr = ecr.PadLeft(8, '0');

            // 2) Create request payload
            var payload = new
            {
                request = new
                {
                    financial = new
                    {
                        id = new { ecr = ecrStr },
                        options = new { language = language, print = printReceipt },
                        transaction = "settlement"
                    }
                }
            };

            // 3) Serialize payload (compact form) for hash
            string payloadJsonCompact = JsonConvert.SerializeObject(payload, Newtonsoft.Json.Formatting.None);
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payloadJsonCompact);

            // 4) Calculate hash over payload only
            string hashValue;
            using (var sha = SHA512.Create())
            {
                byte[] hashBytes = sha.ComputeHash(payloadBytes);
                hashValue = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }

            // 5) Build header with payload length (same as len(data_bytes) in Python)
            var header = new
            {
                requestID = requestID,
                hash = hashValue,
                length = payloadBytes.Length,
                version = version
            };

            // 6) Full message (header + payload)
            var message = new
            {
                header = header,
                request = payload.request
            };

            // 7) Serialize full message (compact form) for sending
            string finalJson = JsonConvert.SerializeObject(message, Newtonsoft.Json.Formatting.None);
            byte[] finalJsonBytes = Encoding.UTF8.GetBytes(finalJson);

            // 8) Create 4-byte big-endian prefix
            byte[] lengthPrefix = BitConverter.GetBytes(finalJsonBytes.Length);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(lengthPrefix);

            // 9) Combine prefix + JSON
            byte[] output = new byte[lengthPrefix.Length + finalJsonBytes.Length];
            Buffer.BlockCopy(lengthPrefix, 0, output, 0, lengthPrefix.Length);
            Buffer.BlockCopy(finalJsonBytes, 0, output, lengthPrefix.Length, finalJsonBytes.Length);

            return output;
        }


        public static byte[] BuildSaleJsonMessage(
            double amount = 45.63,
            string transactionType = "sale",
            string ecr = null,
            string invoice = "123456",
            string reference = "123456",
            string sequence = "123456",
            string authorization = "123456",
            string currency = "CZK",
            string language = "cs",
            double tip = 0.00,
            double cb = 0.00,
            bool printing = false
        )
        {
            // Step 1: Ensure ECR is set
            if (string.IsNullOrEmpty(ecr))
            {
                string t = DateTime.Now.ToString("HHmmss");
                Random rnd = new Random();
                string r = rnd.Next(0, 100).ToString("D2");
                ecr = t + r;
            }

            // Step 2: Build request (as in Python)
            var requestFinancial = new JObject
            {
                ["amounts"] = new JObject
                {
                    ["base"] = amount,
                    ["cashback"] = cb,
                    ["currencyCode"] = currency,
                    ["tip"] = tip
                },
                ["id"] = new JObject
                {
                    ["acquirer"] = "",
                    ["authorization"] = authorization,
                    ["cardName"] = "",
                    ["ecr"] = ecr,
                    ["invoice"] = invoice,
                    ["reference"] = reference,
                    ["sequenceNumber"] = sequence
                },
                ["options"] = new JObject
                {
                    ["language"] = language,
                    ["print"] = printing,
                    ["sendReceiptData"] = false
                },
                ["transaction"] = transactionType
            };
            var request = new JObject
            {
                ["financial"] = requestFinancial
            };

            // Step 3: Build header placeholder
            var header = new JObject
            {
                ["hash"] = "",
                ["length"] = 0,
                ["requestID"] = sequence,
                ["version"] = "02"
            };

            // Step 4: Generate hash over compact "financial" section
            string compactFinancial = JsonConvert.SerializeObject(
                new JObject { ["financial"] = requestFinancial },
                Newtonsoft.Json.Formatting.None
            );
            using (var sha = SHA256.Create())
            {
                byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(compactFinancial));
                header["hash"] = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }

            // Step 5: Build full message to get real length
            JObject fullMessage = new JObject
            {
                ["header"] = header,
                ["request"] = request
            };

            // Compact full message, measure length
            string fullMsgCompact = JsonConvert.SerializeObject(fullMessage, Newtonsoft.Json.Formatting.None);
            int fullMsgLength = Encoding.UTF8.GetByteCount(fullMsgCompact);
            header["length"] = fullMsgLength; // Update

            // Rebuild final message with real length
            fullMessage["header"] = header;
            string finalJson = JsonConvert.SerializeObject(fullMessage, Newtonsoft.Json.Formatting.None);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(finalJson);

            // Create length prefix (big endian, 4 bytes)
            byte[] lengthBytes = BitConverter.GetBytes(jsonBytes.Length);
            if (BitConverter.IsLittleEndian) Array.Reverse(lengthBytes);

            // Concatenate and return
            byte[] outBytes = new byte[lengthBytes.Length + jsonBytes.Length];
            Buffer.BlockCopy(lengthBytes, 0, outBytes, 0, lengthBytes.Length);
            Buffer.BlockCopy(jsonBytes, 0, outBytes, lengthBytes.Length, jsonBytes.Length);

            return outBytes;
        }
    }


}
