using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class ApplicationSettings
    {
        public string ConnectionString { get; set; }
    }

    public class ApplicationSettingsModel
    {
        public ApplicationSettings ApplicationSettings { get; set; }
    }
}
