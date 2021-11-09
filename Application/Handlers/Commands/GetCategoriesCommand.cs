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
    public class GetCategoriesCommand : IRequest<ResponseModel<CategoryResponse>>
    {
        [JsonIgnore]
        public string CountryCode { get; set; }
    }
    public class GetCategoriesCommandHandler : IRequestHandler<GetCategoriesCommand, ResponseModel<CategoryResponse>>
    {
        private readonly BaseServiceRequest _baseRequest;
        private readonly BaseSettings _baseSettings;
        private readonly HttpClientHelper _httpClientHelper;
        public GetCategoriesCommandHandler(BaseServiceRequest baseRequest, HttpClientHelper httpClientHelper, BaseSettings baseSettings)
        {
            _baseRequest = baseRequest;
            _httpClientHelper = httpClientHelper;
            _baseSettings = baseSettings;
        }

        public async Task<ResponseModel<CategoryResponse>> Handle(GetCategoriesCommand request, CancellationToken cancellationToken)
        {
            var header = new Dictionary<string, string>();

            var url = $"{_baseSettings.BaseUrl}/channels/get-categories";
            header.Add("AppId", _baseSettings.AppId);
            header.Add("AppKey", _baseSettings.AppKey);
            _baseRequest.CountryId = request.CountryCode;
            var response = await _httpClientHelper.PostAsync<CategoryResponse, BaseServiceRequest>(_baseRequest, url, null, header);
            return  ResponseModel<CategoryResponse>.Success(data:response);
        }
    }
}
