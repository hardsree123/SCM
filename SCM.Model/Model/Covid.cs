using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.Model
{
    public class Covid
    {
        public int ForecastId { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public DateTime Date { get; set; }
    }
}
