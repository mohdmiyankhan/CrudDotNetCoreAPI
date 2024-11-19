using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDotNetCoreApi.Models
{
    public class ApiResponseModel
    {
        public class ApiResponse<T>
        {
            public string Message { get; set; }
            public bool Result { get; set; }
            public string Error { get; set; }
            public T Data { get; set; }
        }
    }
}
