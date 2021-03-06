﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DecisionMaking.Models
{
    /// <summary>
    /// Возможные оценки(шкала оценок) по критериям качества
    /// </summary>
    public class Mark
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MNum { get; set; }

        public int CNum { get; set; }

        public string MName { get; set; }

        public int MRange { get; set; }

        public double NumMark { get; set; }

        public double NormMark { get; set; }

        public virtual Criterion Criterion { get; set; }

        public virtual ICollection<Vector> Vectors { get; set; }
    }
}