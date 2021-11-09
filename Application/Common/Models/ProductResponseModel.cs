using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models
{
    public class ProductResponseModel : ResponseModel
    {
        public List<ProductDetail> Products { get; set; }
    }
    public class ProductDetail
    {
        public int Id { get; set; }
        public int BillerId { get; set; }
        public string DisplayName { get; set; }
        public decimal ProductAmount { get; set; }
        public bool IsFixedAmount { get; set; }
    }
}
