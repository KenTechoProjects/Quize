using Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Helper
{
    public class AppUtility
    {
        public static void BrokerFailureMessage(string message)
        {
            throw new CustomException(message);
        }
    }
}
