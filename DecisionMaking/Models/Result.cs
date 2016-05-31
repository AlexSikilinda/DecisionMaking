using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DecisionMaking.Models
{
    public class Result
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RNum { get; set; }

        public int LNum { get; set; }

        public int ANum { get; set; }

        public int Range { get; set; }

        public int AWeight { get; set; }

        public virtual LPR LPR { get; set; }

        public virtual Alternative Alternative { get; set; }
    }
}