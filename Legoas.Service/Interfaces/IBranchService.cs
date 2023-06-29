using Legoas.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legoas.Service.Interfaces
{
    public interface IBranchService
    {
        IQueryable<Branch> GetAll();

    }
}
