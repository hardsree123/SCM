using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCM.Business.DbModel
{
    public partial class Requirements
    {
        public uint Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string RequirerName { get; set; }
        public short Age { get; set; }
        public string RequirementDesc { get; set; }
        [Required(ErrorMessage = "Volunteer name is required")]
        public string VolunteerCode { get; set; }
        public string Address { get; set; }
        [RegularExpression(@"((\+*)((0[ -]+)*|(91 )*)(\d{12}|\d{10}))|\d{5}([- ]*)\d{6}",ErrorMessage ="Contact no shall be of max 10 digits"), Required, StringLength(10)]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Requested date is required")]
        public DateTime RequestedDate { get; set; }
        public DateTime? RequestDueDate { get; set; }
        public DateTime? RequestCompleted { get; set; }
        public DateTime? RequestCancelled { get; set; }
        public string CancellationDesc { get; set; }
        public int? Priority { get; set; }
        public int? StatusOfRequest { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public byte[] AdditionalDetails { get; set; }
    }
}
