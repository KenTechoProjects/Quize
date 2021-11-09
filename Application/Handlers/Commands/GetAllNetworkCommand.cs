using Application.Common.Models;
using Application.Common.Models.Requests;
using Application.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class GetAllNetworkCommand:IRequest<ResponseModel<NetworkResponse>>
    {
        [JsonIgnore]
        public string RequestId { get; set; }
        [JsonIgnore]
        public string CountryId { get; set; }
    }
    public class GetAllNetworkCommandHandler : IRequestHandler<GetAllNetworkCommand, ResponseModel<NetworkResponse>>
    {
        private readonly BaseServiceRequest _baseRequest;
        private readonly BaseSettings _baseSettings;
        private readonly HttpClientHelper _httpClientHelper;
        public GetAllNetworkCommandHandler(BaseServiceRequest baseRequest, HttpClientHelper httpClientHelper, BaseSettings baseSettings)
        {
            _baseRequest = baseRequest;
            _httpClientHelper = httpClientHelper;
            _baseSettings = baseSettings;
        }

        public async Task<ResponseModel<NetworkResponse>> Handle(GetAllNetworkCommand request, CancellationToken cancellationToken)
        {
            var header = new Dictionary<string, string>();

            var url = $"{_baseSettings.BaseUrl}airtime/get-networks";
            header.Add("AppId", _baseSettings.AppId);
            header.Add("AppKey", _baseSettings.AppKey);
            request.RequestId = Guid.NewGuid().ToString("N");
            var response = await _httpClientHelper.PostAsync<NetworkResponse, GetAllNetworkCommand>(request, url, null, header);
            return ResponseModel<NetworkResponse>.Success(data: response);
        }
    }
}
