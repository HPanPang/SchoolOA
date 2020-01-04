using System;
using System.Collections.Generic;

namespace OABackground.Entities
{
    public partial class Teacherinfomation
    {
        public Teacherinfomation()
        {
            Conventionapply = new HashSet<Conventionapply>();
            Materialapply = new HashSet<Materialapply>();
            Teacherpassword = new HashSet<Teacherpassword>();
            Teachplan = new HashSet<Teachplan>();
            Wage = new HashSet<Wage>();
        }

        public string Teacherid { get; set; }
        public string Tname { get; set; }
        public string Sex { get; set; }
        public string Profession { get; set; }
        public DateTime EntryTime { get; set; }
        public string Departmentid { get; set; }
        public string Phone { get; set; }

        public virtual Section Department { get; set; }
        public virtual ICollection<Conventionapply> Conventionapply { get; set; }
        public virtual ICollection<Materialapply> Materialapply { get; set; }
        public virtual ICollection<Teacherpassword> Teacherpassword { get; set; }
        public virtual ICollection<Teachplan> Teachplan { get; set; }
        public virtual ICollection<Wage> Wage { get; set; }
    }
}
