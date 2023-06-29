using Legoas.Data.Context;
using Legoas.Data.Interfaces;
using Legoas.Model.Entities;
using System.Data.Entity.Core.Metadata.Edm;
using System;
using System.Linq;

namespace Legoas.Data.Repositories
{
    public class NavigationRepository : BaseRepository<Navigation>, INavigationRepository
    {
        public NavigationRepository(IMyDBContext dbContext) : base(dbContext)
        {
        }

        public EFResponse Insert(Navigation Navigation, string By)
        {
            EFResponse model = new EFResponse();

            try
            {
                Navigation.UpdatedDate = Navigation.CreatedDate = DateTime.Now;
                Navigation.UpdatedBy = Navigation.CreatedBy = By;
                Navigation.IsDeleted = false;
                this.Create(Navigation);
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
        public EFResponse Update(Navigation Navigation, string By)
        {
            EFResponse model = new EFResponse();

            try
            {
                Navigation.UpdatedDate = DateTime.Now;
                Navigation.UpdatedBy = By;
                Navigation.IsDeleted = false;
                this.Update(Navigation);
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
        public EFResponse Delete(Navigation Navigation, string by)
        {
            EFResponse model = new EFResponse();

            try
            {
                Navigation.IsDeleted = true;
                this.Update(Navigation);
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

        public IQueryable<Navigation> GetAll()
        {
            return this.FindAll().Where(x => !x.IsDeleted);
        }

        public Navigation GetById(long ID)
        {
            return this.FindAll().FirstOrDefault(x => x.ID == ID);
        }
    }

}
