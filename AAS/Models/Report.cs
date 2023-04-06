using System;
using System.Collections.Generic;

namespace AAS_Web.Models
{
    public partial class Report
    {
        public Report()
        {
            Answers = new HashSet<Answer>();
        }

        public int ReportId { get; set; }
        public string ReportTheme { get; set; }
        public string ReportDescription { get; set; }
        public int? StatusId { get; set; }
        public int? ComputerId { get; set; }
        public DateTime? ReportDate { get; set; }
        public int? ProgramId { get; set; }

        public string StatusName => this.Status.Name;
        public virtual Computer Computer { get; set; }
        public virtual Program Program { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
