﻿using System;
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

        public static DataDb Create()
        {
            return new DataDb();
        }

        // Model DbSets go here
        public DbSet<State> States { get; set; }
        public DbSet<Code> Codes { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<StateCoverage> StateCoverages { get; set; }
    }
}