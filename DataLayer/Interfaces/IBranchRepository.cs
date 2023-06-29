using System.Linq;
using Legoas.Model.Entities;

namespace Legoas.Data.Interfaces
{
    public interface IBranchRepository : IRepository<Branch>
    {
        EFResponse Insert(Branch branch, string By);
        EFResponse Update(Branch branch, string By);
        EFResponse Delete(Branch branch, string By);
        IQueryable<Branch> GetAll();
        Branch GetById(int ID);
    }
}
