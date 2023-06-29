using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Legoas.Model.Entities;

namespace Legoas.Data.Interfaces
{
    public interface IAccountBranchMappingRepository : IRepository<AccountBranchMapping>
    {
        EFResponse Insert(AccountBranchMapping branch);
        EFResponse HardDelete(List<AccountBranchMapping> branch);
        IQueryable<AccountBranchMapping> GetByAccountID(int accountId);
    }
}
