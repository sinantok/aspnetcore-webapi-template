using System.Collections.Generic;

namespace Models.ResponseModels
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
        }
        public BaseResponse(T data, string message = null)
        {
            Message = message;
            Data = data;
        }
        public BaseResponse(string message)
        {
            Message = message;
            Succeeded = false;
        }
        public bool Succeeded;
        public string Message { get; set; }
        public List<string> Errors;
        public T Data { get; set; }
    }
}
