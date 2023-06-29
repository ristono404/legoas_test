using Legoas.Data.Context;
using Legoas.Data.Interfaces;
using Legoas.Model.Entities;
using System.Data.Entity.Core.Metadata.Edm;
using System;
using System.Linq;

namespace Legoas.Data.Repositories
{
    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        public BranchRepository(IMyDBContext dbContext) : base(dbContext)
        {
        }

        public EFResponse Insert(Branch branch, string By)
        {
            EFResponse model = new EFResponse();

            try
            {
                branch.UpdatedDate = branch.CreatedDate = DateTime.Now;
                branch.UpdatedBy = branch.CreatedBy = By;
                branch.IsDeleted = false;
                this.Create(branch);
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
        public EFResponse Update(Branch branch, string By)
        {
            EFResponse model = new EFResponse();

            try
            {
                branch.UpdatedDate = DateTime.Now;
                branch.UpdatedBy = By;
                branch.IsDeleted = false;
                this.Update(branch);
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
        public EFResponse Delete(Branch branch, string by)
        {
            EFResponse model = new EFResponse();

            try
            {
                branch.IsDeleted = true;
                this.Update(branch);
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

        public IQueryable<Branch> GetAll()
        {
            return this.FindAll().Where(x => !x.IsDeleted);
        }

        public Branch GetById(int ID)
        {
            return this.FindAll().FirstOrDefault(x => x.ID == ID);
        }
    }

}
