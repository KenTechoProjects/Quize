using Application.Common.Models;
using Application.Common.Models.Requests;
using Application.Helper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class BuyAirtimeCommand : BuyAirtimeRequest, IRequest<BuyAirtimeResponse>
    {
        public string Pin { get; set; }
    }
    
    public class BuyAirtimeCommandHandler : IRequestHandler<BuyAirtimeCommand, BuyAirtimeResponse>
    {
        private readonly BaseSettings _baseSettings;
        private readonly HttpClientHelper _httpClientHelper;
        public BuyAirtimeCommandHandler(HttpClientHelper httpClientHelper, BaseSettings baseSettings)
        {
            _httpClientHelper = httpClientHelper;
            _baseSettings = baseSettings;
        }

        public async Task<BuyAirtimeResponse> Handle(BuyAirtimeCommand request, CancellationToken cancellationToken)
        {
            var header = new Dictionary<string, string>();
            
            var url = $"{_baseSettings.BaseUrl}airtime/buy-airtime";
            header.Add("AppId", _baseSettings.AppId);
            header.Add("AppKey", _baseSettings.AppKey);
            request.ReferenceNumber = Guid.NewGuid().ToString("N");
            request.RequestId = Guid.NewGuid().ToString("N");
            return await _httpClientHelper.PostAsync<BuyAirtimeResponse, BuyAirtimeRequest>(request, url, null, header);
        }
    }
}
