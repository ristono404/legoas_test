using Legoas.Data.Context;
using Legoas.Data.Interfaces;
using Legoas.Model.Entities;
using System.Data.Entity.Core.Metadata.Edm;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Legoas.Data.Repositories
{
    public class AccountRoleNavigationMappingRepository : BaseRepository<AccountRoleNavigationMapping>, IAccountRoleNavigationMappingRepository
    {
        public AccountRoleNavigationMappingRepository(IMyDBContext dbContext) : base(dbContext)
        {
        }

        public EFResponse Insert(AccountRoleNavigationMapping AccountRoleNavigationMapping)
        {
            EFResponse model = new EFResponse();

            try
            {
                this.Create(AccountRoleNavigationMapping);
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
        public IQueryable<AccountRoleNavigationMapping> GetByAccountRoleID(int accountRoleId)
        {
            return this.FindAll(x => x.AccountRoleID == accountRoleId);
        }

        public EFResponse HardDelete(List<AccountRoleNavigationMapping> AccountRoleNavMapping)
        {
            EFResponse model = new EFResponse();

            try
            {
                this.DeleteRange(AccountRoleNavMapping);
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
