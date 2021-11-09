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
    public class GetProductsCommand :  IRequest<ProductResponseModel>
    {
        [JsonIgnore]
        public int BillerId { get; set; }
        [JsonIgnore]
        public string CountryId { get; set; }
    }
    public class GetProductsCommandHandler : IRequestHandler<GetProductsCommand, ProductResponseModel>
    {
        private readonly BaseSettings _baseSettings;
        private readonly HttpClientHelper _httpClientHelper;
        public GetProductsCommandHandler(HttpClientHelper httpClientHelper, BaseSettings baseSettings)
        {
            _httpClientHelper = httpClientHelper;
            _baseSettings = baseSettings;
        }

        public async Task<ProductResponseModel> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            var header = new Dictionary<string, string>();

            var url = $"{_baseSettings.BaseUrl}/channels/get-products";
            header.Add("AppId", _baseSettings.AppId);
            header.Add("AppKey", _baseSettings.AppKey);
            var productDetail = new ProductRequest { BillerId = request.BillerId, CountryId = request.CountryId, RequestId = Guid.NewGuid().ToString("N") };

            var response = await _httpClientHelper.PostAsync<ProductResponseModel, ProductRequest>(productDetail, url, null, header);
            return response;
        }
    }
}
