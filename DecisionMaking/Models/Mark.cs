using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DecisionMaking.Models
{
    public class Mark
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MNum { get; set; }

        public int CNum { get; set; }

        public string MName { get; set; }

        public int MRange { get; set; }

        public int NumMark { get; set; }

        public int NormMark { get; set; }

        public virtual Criterion Criterion { get; set; }

        public virtual ICollection<Vector> Vectors { get; set; }
    }
}