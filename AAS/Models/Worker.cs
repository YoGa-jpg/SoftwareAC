using System;
using System.Collections.Generic;

namespace AAS_Web.Models
{
    public partial class Worker
    {
        public Worker()
        {
            Computers = new HashSet<Computer>();
        }

        public int WorkerId { get; set; }
        public string Fullname { get; set; }
        public int? PositionId { get; set; }

        public string PositionName => Position.PositionName;

        public virtual Position Position { get; set; }
        public virtual ICollection<Computer> Computers { get; set; }
    }
}
