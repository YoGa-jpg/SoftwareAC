using System;
using System.Collections.Generic;

namespace AAS_Web.Models
{
    public partial class Software
    {
        public int SoftwareId;
        public string Version { get; set; }
        public DateTime? LicenseStart { get; set; }
        public DateTime? LicenseEnd { get; set; }
        public int? ProgramId;
        public int? ComputerId;

        public virtual Computer Computer { get; set; }
        public virtual Program Program { get; set; }

        public string WorkerName
        {
            get
            {
                if (this.Computer != null)
                {
                    return Computer.Worker.Fullname;
                }
                else
                {
                    return "undefined";
                }
            }
            set => Computer.Worker.Fullname = value;
        }

        public int? WorkerId
        {
            get => Computer.WorkerId;
            set => Computer.WorkerId = value;
        }

        public string ProgramName
        {
            get => Program.ProgramName;
            set => Program.ProgramName = value;
        }

        public string ProgramType
        {
            get => Program.Type.TypeName;
            set => Program.Type.TypeName = value;
        }

        public int? TypeId
        {
            get => Program.TypeId;
            set => Program.TypeId = value;
        }
    }
}
