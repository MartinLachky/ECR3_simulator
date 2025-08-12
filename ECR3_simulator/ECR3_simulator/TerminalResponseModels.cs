using System;
using System.Collections.Generic;

namespace ECR3_simulator
{
    public class Header
    {
        public string hash { get; set; }
        public int length { get; set; }
        public string requestID { get; set; }
        public string version { get; set; }
    }

    // 'base' is a reserved keyword in C#, so we rename to baseAmount
    public class Amounts
    {
        public double baseAmount { get; set; }
        public string currencyCode { get; set; }
        public double total { get; set; }
        public double original { get; set; }
    }

    public class Emv
    {
        public string aid { get; set; }
        public string aidLabel { get; set; }
        public string aosa { get; set; }
        public string cryptogram1 { get; set; }
        public string ctq { get; set; }
        public string currencyCode { get; set; }
        public string ttq { get; set; }
        public string tvr { get; set; }
    }

    public class Card
    {
        public string @interface { get; set; }
        public string name { get; set; }
        public string pan { get; set; }
    }

    public class Id
    {
        public string authorization { get; set; }
        public string batch { get; set; }
        public Card card { get; set; }
        public string ecr { get; set; }
        public string invoice { get; set; }
        public string merchant { get; set; }
        public string terminal { get; set; }
    }

    public class Result
    {
        public string code { get; set; }
        public string message { get; set; }
    }

    public class Dcc
    {
        public Amounts amounts { get; set; }
        public string dateTime { get; set; }
        public string disclaimer { get; set; }
        public double formattedRate { get; set; }
        public double markUp { get; set; }
        public string provider { get; set; }
        public string status { get; set; }
    }

    public class Services
    {
        public Dcc dcc { get; set; }
    }

    public class Financial
    {
        public Amounts amounts { get; set; }
        public string dateTime { get; set; }
        public Emv emv { get; set; }
        public object flags { get; set; }
        public List<object> fleetProducts { get; set; }
        public Id id { get; set; }
        public Result result { get; set; }
        public Services services { get; set; }
        public string transaction { get; set; }
    }

    public class Response
    {
        public Financial financial { get; set; }
    }

    public class Root
    {
        public Header header { get; set; }
        public Response response { get; set; }
    }
}
