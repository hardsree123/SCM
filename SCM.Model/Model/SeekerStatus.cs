using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.Model
{
    public class SeekerStatus
    {
        public decimal TotalRequests { get; set; }
        public decimal TotalDelivered { get; set; }
        public decimal TotalDue { get; set; }
        public decimal TotalCancelled { get; set; }
    }

    public class SeekerLocation
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
    }
}
