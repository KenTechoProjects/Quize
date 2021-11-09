using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models
{
    public class ValidateBillerResponseModel:ResponseModel
    {
      //  public string RequestId { get; set; }
        public string ValidationReference { get; set; }
        public string ValidationMessage { get; set; }
        public string BillerName { get; set; }
        public string ProductName { get; set; }
        public decimal Amount { get; set; }
        public decimal ChargeAmount { get; set; }
        public string CurrencyCode { get; set; }

    }
}
