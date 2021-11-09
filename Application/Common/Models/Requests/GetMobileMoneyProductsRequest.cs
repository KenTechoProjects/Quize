using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models.Requests
{
    public class GetMobileMoneyProductsRequest : BaseServiceRequest
    {
        public GetMobileMoneyProductsRequest(IConfiguration configuration) : base(configuration)
        {
        }
        public int BillerId { get; set; }
    }
}
