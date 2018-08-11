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

        public static DataDb Create()
        {
            return new DataDb();
        }
        
        public DbSet<State> States { get; set; }
        public DbSet<Code> Codes { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<StateCoverage> StateCoverages { get; set; }
        public DbSet<PolicyType> PolicyTypes { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<PolicyAssignment> PolicyAssignments { get; set; }
        public DbSet<WCRate> WCRates { get; set; }
    }
}