using System;
using System.Collections.Generic;

namespace AAS_Web.Models
{
    public partial class Status
    {
        public Status()
        {
            Reports = new HashSet<Report>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
