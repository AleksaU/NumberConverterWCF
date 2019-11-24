using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WcfNumberConverter_lab.Models
{
    public class NumberConverterContext : DbContext
    {
        public NumberConverterContext() : base("NumberConverterLab")
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<NumberConverterContext, WcfNumberConverter_lab.Migrations.Configuration>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }

    }
}