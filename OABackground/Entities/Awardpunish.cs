using System;
using System.Collections.Generic;

namespace OABackground.Entities
{
    public partial class Awardpunish
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PunishContent { get; set; }
        public string AwardContent { get; set; }
        public int State { get; set; }
        public string Issue { get; set; }
        public string Sid { get; set; }
        public DateTime ApplyTime { get; set; }
        public DateTime? CheckTime { get; set; }
        public string Content { get; set; }

        public virtual Student S { get; set; }
    }
}
