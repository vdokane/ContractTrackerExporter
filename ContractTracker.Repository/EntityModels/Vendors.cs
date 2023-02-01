using System;
using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class Vendors
    {
        [Key]
        public int VendorId { get; set; }
        public string VendorType { get; set; }
        public string VendorNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string PurchasingNameLine1 { get; set; }
        public string PurchasingNameLine2 { get; set; }
        public string ShortName { get; set; }
        public string PurchasingAddressLine1 { get; set; }
        public string PurchasingAddressLine2 { get; set; }
        public string PurchasingAddressLine3 { get; set; }
        public string PurchasingCity { get; set; }
        public string PurchasingState { get; set; }
        public string PurchasingZipCode { get; set; }
        public string PurchasingCountry { get; set; }
        public string RemittanceAddressLine1 { get; set; }
        public string RemittanceAddressLine2 { get; set; }
        public string RemittanceAddressLine3 { get; set; }
        public string RemittanceCity { get; set; }
        public string RemittanceState { get; set; }
        public string RemittanceZipCode { get; set; }
        public string RemittanceCountry { get; set; }
        public string MinorityCode { get; set; }
        public string StatusCode { get; set; }
        public string PhoneNumberAreaCode { get; set; }
        public string PhoneNumberPrefix { get; set; }
        public string PhoneNumberSuffix { get; set; }
        public string DateLastUsed { get; set; }
        public string VendorEnterIndicator { get; set; }
        public string AddUserIdentifier { get; set; }
        public string AddDate { get; set; }
        public string AddOperatingLevelOrganization { get; set; }
        public string UpdateUserIdentifier { get; set; }
        public string UpdateDate { get; set; }
        public string UpdateOperatingLevelOrganization { get; set; }
        public string W9Indicator { get; set; }
        public string InactiveReasonCode { get; set; }
        public string PersonalIdentificationNumber { get; set; }
        public string W9UpdateDate { get; set; }
        public string ConfidentialVendorIndicator { get; set; }
        public string TaxLevyIndicator { get; set; }
        public string W9Name { get; set; }
        public string PayeeIndicator { get; set; }
        public string ForeignIndicator { get; set; }
        public string EFTAuthorizationIndicator { get; set; }
        public string UserId { get; set; }
        public DateTime? InsertDate { get; set; }

    }
}
