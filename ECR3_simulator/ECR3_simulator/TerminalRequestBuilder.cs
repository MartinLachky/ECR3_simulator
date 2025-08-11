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
        public static byte[] BuildSaleJsonMessage(
            double amount = 45.63,
            string transactionType = "sale",
            string ecr = null,
            string invoice = "123456",
            string reference = "123456",
            string sequence = "123456",
            string authorization = "123456",
            string currency = "CZK",
            string language = "cs"
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
                    ["cashback"] = 0.00,
                    ["currencyCode"] = currency,
                    ["tip"] = 0.00
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
                    ["print"] = false,
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
