using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DecisionMaking.Models
{
    /// <summary>
    /// Лицо принимающее решение.
    /// </summary>
    public class LPR
    {
        public int LNum { get; set; }

        public string LName { get; set; }

        public int LRange { get; set; }
    }
}