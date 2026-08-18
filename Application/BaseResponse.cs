using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class BaseResponse<T>
    {
        public T? Value { get; set; }
        public string Message { get; set; } = default!;
        public bool IsSuccess {  get; set;  }
       
        public static BaseResponse<T> Sucess(T? value,string message = "Successfull.........")
        {
            return new BaseResponse<T>
            {
                Value = value,
                Message = message,
                IsSuccess = true
            };
        }
        public static BaseResponse<T> Fail(string message = "Failed.........")
        {
            return new BaseResponse<T>
            {
                Message = message,
                IsSuccess = false
            };
        }
     
    }
}
