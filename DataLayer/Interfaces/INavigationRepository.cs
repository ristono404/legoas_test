using System.Linq;
using Legoas.Model.Entities;

namespace Legoas.Data.Interfaces
{
    public interface INavigationRepository : IRepository<Navigation>
    {
        EFResponse Insert(Navigation navigation, string By);
        EFResponse Update(Navigation navigation, string By);
        EFResponse Delete(Navigation navigation, string By);
        IQueryable<Navigation> GetAll();
        Navigation GetById(long ID);
    }
}
