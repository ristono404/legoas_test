using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Legoas.Model.Entities; 

namespace Legoas.Data.Interfaces
{
    public interface IAccountRoleNavigationMappingRepository : IRepository<AccountRoleNavigationMapping>
    {
        EFResponse Insert(AccountRoleNavigationMapping branch);
        EFResponse HardDelete(List<AccountRoleNavigationMapping> branch);
        IQueryable<AccountRoleNavigationMapping> GetByAccountRoleID(int accountRoleId);
    }
}
