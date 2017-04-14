using System;
using System.Web;
using System.Linq;
using System.Data.Entity;
using SADAssignment3.Models;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SADAssignment3.DAL
{
    public class SADAssignment3Context : DbContext
    {
        public SADAssignment3Context() : base("SADAssignment3Context") { }

        public DbSet<LineInput> LineInputs { get; set; }

        public DbSet<NoiseWord> NoiseWords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }    
}