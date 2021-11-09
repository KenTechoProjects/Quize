using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models
{
    public class GetMobileMoneyProductResponse : ResponseModel
    {
        public string RequestId { get; set; }
        public List<ProductDetail> Products { get; set; }
    }
}
