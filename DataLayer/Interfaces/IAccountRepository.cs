using System.Linq;
using Legoas.Model.Entities;

namespace Legoas.Data.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        EFResponse Insert(Account account, string By);
        EFResponse Update(Account account, string By);
        EFResponse Delete(Account account, string By);
        IQueryable<Account> GetAll();
        Account GetById(long ID);
    }
}
