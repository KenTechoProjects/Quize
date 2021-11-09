using Application.Common.Models;
using Application.Common.Models.Requests;
using Application.Helper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class GetMobileMoneyProductsCommand : GetMobileMoneyProductsRequest, IRequest<GetMobileMoneyProductResponse>
    {
        public GetMobileMoneyProductsCommand(IConfiguration configuration) : base(configuration)
        {
        }
    }
    public class GetMobileMoneyProductsCommandHandler : IRequestHandler<GetMobileMoneyProductsCommand, GetMobileMoneyProductResponse>
    {
        private readonly BaseSettings _baseSettings;
        private readonly HttpClientHelper _httpClientHelper;
        public GetMobileMoneyProductsCommandHandler(HttpClientHelper httpClientHelper, BaseSettings baseSettings)
        {
            _httpClientHelper = httpClientHelper;
            _baseSettings = baseSettings;
        }

        public async Task<GetMobileMoneyProductResponse> Handle(GetMobileMoneyProductsCommand request, CancellationToken cancellationToken)
        {
            var header = new Dictionary<string, string>();

            var url = $"{_baseSettings.BaseUrl}/channels/get-billers";
            header.Add("AppId", _baseSettings.AppId);
            header.Add("AppKey", _baseSettings.AppKey);
            var response = await _httpClientHelper.PostAsync<GetMobileMoneyProductResponse, GetMobileMoneyProductsCommand>(request, url, null, header);
            return response;
        }
    }
}
