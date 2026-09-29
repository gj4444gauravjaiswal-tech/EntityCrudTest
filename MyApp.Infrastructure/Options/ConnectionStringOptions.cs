using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Options
{
    public class ConnectionStringOptions
    {
        public const string SectionName = "ConnectionStrings";
        public string ConStr {  get; set; }
    }
}
