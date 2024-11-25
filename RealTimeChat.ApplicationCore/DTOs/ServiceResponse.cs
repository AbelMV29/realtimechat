using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChat.ApplicationCore.DTOs
{
    public class ServiceResponse<T>
    {
        public bool Success { get; }
        public T? Data { get; }
        public string? ErrorMessage { get; }
        public ServiceResponse(bool success, T? data, string? errorMessage)
        {
            Success = success;
            Data = data;
            ErrorMessage = errorMessage;
        }
    }
}
