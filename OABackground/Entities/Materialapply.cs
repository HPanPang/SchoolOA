using System;
using System.Collections.Generic;

namespace OABackground.Entities
{
    public partial class Materialapply
    {
        public int Id { get; set; }
        public string Departmentid { get; set; }
        public string Tid { get; set; }
        public string Goodsname { get; set; }
        public int Goodsnum { get; set; }
        public float Goodsprice { get; set; }
        public string Remarks { get; set; }
        public int State { get; set; }

        public virtual Section Department { get; set; }
        public virtual Teacherinfomation T { get; set; }
    }
}
