using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Application.Common.Models.Requests
{
    public class CommitBillerRequest 
    {
        [JsonIgnore]
        public string RequestId { get; set; }
        [JsonIgnore]
        public string CountryId { get; set; }
        public string ValidationReference { get; set; }
    }
}
