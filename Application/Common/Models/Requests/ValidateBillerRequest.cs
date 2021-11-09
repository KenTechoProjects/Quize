using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Application.Common.Models.Requests
{
    public class ValidateBillerRequest
    {
           [JsonIgnore]
        public string CountryId { get; set; }
        [JsonIgnore]
        public string RequestId { get; set; }
        public int BillerId { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
        public string SourceAccountNumber { get; set; }
        public string CustomerMsisdn { get; set; }
        public List<ProductFormItems> productFormItems { get; set; }
    }
    public class ProductFormItems
    {
        public int Id { get; set; }
        public string value { get; set; }
    }
}


