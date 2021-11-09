using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models.Requests
{
    public class GetProductFormItemsRequest 
    {
      
        public string RequestId { get; set; }
        public string CountryId { get; set; }
        public int ProductId { get; set; }
    }
}
