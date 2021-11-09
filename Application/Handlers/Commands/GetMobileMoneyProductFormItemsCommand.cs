using Application.Common.Models;
using Application.Common.Models.Requests;
using Application.Helper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class GetProductFormItemsCommand : IRequest<GetProductFormItemsResponseModel>
    {
        [JsonIgnore]
        public int ProductId { get; set; }
        [JsonIgnore]
        public string CountryId { get; set; }
    }

    public class GetProductFormItemsCommandHandler : IRequestHandler<GetProductFormItemsCommand, GetProductFormItemsResponseModel>
    {
        private readonly BaseSettings _baseSettings;
        private readonly HttpClientHelper _httpClientHelper;
        public GetProductFormItemsCommandHandler(HttpClientHelper httpClientHelper, BaseSettings baseSettings)
        {
            _httpClientHelper = httpClientHelper;
            _baseSettings = baseSettings;
        }

        public async Task<GetProductFormItemsResponseModel> Handle(GetProductFormItemsCommand request, CancellationToken cancellationToken)
        {
            var header = new Dictionary<string, string>();

            var url = $"{_baseSettings.BaseUrl}channels/get-product-form-items";
            header.Add("AppId", _baseSettings.AppId);
            header.Add("AppKey", _baseSettings.AppKey);
            var uniqDet = Guid.NewGuid().ToString("N");
            var req = new GetProductFormItemsRequest { ProductId = request.ProductId, CountryId = request.CountryId,RequestId  = uniqDet };

            var response = await _httpClientHelper.PostAsync<GetProductFormItemsResponseModel, GetProductFormItemsRequest>(req, url, null, header);
            return response;
        }
    }
}
