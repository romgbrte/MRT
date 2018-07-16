using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MRT.DataContexts
{
    public class DataDb : DbContext
    {
        public DataDb()
            : base("DefaultConnection")
        {
        }

        // DbSets go here
    }
}