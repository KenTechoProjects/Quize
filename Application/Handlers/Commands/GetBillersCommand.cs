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
    public class GetBillersCommand : IRequest<ResponseModel<NetworkResponse>>
    {
        [JsonIgnore]
        public int BillerCategoryId { get; set; }
        [JsonIgnore]
        public string CountryId { get; set; }
    
    }
    public class GetBillersCommandHandler : IRequestHandler<GetBillersCommand, ResponseModel<NetworkResponse>>
    {
        private readonly BaseSettings _baseSettings;
        private readonly HttpClientHelper _httpClientHelper;
        public GetBillersCommandHandler(HttpClientHelper httpClientHelper, BaseSettings baseSettings)
        {
            _httpClientHelper = httpClientHelper;
            _baseSettings = baseSettings;
        }

        public async Task<ResponseModel<NetworkResponse>> Handle(GetBillersCommand request, CancellationToken cancellationToken)
        {
            var header = new Dictionary<string, string>();

            var url = $"{_baseSettings.BaseUrl}channels/get-billers";
            header.Add("AppId", _baseSettings.AppId);
            header.Add("AppKey", _baseSettings.AppKey);
           var uniqDet = Guid.NewGuid().ToString("N");
            var req = new GetBillerRequest { BillerCategoryId = request.BillerCategoryId, CountryId = request.CountryId,RequestId=uniqDet };

            var response = await _httpClientHelper.PostAsync<NetworkResponse, GetBillerRequest>(req, url, null, header);
            return ResponseModel<NetworkResponse>.Success(data: response);
        }
    }
}
