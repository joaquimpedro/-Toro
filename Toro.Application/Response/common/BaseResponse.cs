using System;
using System.Collections.Generic;
using System.Text;

namespace Toro.Application.Response.common
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {

        }

        public BaseResponse(T data)
        {
            Error = false;
            Data = data;
        }

        public bool Error { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
