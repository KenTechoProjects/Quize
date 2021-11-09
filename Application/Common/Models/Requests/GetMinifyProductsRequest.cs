using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models.Requests
{
    public class GetMinifyProductsRequest : BaseServiceRequest
    {
        public GetMinifyProductsRequest(IConfiguration configuration) : base(configuration)
        {
        }
        public int BillerId { get; set; }
    }
}
