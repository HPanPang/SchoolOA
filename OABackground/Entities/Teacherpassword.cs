using System;
using System.Collections.Generic;

namespace OABackground.Entities
{
    public partial class Teacherpassword
    {
        public int Id { get; set; }
        public string Teacherid { get; set; }
        public string Teacherpassword1 { get; set; }
        public string Pwdsalt { get; set; }

        public virtual Teacherinfomation Teacher { get; set; }
    }
}
