using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DecisionMaking.Models
{
    public class MinMaxViewModel
    {
        public int[,] InitialArray { get; set; }

        public IQueryable<Alternative> Alternatives { get; set; }

        public double[,] ResultMatrix { get; set; }

        public List<Criterion> Criteria { get; set; }
    }
}