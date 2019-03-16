using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TransRoute.Common.Model
{
    
    public class CustomField
    {

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("variable_name")]
        public string VariableName { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Metadata
    {

        [JsonProperty("custom_fields")]
        public IList<CustomField> CustomFields { get; set; }
    }

    public class Data
    {

        [JsonProperty("business_name")]
        public string BusinessName { get; set; }

        [JsonProperty("primary_contact_name")]
        public string PrimaryContactName { get; set; }

        [JsonProperty("primary_contact_email")]
        public string PrimaryContactEmail { get; set; }

        [JsonProperty("primary_contact_phone")]
        public string PrimaryContactPhone { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("percentage_charge")]
        public int PercentageCharge { get; set; }

        [JsonProperty("settlement_bank")]
        public string SettlementBank { get; set; }

        [JsonProperty("integration")]
        public int Integration { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("subaccount_code")]
        public string SubaccountCode { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        [JsonProperty("settlement_schedule")]
        public string SettlementSchedule { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("migrate")]
        public bool Migrate { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }

    public class SubAccountResp
    {

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

}
