using Legoas.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using Legoas.Model.objects;

namespace Legoas.Service.Interfaces
{
    public interface IBranchService
    {
        IQueryable<Branch> GetAll();
        ResultModel<BranchModel> AddBranch(BranchModel model, string by);
        ResultModel<BranchModel> EditBranch(BranchModel model, string By);
        BranchModel GetById(int ID);
        ResultModel<BranchModel> DeleteBranch(int ID, string by);
    }
}
