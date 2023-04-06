using System;
using System.Collections.Generic;

namespace AAS_Web.Models
{
    public partial class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerTheme { get; set; }
        public string AnswerDescription { get; set; }
        public int? ReportId { get; set; }

        public virtual Report Report { get; set; }
    }
}
    