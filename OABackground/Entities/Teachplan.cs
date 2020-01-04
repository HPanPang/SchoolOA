using System;
using System.Collections.Generic;

namespace OABackground.Entities
{
    public partial class Teachplan
    {
        public string Id { get; set; }
        public string Tid { get; set; }
        public string TeachTime { get; set; }
        public string TeachSubject { get; set; }
        public string Examination { get; set; }

        public virtual Teacherinfomation T { get; set; }
    }
}
