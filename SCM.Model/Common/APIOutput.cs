using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.Model
{
    public class Status
    {
        public Status()
        {
            this.DateTimeUTC = CommonUtilties.GetCurrentDateTime().ToFormatedDateTime();
            this.Version = "1.0.0";
        }

        public string DateTimeUTC { get; set; }

        public string Version { get; set; }
    }

    public class APIOutput
    {
        public APIOutput()
        {
            this.Status = new Status();
        }

        public object Data { get; set; }
        public string ErrorMessage { get; set; }
        public object ErrorModel { get; set; }
        public int TotalRecords { get; set; }
        public Status Status { get; set; }
    }
}
