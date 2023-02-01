﻿

namespace FileExporter.Infrastructure
{
    internal class RowConstants
    {
        public const string Contract = "MAIN";
        public const string Vendor = "VNDR";
        public const string Budget = "BUGT";
        public const string Deliverable = "DLBL";
        public const string Change = "CTCH";
    }

    internal class SaveConstants
    {
        public const string Update = "UPD";
        public const string Insert = "???";
    }

    internal class FieldDelimiter
    {
        public const char Delimiter = '|';
    }
    internal class ScsOlo
    {
        public const string OrgCode = "22000";
    }
    internal class Santize
    {
        public static List<char> Chars = new List<char>() { '|'};
    }
}