using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class BaseServiceResponse<T>
    {
        public string ServerTime { get; set; }
        public string Status { get; set; }
        public string Errors { get; set; }
        public T Result { get; set; }
    }
}
