using System;
using System.Reflection;
using Application.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extentions
{
    public static class StringExtensions
    {
        public static bool IsTheSame(this string value, string valueToCompare)
        {
            if ((string.IsNullOrEmpty(value)) || (string.IsNullOrEmpty(valueToCompare)))
                throw new CustomException();
            return value.Trim().ToLower() == valueToCompare.Trim().ToLower();
        }



    }
}
