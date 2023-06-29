using Legoas.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using Legoas.Model.objects;

namespace Legoas.Service.Interfaces
{
    public interface IRoleService
    {
        IQueryable<Role> GetAll();
        ResultModel<RoleModel> AddRole(RoleModel model, string by);
        ResultModel<RoleModel> EditRole(RoleModel model, string By);
        RoleModel GetById(int ID);
        ResultModel<RoleModel> DeleteRole(int ID, string by);
    }
}
