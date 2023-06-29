using Legoas.Data.Context;
using Legoas.Data.Interfaces;
using Legoas.Model.Entities;

namespace Legoas.Data.Repositories
{
    class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        public BranchRepository(IMyDBContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Branch> GetAll()
        {
            return this.GetAll();
        }

    }
}
