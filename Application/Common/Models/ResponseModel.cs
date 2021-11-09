using Application.Common.Enums;
using Application.Extentions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models
{
    public class ResponseModel
    {
        public bool Status { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseCode { get; set; }

        public static ResponseModel Success(string message = null)
        {
            return new ResponseModel()
            {
                Status = true,
                ResponseMessage = message ?? "Request was Successful",
                ResponseCode = ResponseCodeEnum.Success.GetDescription()
            };
        }

        public static ResponseModel Failure(string message = null) // , Dictionary<string, string> errors = null
        {
            return new ResponseModel()
            {
                ResponseMessage = message ?? "Request was not completed",
                ResponseCode = ResponseCodeEnum.ApplicationError.GetDescription()
                //Errors = errors
            };

        }
        public static ResponseModel ValidationError(string message = null) // , Dictionary<string, string> errors = null
        {
            return new ResponseModel()
            {
                ResponseMessage = message ?? "One or more validation error occurred",
                ResponseCode = ResponseCodeEnum.ValidationError.GetDescription()
                //Errors = errors
            };

        }
    }

    public class ResponseModel<T> : ResponseModel
    {
        public T Data { get; set; }

        public static ResponseModel<T> Success(T data, string message = null)
        {
            return new ResponseModel<T>()
            {
                Status = true,
                ResponseMessage = message ?? "Request was Successful",
                Data = data,
                ResponseCode = ResponseCodeEnum.Success.GetDescription()
            };
        }
    }

    public class ResponseErrorModel : ResponseModel
    {
        public IDictionary<string, string[]> Errors { get; set; }

        public static ResponseModel Failure(IDictionary<string, string[]> errors = null, string message = null)
        {
            return new ResponseErrorModel()
            {
                ResponseMessage = message ?? "Request was not completed",
                Errors = errors ?? new Dictionary<string, string[]>(),
                ResponseCode = ResponseCodeEnum.Success.GetDescription()
            };
        }
    }
}
