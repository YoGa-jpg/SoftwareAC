using System;
using System.Collections.Generic;

namespace AAS_Web.Models
{
    public partial class Type
    {
        public Type()
        {
            Programs = new HashSet<Program>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Program> Programs { get; set; }
    }
}
