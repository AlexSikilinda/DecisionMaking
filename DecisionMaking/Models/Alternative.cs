using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DecisionMaking.Models
{
    public class Alternative
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ANum { get; set; }

        public string AName { get; set; }

        public virtual ICollection<Result> Results { get; set; }

        public virtual ICollection<Vector> Vectors { get; set; }
    }
}