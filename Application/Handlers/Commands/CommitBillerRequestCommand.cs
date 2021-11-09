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
    public class CommitBillerRequestCommand : CommitBillerRequest, IRequest<CommitBillerRequestResponse>
    {
       
    }

    public class CommitBillerRequestCommandHandler : IRequestHandler<CommitBillerRequestCommand, CommitBillerRequestResponse>
    {
        private readonly BaseSettings _baseSettings;
        private readonly HttpClientHelper _httpClientHelper;
        public CommitBillerRequestCommandHandler(HttpClientHelper httpClientHelper, BaseSettings baseSettings)
        {
            _httpClientHelper = httpClientHelper;
            _baseSettings = baseSettings;
        }

        public async Task<CommitBillerRequestResponse> Handle(CommitBillerRequestCommand request, CancellationToken cancellationToken)
        {
            var header = new Dictionary<string, string>();

            var url = $"{_baseSettings.BaseUrl}channels/commit-biller-request";
            header.Add("AppId", _baseSettings.AppId);
            header.Add("AppKey", _baseSettings.AppKey);
            request.RequestId = Guid.NewGuid().ToString("N");
            return await _httpClientHelper.PostAsync<CommitBillerRequestResponse, CommitBillerRequest>(request, url, null, header);
          
        }
    }
}
