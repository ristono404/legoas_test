using System.Data;
using System.Data.Entity;
using System.Linq;
using Legoas.Model.Entities;

namespace Legoas.Data.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        EFResponse Insert(Role branch, string By);
        EFResponse Update(Role branch, string By);
        EFResponse Delete(Role branch, string By);
        IQueryable<Role> GetAll();
        Role GetById(long ID);
    }
}
