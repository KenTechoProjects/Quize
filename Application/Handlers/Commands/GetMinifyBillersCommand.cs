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
    public class GetMinifyBillersCommand : GetMinifyBIllersRequest, IRequest<GetMinifyBIllersResponse>
    {
        public GetMinifyBillersCommand(IConfiguration configuration) : base(configuration)
        {
        }
    }

    public class GetMinifyBillersCommandHandler : IRequestHandler<GetMinifyBillersCommand, GetMinifyBIllersResponse>
    {
        private readonly BaseSettings _baseSettings;
        private readonly HttpClientHelper _httpClientHelper;
        public GetMinifyBillersCommandHandler(HttpClientHelper httpClientHelper, BaseSettings baseSettings)
        {
            _httpClientHelper = httpClientHelper;
            _baseSettings = baseSettings;
        }

        public async Task<GetMinifyBIllersResponse> Handle(GetMinifyBillersCommand request, CancellationToken cancellationToken)
        {
            var header = new Dictionary<string, string>();

            var url = $"{_baseSettings.BaseUrl}/minify/get-minify-billers";
            header.Add("AppId", _baseSettings.AppId);
            header.Add("AppKey", _baseSettings.AppKey);
            var response = await _httpClientHelper.PostAsync<GetMinifyBIllersResponse, GetMinifyBIllersRequest>(request, url, null, header);
            return response;
        }
    }
}
