using System;
using System.Collections.Generic;

namespace AAS_Web.Models
{
    public partial class Position
    {
        public Position()
        {
            Workers = new HashSet<Worker>();
        }

        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public string Permission { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
