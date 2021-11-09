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
    public class GetMinifyProductsCommand : GetMinifyProductsRequest, IRequest<GetMinifyProductResponse>
    {
        public GetMinifyProductsCommand(IConfiguration configuration) : base(configuration)
        {
        }
    }

    public class GetMinifyProductsCommandHandler : IRequestHandler<GetMinifyProductsCommand, GetMinifyProductResponse>
    {
        private readonly BaseSettings _baseSettings;
        private readonly HttpClientHelper _httpClientHelper;
        public GetMinifyProductsCommandHandler(HttpClientHelper httpClientHelper, BaseSettings baseSettings)
        {
            _httpClientHelper = httpClientHelper;
            _baseSettings = baseSettings;
        }

        public async Task<GetMinifyProductResponse> Handle(GetMinifyProductsCommand request, CancellationToken cancellationToken)
        {
            var header = new Dictionary<string, string>();

            var url = $"{_baseSettings.BaseUrl}/minify/get-minify-products";
            header.Add("AppId", _baseSettings.AppId);
            header.Add("AppKey", _baseSettings.AppKey);
            var response = await _httpClientHelper.PostAsync<GetMinifyProductResponse, GetMinifyProductsRequest>(request, url, null, header);
            return response;
        }
    }
}
