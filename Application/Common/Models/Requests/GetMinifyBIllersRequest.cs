using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models.Requests
{
    public class GetMinifyBIllersRequest : BaseServiceRequest
    {
        public GetMinifyBIllersRequest(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
