using Legoas.Service.Interfaces;
using Legoas.Data.Interfaces;
using Legoas.Model.Entities;

namespace Legoas.Service
{
    public class BranchService : IBranchService
    {
        private IBranchRepository _branchRepository;
        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }
        public IQueryable<Branch> GetAll()
        {
            return _branchRepository.GetAll();
        }
    }
}