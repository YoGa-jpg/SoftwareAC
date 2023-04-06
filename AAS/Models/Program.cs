using System;
using System.Collections.Generic;

namespace AAS_Web.Models
{
    public partial class Program
    {
        public Program()
        {
            Softwares = new HashSet<Software>();
        }

        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public int? TypeId { get; set; }


        public string TypeName
        {
            get
            {
                if(this.Type != null)
                {
                    return Type.TypeName;
                }
                else
                {
                    return "undefined";
                }
            }
        }
        public virtual Type Type { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Software> Softwares { get; set; }

        public override string ToString()
        {
            return ProgramName;
        }
    }
}
