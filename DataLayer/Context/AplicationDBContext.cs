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
        public DbSet<Role> Role { get; set; }
        public DbSet<Navigation> Navigation { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountRoleMapping> AccountRoleMapping { get; set; }
        public DbSet<AccountRoleNavigationMapping> AccountRoleNavigationMapping { get; set; }
        public DbSet<AccountBranchMapping> AccountBranchMapping { get; set; }
    }
}
