﻿namespace TrackerFile.Infrastructure.Utilities
{
    public class RowConstants
    {
        public const string Contract = "MAIN";
        public const string Vendor = "VNDR";
        public const string Budget = "BUGT";
        public const string Deliverable = "DLBL";
        public const string Change = "CTCH";
        public const string CSFA = "CSFA";
        public const string CFDA = "CFDA";
    }

    public class SaveConstants
    {
        public const string Update = "UPD";
        public const string Insert = "ADD";
        public const string NONE = "NONE";  //When Updating/Adding an existing contract/grant disbursement agreement’s children.
    }

    public class FieldDelimiter
    {
        public const char Delimiter = '|';
    }
    public class ScsOlo
    {
        public const string OrgCode = "22000";
    }
    public class Santize
    {
        public static List<char> Chars = new List<char>() { '|'};
    }
    public class AttachmentRowConstants
    {
        public const string Contract = "CN";
        public const string Procurement = "???";
        public const string Change = "???";
    }

    public enum ExportSteps
    {
        NothingToExport,
        Contract,
        Vendor,
        Budget,
        Deliverable,
        Change,
        ContractAttachments,
        ProcurementAttachments,
        ChangeAttachments,
        CSFA,
        CFDA
    }
}