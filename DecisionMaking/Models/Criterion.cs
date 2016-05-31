using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DecisionMaking.Models
{
    public class Criterion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CNum { get; set; }

        public string CName { get; set; }

        public int CRange { get; set; }

        public int CWeight { get; set; }

        public string CType { get; set; }

        public string OptimType { get; set; }

        public string EdIzmer { get; set; }

        public string ScaleType { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }
    }
}