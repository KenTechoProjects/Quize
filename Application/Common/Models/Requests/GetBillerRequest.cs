using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models.Requests
{
    public class GetBillerRequest 
    {
       
      
        public int BillerCategoryId { get; set; }
      
        public string CountryId { get; set; }
     
        public string RequestId { get; set; }
       
    }
    public class ProductRequest
    { 
        public int BillerId { get; set; }
        public string CountryId { get; set; }

        public string RequestId { get; set; }
    }
}
