using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DecisionMaking.Models
{
    public class Vector
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VNum { get; set; }

        public int ANum { get; set; }

        public int MNum { get; set; }

        public virtual Alternative Alternative { get; set; }

        public virtual Mark Mark { get; set; }
    }
}