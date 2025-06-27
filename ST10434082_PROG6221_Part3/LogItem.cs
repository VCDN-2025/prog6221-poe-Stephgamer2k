using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10434082_PROG6221_Part3
{
    public class LogItem
    {
        public DateTime Timestamp { get; set; }
        public string Description { get; set; }

        public string Display => $"{Timestamp:g} - {Description}";

    }
}
