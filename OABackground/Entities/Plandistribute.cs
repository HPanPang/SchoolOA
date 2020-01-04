using System;
using System.Collections.Generic;

namespace OABackground.Entities
{
    public partial class Plandistribute
    {
        public int Id { get; set; }
        public int Workid { get; set; }
        public string Peopleid { get; set; }

        public virtual Teacherinfomation People { get; set; }
        public virtual Plantable Work { get; set; }
    }
}
