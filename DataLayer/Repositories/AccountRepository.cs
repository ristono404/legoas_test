using Legoas.Data.Context;
using Legoas.Data.Interfaces;
using Legoas.Model.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace Legoas.Data.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(IMyDBContext dbContext) : base(dbContext)
        {
        }

        public EFResponse Insert(Account Account, string By)
        {
            EFResponse model = new EFResponse();

            try
            {
                Account.UpdatedDate = Account.CreatedDate = DateTime.Now;
                Account.UpdatedBy = Account.CreatedBy = By;
                Account.IsDeleted = false;
                this.Create(Account);
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
        public EFResponse Update(Account Account, string By)
        {
            EFResponse model = new EFResponse();

            try
            {
                Account.UpdatedDate = DateTime.Now;
                Account.UpdatedBy = By;
                Account.IsDeleted = false;
                this.Update(Account);
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
        public EFResponse Delete(Account Account, string by)
        {
            EFResponse model = new EFResponse();

            try
            {
                Account.IsDeleted = true;
                this.Update(Account);
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

        public IQueryable<Account> GetAll()
        {
            return this.FindAll().Include("AccountBranchMappings.Branch").Where(x => !x.IsDeleted);
        }

        public Account GetById(long ID)
        {
            return this.FindAll()
                .Include("AccountBranchMappings.Branch")
                .Include("AccountRoleMappings.Role")
                .Include("AccountRoleMappings.AccountRoleNavigationMappings.Navigation")
                .FirstOrDefault(x => x.ID == ID);
        }
    }

}
