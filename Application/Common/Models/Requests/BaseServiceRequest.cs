using Microsoft.Extensions.Configuration;
using System;
using System.Text.Json.Serialization;

namespace Application.Common.Models.Requests
{
    public class BaseServiceRequest
    {
        private readonly IConfiguration _configuration;
        public BaseServiceRequest(IConfiguration configuration)
        {
            _configuration = configuration;
            this.RequestId = Guid.NewGuid().ToString();
        }
        [JsonIgnore]
        public string RequestId { get; set; }
        [JsonIgnore]
        public string CountryId { get; set; }

    }
    public class BaseSettings
    {
        private readonly IConfiguration _configuration;
        public BaseSettings(IConfiguration configuration)
        {
            _configuration = configuration;

        }


        public string BaseUrl
        {
            get
            {
                var baseUrl = _configuration.GetValue<string>("SingleBillerSetting:BaseUrl");
                return baseUrl;

            }
        }
        public string AppId
        {
            get
            {
                var baseUrl = _configuration.GetValue<string>("SingleBillerSetting:AppId");
                return baseUrl;
            }

        }
        public string AppKey
        {
            get
            {
                var baseUrl = _configuration.GetValue<string>("SingleBillerSetting:AppKey");
                return baseUrl;
            }
        }
    }
}

