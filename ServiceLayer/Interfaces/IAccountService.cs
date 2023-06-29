using Legoas.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using Legoas.Model.objects;

namespace Legoas.Service.Interfaces
{
    public interface IAccountService
    {
        List<AccountListModel> GetAll();
        ResultModel<AccountModel> AddAccount(AccountModel model, string by);
        ResultModel<AccountModel> EditAccount(AccountModel model, string By);
        AccountModel GetById(int ID);
        ResultModel<AccountModel> DeleteAccount(int ID, string by);
    }
}
