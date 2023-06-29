using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Legoas.Model.Entities;

namespace Legoas.Data.Context
{
    public class AplicationDBContext : DbContext, IMyDBContext
    {
        public AplicationDBContext()
          : base("LegoContext")
        {
            Database.SetInitializer<AplicationDBContext>(null);
        }

        public DbSet<Branch> Branch { get; set; }
    }
}
