using Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Modules.Lookups
{
    public class Model : BaseEntity
    {
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public int MakeId { get; set; }
        public Make Make { get; set; }
    }
}
