using System;
using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class Vendors
    {
        [Key]
        public int VendorId { get; set; }
        public string VendorType { get; set; } = string.Empty;
        public string VendorNumber { get; set; } = string.Empty;
        public string SequenceNumber { get; set; } = string.Empty;
        public string PurchasingNameLine1 { get; set; } = string.Empty;
        public string PurchasingNameLine2 { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public string PurchasingAddressLine1 { get; set; } = string.Empty;
        public string PurchasingAddressLine2 { get; set; } = string.Empty;
        public string PurchasingAddressLine3 { get; set; } = string.Empty;
        public string PurchasingCity { get; set; } = string.Empty;
        public string PurchasingState { get; set; } = string.Empty;
        public string PurchasingZipCode { get; set; } = string.Empty;
        public string PurchasingCountry { get; set; } = string.Empty;
        public string RemittanceAddressLine1 { get; set; } = string.Empty;
        public string RemittanceAddressLine2 { get; set; } = string.Empty;
        public string RemittanceAddressLine3 { get; set; } = string.Empty;
        public string RemittanceCity { get; set; } = string.Empty;
        public string RemittanceState { get; set; } = string.Empty;
        public string RemittanceZipCode { get; set; } = string.Empty;
        public string RemittanceCountry { get; set; } = string.Empty;
        public string MinorityCode { get; set; } = string.Empty;
        public string StatusCode { get; set; } = string.Empty;
        public string PhoneNumberAreaCode { get; set; } = string.Empty;
        public string PhoneNumberPrefix { get; set; } = string.Empty;
        public string PhoneNumberSuffix { get; set; } = string.Empty;
        public string DateLastUsed { get; set; } = string.Empty;
        public string VendorEnterIndicator { get; set; } = string.Empty;
        public string AddUserIdentifier { get; set; } = string.Empty;
        public string AddDate { get; set; } = string.Empty;
        public string AddOperatingLevelOrganization { get; set; } = string.Empty;
        public string UpdateUserIdentifier { get; set; } = string.Empty;
        public string UpdateDate { get; set; } = string.Empty;
        public string UpdateOperatingLevelOrganization { get; set; } = string.Empty;
        public string W9Indicator { get; set; } = string.Empty;
        public string InactiveReasonCode { get; set; } = string.Empty;
        public string PersonalIdentificationNumber { get; set; } = string.Empty;
        public string W9UpdateDate { get; set; } = string.Empty;
        public string ConfidentialVendorIndicator { get; set; } = string.Empty;
        public string TaxLevyIndicator { get; set; } = string.Empty;
        public string W9Name { get; set; } = string.Empty;
        public string PayeeIndicator { get; set; } = string.Empty;
        public string ForeignIndicator { get; set; } = string.Empty;
        public string EFTAuthorizationIndicator { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public DateTime? InsertDate { get; set; }

    }
}
