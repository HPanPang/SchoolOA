using System;
using System.Collections.Generic;

namespace OABackground.Entities
{
    public partial class Conventionapply
    {
        public int Id { get; set; }
        public string Contact { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ConventionPlace { get; set; }
        public int ConventionState { get; set; }

        public virtual Teacherinfomation ContactNavigation { get; set; }
    }
}
