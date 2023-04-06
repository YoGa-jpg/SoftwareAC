using System;
using System.Collections.Generic;

namespace AAS_Web.Models
{
    public partial class Computer
    {
        public Computer()
        {
            Reports = new HashSet<Report>();
            Softwares = new HashSet<Software>();
        }

        public int ComputerId { get; set; }
        public int? WorkerId { get; set; }

        public string WorkerName
        {
            get
            {
                if (this.Worker != null)
                {
                    return Worker.Fullname;
                }
                else
                {
                    return "undefined";
                }
            }
        }
        public string WorkerPosition => Worker.PositionName;
        public virtual Worker Worker { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Software> Softwares { get; set; }

        public override string ToString()
        {
            return $"№{ComputerId}";
        }
    }
}
