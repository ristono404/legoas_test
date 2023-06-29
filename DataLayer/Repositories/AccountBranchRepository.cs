using Legoas.Data.Context;
using Legoas.Data.Interfaces;
using Legoas.Model.Entities;
using System.Data.Entity.Core.Metadata.Edm;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Legoas.Data.Repositories
{
    public class AccountBranchMappingRepository : BaseRepository<AccountBranchMapping>, IAccountBranchMappingRepository
    {
        public AccountBranchMappingRepository(IMyDBContext dbContext) : base(dbContext)
        {
        }

        public EFResponse Insert(AccountBranchMapping AccountRoleMapping)
        {
            EFResponse model = new EFResponse();

            try
            {
                this.Create(AccountRoleMapping);
                this.Save();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException != null ? e.InnerException.ToString() : e.Message;
                model.ErrorMessage = e.Message;
                model.Success = false;
            }

            return model;
        }
        public IQueryable<AccountBranchMapping> GetByAccountID(int accountId)
        {
            return this.FindAll(x => x.AccountID == accountId);
        }

        public EFResponse HardDelete(List<AccountBranchMapping> AccountRoleMapping)
        {
            EFResponse model = new EFResponse();

            try
            {
                this.DeleteRange(AccountRoleMapping);
                this.Save();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException != null ? e.InnerException.ToString() : e.Message;
                model.ErrorMessage = e.Message;
                model.Success = false;
            }

            return model;
        }
    }

}
