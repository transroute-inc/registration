using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransRoute.Common.Http
{
    public class GenericResponse<T>
    {
        public ResponseCode ResponseCode { get; set; }
        public string Message { get; set; }

        public T Result { get; set; }
    }

    public enum ResponseCode
    {
        Ok,
        BadRequest
    }
}
