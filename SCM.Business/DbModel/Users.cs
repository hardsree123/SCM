using System;
using System.Collections.Generic;

namespace SCM.Business.DbModel
{
    public partial class Users
    {
        public uint Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public short Age { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public int Designation { get; set; }
    }
}
