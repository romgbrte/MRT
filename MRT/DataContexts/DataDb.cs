using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MRT.Models;

namespace MRT.DataContexts
{
    public class DataDb : DbContext
    {
        public DataDb()
            : base("DefaultConnection")
        {
        }

        // Model DbSets go here
        public DbSet<State> States { get; set; }
    }
}