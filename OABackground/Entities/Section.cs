using System;
using System.Collections.Generic;

namespace OABackground.Entities
{
    public partial class Section
    {
        public Section()
        {
            Materialapply = new HashSet<Materialapply>();
            Teacherinfomation = new HashSet<Teacherinfomation>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Chairman { get; set; }
        public string Phone { get; set; }
        public string Workplace { get; set; }

        public virtual ICollection<Materialapply> Materialapply { get; set; }
        public virtual ICollection<Teacherinfomation> Teacherinfomation { get; set; }
    }
}
