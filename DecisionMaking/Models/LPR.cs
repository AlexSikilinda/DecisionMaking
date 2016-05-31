using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DecisionMaking.Models
{
    /// <summary>
    /// Лицо принимающее решение.
    /// </summary>
    public class LPR
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LNum { get; set; }

        public string LName { get; set; }

        public int LRange { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}