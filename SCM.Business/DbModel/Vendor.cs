using System;
using System.Collections.Generic;

namespace SCM.Business.DbModel
{
    public partial class Vendor
    {
        public uint Id { get; set; }
        public string VendorCode { get; set; }
        public string VendorAddr { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public byte[] AdditionalDetails { get; set; }
    }
}
