using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Query
{
    public class Pagination
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }
}
