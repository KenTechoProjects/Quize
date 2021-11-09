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
    public class ValidateBillerRequestCommand : ValidateBillerRequest, IRequest<ResponseModel<ValidateBillerResponseModel>>
    {

    }

    public class ValidateBillerRequestCommandHandler : IRequestHandler<ValidateBillerRequestCommand, ResponseModel<ValidateBillerResponseModel>>
    {
        private readonly BaseSettings _baseSettings;
        private readonly HttpClientHelper _httpClientHelper;
        public ValidateBillerRequestCommandHandler(HttpClientHelper httpClientHelper, BaseSettings baseSettings)
        {
            _httpClientHelper = httpClientHelper;
            _baseSettings = baseSettings;
        }

        public async Task<ResponseModel<ValidateBillerResponseModel>> Handle(ValidateBillerRequestCommand request, CancellationToken cancellationToken)
        {
            var header = new Dictionary<string, string>();

            var url = $"{_baseSettings.BaseUrl}channels/validate-biller-request";
            header.Add("AppId", _baseSettings.AppId);
            header.Add("AppKey", _baseSettings.AppKey);
            request.RequestId = Guid.NewGuid().ToString("N");
            var response = await _httpClientHelper.PostAsync<ValidateBillerResponseModel, ValidateBillerRequest>(request, url, null, header);
            return ResponseModel<ValidateBillerResponseModel>.Success(data: response);
        }
    }
}
