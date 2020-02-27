using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Application.Models
{
    public class ResponseModel<T>
    {
        public bool Success
        {
            get
            {
                return Data != null;
            }
        }
        public T Data { get; set; }
        public string[] Messages { get; set; }

        public static ResponseModel<T> GetResponse(T result)
        {
            var response = new ResponseModel<T>();
            response.Data = result;
            return response;
        }

        public static ResponseModel<T> GetResponse(string[] errors)
        {
            var response = new ResponseModel<T>();
            response.Messages = errors;
            return response;
        }
    }
}
