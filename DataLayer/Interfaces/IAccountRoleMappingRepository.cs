using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Legoas.Model.Entities;

namespace Legoas.Data.Interfaces
{
    public interface IAccountRoleMappingRepository : IRepository<AccountRoleMapping>
    {
        EFResponse Insert(AccountRoleMapping branch);
        EFResponse HardDelete(AccountRoleMapping branch);
        AccountRoleMapping GetByAccountIDAndRoleID(int accountId,int roleId);
    }
}
