using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ResponseModels
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            Errors = new List<string>();
        }
        public BaseResponse(T data, string message = null)
        {
            Message = message;
            Data = data;
        }
        public BaseResponse(string message)
        {
            Message = message;
        }
        public bool Succeeded => Errors.Count == 0;
        public string Message { get; set; }

        public List<string> Errors = new List<string>();
        public T Data { get; set; }
    }
}
