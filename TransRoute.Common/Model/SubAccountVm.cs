using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace TransRoute.Common.Model
{
    public class SubAccountVm
    {
        [JsonProperty("business_name")]
        public string BusinessName { get; set; }

        [JsonProperty("settlement_bank")]
        public string SettlementBank { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("percentage_charge")]
        public int PercentageCharge { get; set; }

        [JsonProperty("primary_contact_email")]
        public string PrimaryContactEmail { get; set; }

        [JsonProperty("primary_contact_name")]
        public string PrimaryContactName { get; set; }

        [JsonProperty("primary_contact_phone")]
        public string PrimaryContactPhone { get; set; }

        [JsonProperty("metadata")]
        public string Metadata { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class Meta
    {

        [JsonProperty("metaname")]
        public string Metaname { get; set; }

        [JsonProperty("metavalue")]
        public string Metavalue { get; set; }
    }

    public class FluSubAccountVm : SubAccountVm
    {

        [JsonProperty("account_bank")]
        public string AccountBank {
            get { return SettlementBank; }
            set {  }
        }

        [JsonProperty("business_email")]
        public string BusinessEmail
        {
            get { return PrimaryContactEmail; }
            set { }
        }

        [JsonProperty("business_contact")]
        public string BusinessContact
        {
            get { return Name; }
            set { }
        }

        [JsonProperty("business_contact_mobile")]
        public string BusinessContactMobile
        {
            get { return PrimaryContactPhone; }
            set { }
        }

        [JsonProperty("business_mobile")]
        public string BusinessMobile
        {
            get { return PrimaryContactPhone; }
            set { }
        }

        [JsonProperty("meta")]
        public IList<Meta> Meta
        {
            get
            {
                var meta = new List<Meta>();

                JavaScriptSerializer js = new JavaScriptSerializer();
                Metadata metadata = js.Deserialize<Metadata>(Metadata);
                foreach (var item in metadata.CustomFields)
                {
                    meta.Add(new Meta(){Metaname = item.VariableName, Metavalue = item.Value});
                }
                return meta;
            }
            set { }
        }

        [JsonProperty("seckey")]
        public string Seckey { get; set; }
    }


}
