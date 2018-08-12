using IR.Data.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Data.EFCore.Context
{
    public class IRContext : DbContext
    {
        public IRContext(DbContextOptions<IRContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContribuinteMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
