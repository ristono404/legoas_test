using Legoas.Data.Context;
using Legoas.Data.Interfaces;
using Legoas.Model.Entities;
using System.Data.Entity.Core.Metadata.Edm;
using System;
using System.Linq;

namespace Legoas.Data.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(IMyDBContext dbContext) : base(dbContext)
        {
        }

        public EFResponse Insert(Role Role, string By)
        {
            EFResponse model = new EFResponse();

            try
            {
                Role.UpdatedDate = Role.CreatedDate = DateTime.Now;
                Role.UpdatedBy = Role.CreatedBy = By;
                Role.IsDeleted = false;
                this.Create(Role);
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
        public EFResponse Update(Role Role, string By)
        {
            EFResponse model = new EFResponse();

            try
            {
                Role.UpdatedDate = DateTime.Now;
                Role.UpdatedBy = By;
                Role.IsDeleted = false;
                this.Update(Role);
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
        public EFResponse Delete(Role Role, string by)
        {
            EFResponse model = new EFResponse();

            try
            {
                Role.IsDeleted = true;
                this.Update(Role);
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

        public IQueryable<Role> GetAll()
        {
            return this.FindAll().Where(x => !x.IsDeleted);
        }

        public Role GetById(long ID)
        {
            return this.FindAll().FirstOrDefault(x => x.ID == ID);
        }
    }

}
