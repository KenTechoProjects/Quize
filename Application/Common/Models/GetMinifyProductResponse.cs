using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models
{
    public class GetMinifyProductResponse: ResponseModel
    {
        public string RequestId { get; set; }
        public List<Product> Products { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public int BillerId { get; set; }
        public string DisplayName { get; set; }
        public decimal ProductAmount { get; set; }
        public bool IsFixedAmount { get; set; }
    }
   
}
