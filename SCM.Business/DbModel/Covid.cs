using System;
using System.Collections.Generic;

namespace SCM.Business.DbModel
{
    public partial class Covid
    {
        public uint ForecastId { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public DateTime Date { get; set; }
        public byte[] AdditionalDetails { get; set; }
    }
}
