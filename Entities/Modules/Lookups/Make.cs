using Entities.Base;
using System.Collections.Generic;

namespace Entities.Modules.Lookups
{
    public class Make : BaseEntity
    {
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public List<Model> Models { get; set; }
        public List<Trim> Trims { get; set; }
    }
}
