using Legoas.Data.Context;
using Legoas.Data.Interfaces;
using Legoas.Model.Entities;
using System.Data.Entity.Core.Metadata.Edm;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Legoas.Data.Repositories
{
    public class AccountRoleMappingRepository : BaseRepository<AccountRoleMapping>, IAccountRoleMappingRepository
    {
        public AccountRoleMappingRepository(IMyDBContext dbContext) : base(dbContext)
        {
        }

        public EFResponse Insert(AccountRoleMapping AccountRoleMapping)
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

        public AccountRoleMapping GetByAccountIDAndRoleID(int accountId, int roleId)
        {
            return this.FindAll(x => x.AccountID == accountId && x.RoleID == roleId).FirstOrDefault();
        }

        public EFResponse HardDelete(AccountRoleMapping accountRoleMapping)
        {
            EFResponse model = new EFResponse();

            try
            {
                this.Delete(accountRoleMapping);
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
