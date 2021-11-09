using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models.Requests
{
    public class CommitMinifyBillerRequest : BaseServiceRequest
    {
        public CommitMinifyBillerRequest(IConfiguration configuration) : base(configuration)
        {
            this.ReferenceNumber = Guid.NewGuid().ToString("N");
        }
        public int ProductId { get; set; }
        public string CustomerMsisdn { get; set; }
        public string SourceAccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string ReferenceNumber { get; set; }
    }
}
