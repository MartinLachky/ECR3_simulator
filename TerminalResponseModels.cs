using System;
using System.Collections.Generic;

namespace ECR3_simulator
{
    // ===== Common Payment Totals =====
    public class PaymentTotals
    {
        public decimal credit { get; set; }
        public int creditCount { get; set; }
        public decimal creditRev { get; set; }
        public int creditRevCount { get; set; }
        public decimal debit { get; set; }
        public int debitCount { get; set; }
        public decimal debitRev { get; set; }
        public int debitRevCount { get; set; }
        public string currencyCode { get; set; }
    }

    // ===== Transaction Details =====
    public class Card
    {
        public string pan { get; set; }
    }

    public class TransactionId
    {
        public Card card { get; set; }
        public string authorization { get; set; }
        public string invoice { get; set; }
        public string reference { get; set; }         // optional in some responses
        public string sequenceNumber { get; set; }    // optional in some responses
    }

    public class TransactionInfo
    {
        public decimal amount { get; set; }
        public string currencyCode { get; set; }
        public string dateTime { get; set; }
        public TransactionId id { get; set; }
        public string transaction { get; set; }
    }

    // ===== Issuer / Acquirer / Overall Totals for Settlement =====
    public class Issuer
    {
        public string name { get; set; }
        public List<PaymentTotals> totals { get; set; }
        public List<TransactionInfo> transactions { get; set; }
    }

    public class Acquirer
    {
        public string batch { get; set; }
        public string dateTime { get; set; }
        public string mid { get; set; }
        public string tid { get; set; }
        public string name { get; set; }
        public List<PaymentTotals> totals { get; set; }
        public List<Issuer> issuers { get; set; }
    }

    public class OverallTotals
    {
        public List<Acquirer> acquirers { get; set; }
    }

    // ===== Result & Common Nodes =====
    public class Result
    {
        public string code { get; set; }
        public string message { get; set; }
        public string messageEnglish { get; set; }
        public string terminalResponse { get; set; }
        public string hostResponse { get; set; }
    }

    public class Amounts
    {
        public double baseAmount { get; set; }
        public double total { get; set; }
        public string currencyCode { get; set; }
    }

    public class Emv
    {
        public string applicationLabel { get; set; }
        public string aid { get; set; }
        public string tvr { get; set; }
        public string tsi { get; set; }
    }

    public class Id
    {
        public string merchant { get; set; }
        public string terminal { get; set; }
        public string ecr { get; set; }
    }

    public class Services
    {
        // can be extended if needed for your spec
    }

    // ===== Financial Object (can contain both transaction & settlement data) =====
    public class Financial
    {
        // Settlement-specific
        public OverallTotals overallTotals { get; set; }

        // Transaction-specific
        public Amounts amounts { get; set; }
        public string dateTime { get; set; }
        public Emv emv { get; set; }
        public object flags { get; set; }
        public object fleetProducts { get; set; }
        public Id id { get; set; }
        public Result result { get; set; }
        public Services services { get; set; }
        public string transaction { get; set; }
    }

    public class Response
    {
        public Financial financial { get; set; }
    }

    public class Header
    {
        public string requestID { get; set; }
        public string hash { get; set; }
        public int length { get; set; }
        public string version { get; set; }
    }

    public class Root
    {
        public Header header { get; set; }
        public Response response { get; set; }
    }
    public class StatusResponseRoot
    {
        public Header header { get; set; }
        public StatusResponseBody response { get; set; }
    }

    public class StatusResponseBody
    {
        public StatusConfig config { get; set; }
        public Status status { get; set; }
    }

    public class StatusConfig
    {
        public List<AcquirerData> acquirerData { get; set; }
        public string applicationVersion { get; set; }
        public string profileId { get; set; }
        public string serialNumber { get; set; }
    }

    public class AcquirerData
    {
        public string acquirerMid { get; set; }
        public string acquirerName { get; set; }
        public string acquirerTid { get; set; }
    }

    public class Status
    {
        public string code { get; set; }            // idle / busy / notAllowed ...
        public string message { get; set; }         // Localised message
        public string messageEnglish { get; set; }  // English message
    }
}
