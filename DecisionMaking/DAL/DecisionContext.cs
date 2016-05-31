using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DecisionMaking.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DecisionMaking.DAL
{
    public class DecisionContext : DbContext
    {
        public DecisionContext()
            : base("DecisionContext")
        {

        }

        public DbSet<Criterion> Criterions { get; set; }

        public DbSet<Vector> Vectors { get; set; }

        public DbSet<Result> Results { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<LPR> LPRs { get; set; }

        public DbSet<Alternative> Alternatives { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}