using Legoas.Model.Entities;
using System.Linq;
using Legoas.Model.objects;

namespace Legoas.Service.Interfaces
{
    public interface INavigationService
    {
        IQueryable<Navigation> GetAll();
        ResultModel<NavigationModel> AddNavigation(NavigationModel model, string by);
        ResultModel<NavigationModel> EditNavigation(NavigationModel model, string By);
        NavigationModel GetById(int ID);
        ResultModel<NavigationModel> DeleteNavigation(int ID, string by);
    }
}
