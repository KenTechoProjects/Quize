
using System;
using System.Text.Json.Serialization;

namespace Application.Common.Models.Requests
{
    public class BuyAirtimeRequest 
    {
        public BuyAirtimeRequest()
        {
            this.ReferenceNumber = Guid.NewGuid().ToString("N");
        }
        public int BillerId { get; set; }
        public string CustomerAccountNumber { get; set; }
        public string CustomerMsisdn { get; set; }
        public string Provider { get; set; }
        [JsonIgnore]
        public string ReferenceNumber { get; set; }
        [JsonIgnore]
        public string RequestId { get; set; }
        [JsonIgnore]
        public string CountryId { get; set; }
        public string BeneficiaryMobileNumber { get; set; }
        public decimal Amount { get; set; }
        
    }
}
