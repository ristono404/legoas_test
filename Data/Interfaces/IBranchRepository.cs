using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Legoas.Model.Entities;

namespace Legoas.Data.Interfaces
{
    public interface IBranchRepository : IRepository<Branch>
    {
        IQueryable<Branch> GetAll();
    }
}
