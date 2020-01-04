using System;
using System.Collections.Generic;

namespace OABackground.Entities
{
    public partial class Student
    {
        public Student()
        {
            Awardpunish = new HashSet<Awardpunish>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Class { get; set; }
        public string Grade { get; set; }
        public string Dormitory { get; set; }
        public string SelfPhone { get; set; }
        public string Parent { get; set; }
        public string ParentPhone { get; set; }

        public virtual ICollection<Awardpunish> Awardpunish { get; set; }
    }
}
