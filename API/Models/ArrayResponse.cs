using DataAccess.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ArrayResponse<T>
    {
        public Pagination Pagination { get; set; }
        public List<T> Data { get; set; }
    }
}
