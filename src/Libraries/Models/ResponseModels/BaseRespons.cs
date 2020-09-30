using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ResponseModels
{
    public class BaseRespons<T>
    {
        public BaseRespons()
        {
        }
        public BaseRespons(T data, string message = null)
        {
            Message = message;
            Data = data;
        }
        public BaseRespons(string message)
        {
            Message = message;
        }
        public bool Succeeded => Errors.Count == 0;
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
