using System;
using System.Collections.Generic;

namespace OABackground.Entities
{
    public partial class Wage
    {
        public int Id { get; set; }
        public string Teacherid { get; set; }
        public DateTime Wagetime { get; set; }
        public float Basicwage { get; set; }
        public float? Overtimewage { get; set; }
        public float? Welfare { get; set; }
        public float? Bonus { get; set; }
        public float? Totalwage { get; set; }

        public virtual Teacherinfomation Teacher { get; set; }
    }
}
