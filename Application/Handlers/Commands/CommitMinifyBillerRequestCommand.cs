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
    public class CommitMinifyBillerRequestCommand : CommitMinifyBillerRequest, IRequest<CommitMinifyBillerResponse>
    {
        public CommitMinifyBillerRequestCommand(IConfiguration configuration) : base(configuration)
        {
        }
    }
    public class CommitMinifyBillerRequestCommandHandler : IRequestHandler<CommitMinifyBillerRequestCommand, CommitMinifyBillerResponse>
    {
        private readonly BaseSettings _baseSettings;
        private readonly HttpClientHelper _httpClientHelper;
        public CommitMinifyBillerRequestCommandHandler(HttpClientHelper httpClientHelper, BaseSettings baseSettings)
        {
            _httpClientHelper = httpClientHelper;
            _baseSettings = baseSettings;
        }

        public async Task<CommitMinifyBillerResponse> Handle(CommitMinifyBillerRequestCommand request, CancellationToken cancellationToken)
        {
            var header = new Dictionary<string, string>();

            var url = $"{_baseSettings.BaseUrl}/minify/commit-minify-biller-request";
            header.Add("AppId", _baseSettings.AppId);
            header.Add("AppKey", _baseSettings.AppKey);
            var response = await _httpClientHelper.PostAsync<CommitMinifyBillerResponse, CommitMinifyBillerRequest>(request, url, null, header);
            return response;
        }
    }
}
