using Application.Common.Models;
using Application.Common.Models.Requests;
using Application.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class GetMobileMoneyOperatorsCommand : IRequest<GetMobileMoneyOperatorsResponse>
    {
    }
    public class GetMobileMoneyOperatorsCommandHandler : IRequestHandler<GetMobileMoneyOperatorsCommand, GetMobileMoneyOperatorsResponse>
    {
        private readonly BaseServiceRequest _baseRequest;
        private readonly BaseSettings _baseSettings;
        private readonly HttpClientHelper _httpClientHelper;
        public GetMobileMoneyOperatorsCommandHandler(BaseServiceRequest baseRequest, HttpClientHelper httpClientHelper, BaseSettings baseSettings)
        {
            _baseRequest = baseRequest;
            _httpClientHelper = httpClientHelper;
            _baseSettings = baseSettings;
        }

        public async Task<GetMobileMoneyOperatorsResponse> Handle(GetMobileMoneyOperatorsCommand request, CancellationToken cancellationToken)
        {
            var header = new Dictionary<string, string>();

            var url = $"{_baseSettings.BaseUrl}/mobilemoney/get-mobile-money-operators";
            header.Add("AppId", _baseSettings.AppId);
            header.Add("AppKey", _baseSettings.AppKey);
            var response = await _httpClientHelper.PostAsync<GetMobileMoneyOperatorsResponse, BaseServiceRequest>(_baseRequest, url, null, header);
            return response;
        }
    }
}
