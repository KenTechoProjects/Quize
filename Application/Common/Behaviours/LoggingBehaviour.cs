﻿//using Application.Interfaces;
//using MediatR.Pipeline;
//using Microsoft.Extensions.Logging;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Application.Common.Behaviours
//{
//    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
//    {
//        private readonly ILogger _logger;
//        private readonly ICurrentUserService _currentUserService;

//        public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
//        {
//            _logger = logger;
//            _currentUserService = currentUserService;
//        }

//        public async Task Process(TRequest request, CancellationToken cancellationToken)
//        {
//            var requestName = typeof(TRequest).Name;
//            var userId = _currentUserService.UserId ?? string.Empty;
//            string userName = string.Empty;

//            if (!string.IsNullOrEmpty(userId))
//            {
//                //userName = await _identityService.GetUserNameAsync(userId);
//            }

//            _logger.LogInformation("Notification Request:{@Request}",
//                requestName, userId, userName, request);

//            await Task.FromResult(0);
//        }
//    }
//}
