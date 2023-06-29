using Legoas.Service.Interfaces;
using Legoas.Data.Interfaces;
using Legoas.Model.Entities;
using System.Linq;
using Legoas.Model.objects;
using System;
using System.Transactions;
using System.Collections.Generic;

namespace Legoas.Service
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;
        private IAccountRoleMappingRepository _accountRoleMappingRepository;
        private IAccountRoleNavigationMappingRepository _accountRoleNavigationMappingRepository;
        private IAccountBranchMappingRepository _accountBranchMappingRepository;
        public AccountService(IAccountRepository AccountRepository, IAccountBranchMappingRepository accountBranchMappingRepository, IAccountRoleMappingRepository accountRoleMappingRepository, IAccountRoleNavigationMappingRepository accountRoleNavigationMappingRepository)
        {
            _accountRepository = AccountRepository;
            _accountRoleMappingRepository = accountRoleMappingRepository;
            _accountRoleNavigationMappingRepository = accountRoleNavigationMappingRepository;
            _accountBranchMappingRepository = accountBranchMappingRepository;
        }

        public List<AccountListModel> GetAll()
        {
            List<AccountListModel> result = new List<AccountListModel>();
            foreach (var item in _accountRepository.GetAll().ToList())
            {
                var data = new AccountListModel(item);
                result.Add(data);
            }
            return result;
        }

        public ResultModel<AccountModel> AddAccount(AccountModel model, string By)
        {

            ResultModel<AccountModel> result = new ResultModel<AccountModel>();

            if (string.IsNullOrEmpty(model.FullName))
            {
                result.StatusCode = "422";
                result.StatusMessage = "Account name is mandatory";
                return result;
            }
            else if (string.IsNullOrEmpty(model.UserName))
            {
                result.StatusCode = "422";
                result.StatusMessage = "user name is mandatory";
                return result;
            }
            else if (string.IsNullOrEmpty(model.Password))
            {
                result.StatusCode = "422";
                result.StatusMessage = "Password is mandatory";
                return result;
            }
            else if (string.IsNullOrEmpty(model.Email))
            {
                result.StatusCode = "422";
                result.StatusMessage = "Email is mandatory";
                return result;
            }
            else if (string.IsNullOrEmpty(model.Address))
            {
                result.StatusCode = "422";
                result.StatusMessage = "Address is mandatory";
                return result;
            }
            else if (string.IsNullOrEmpty(model.ZipCode))
            {
                result.StatusCode = "422";
                result.StatusMessage = "ZipCode is mandatory";
                return result;
            }
            else if (string.IsNullOrEmpty(model.Province))
            {
                result.StatusCode = "422";
                result.StatusMessage = "Province is mandatory";
                return result;
            }

            if (model.AccountBranchMappings.Count == 0)
            {
                result.StatusCode = "422";
                result.StatusMessage = "Branch is mandatory";
                return result;
            }

            if (model.AccountRoleMappings.Count == 0)
            {
                result.StatusCode = "422";
                result.StatusMessage = "Role is mandatory";
                return result;
            }

            foreach (var item in model.AccountRoleMappings)
            {
                if (item.AccountRoleNavigationMappings.Count == 0)
                {
                    result.StatusCode = "422";
                    result.StatusMessage = "At least add one navigation";
                    return result;
                }
                foreach (var nav in item.AccountRoleNavigationMappings)
                {
                    if (nav.Privilege == null || nav.Privilege.Length == 0)
                    {
                        result.StatusCode = "422";
                        result.StatusMessage = "At least choose one privilege";
                        return result;
                    }
                }
            }

            var transOptions = new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted };
            using (var transScope = new TransactionScope(TransactionScopeOption.Required, transOptions))
            {
                try
                {
                    EFResponse eFResponse = new EFResponse();
                    Account _account = new Account();
                    _account.FullName = model.FullName;
                    _account.Username = model.UserName;
                    _account.Password = model.Password;
                    _account.Address = model.Address;
                    _account.Email = model.Email;
                    _account.ZipCode = model.ZipCode;
                    _account.Province = model.Province;
                    eFResponse = _accountRepository.Insert(_account, By);
                    if (!eFResponse.Success)
                    {
                        result.StatusCode = "500";
                        result.StatusMessage = "Error database";
                        transScope.Dispose();
                    }
                    else
                    {
                        foreach (var item in model.AccountBranchMappings)
                        {
                            AccountBranchMapping accountBranchMapping = new AccountBranchMapping();
                            accountBranchMapping.AccountID = _account.ID;
                            accountBranchMapping.BranchID = item.BranchID;
                            eFResponse = _accountBranchMappingRepository.Insert(accountBranchMapping);
                            if (!eFResponse.Success)
                            {
                                result.StatusCode = "500";
                                result.StatusMessage = "Error database";
                                transScope.Dispose();
                                return result;
                            }
                        }

                        foreach (var item in model.AccountRoleMappings)
                        {
                            AccountRoleMapping accountRoleMapping = new AccountRoleMapping();
                            accountRoleMapping.AccountID = _account.ID;
                            accountRoleMapping.RoleID = item.RoleID;
                            eFResponse = _accountRoleMappingRepository.Insert(accountRoleMapping);
                            if (!eFResponse.Success)
                            {
                                result.StatusCode = "500";
                                result.StatusMessage = "Error database";
                                transScope.Dispose();
                                return result;
                            }

                            foreach (var _accountRoleNavigationMapping in item.AccountRoleNavigationMappings)
                            {
                                AccountRoleNavigationMapping accountRoleNavigationMapping = new AccountRoleNavigationMapping();
                                accountRoleNavigationMapping.AccountRoleID = accountRoleMapping.ID;
                                accountRoleNavigationMapping.NavigationID = _accountRoleNavigationMapping.NavigationID;
                                accountRoleNavigationMapping.Privilege = _accountRoleNavigationMapping.Privilege;
                                eFResponse = _accountRoleNavigationMappingRepository.Insert(accountRoleNavigationMapping);
                                if (!eFResponse.Success)
                                {
                                    result.StatusCode = "500";
                                    result.StatusMessage = "Error database";
                                    transScope.Dispose();
                                    return result;
                                }
                            }

                        }

                        result.StatusCode = "200";
                        result.StatusMessage = "success";
                    }

                    transScope.Complete();
                    transScope.Dispose();
                }
                catch (Exception ex)
                {
                    transScope.Dispose();
                    result.StatusCode = "500";
                    result.StatusMessage = ex.Message;
                }

            }


            return result;
        }

        public ResultModel<AccountModel> EditAccount(AccountModel model, string By)
        {
            ResultModel<AccountModel> result = new ResultModel<AccountModel>();

            if (string.IsNullOrEmpty(model.FullName))
            {
                result.StatusCode = "422";
                result.StatusMessage = "Account name is mandatory";
                return result;
            }
            else if (string.IsNullOrEmpty(model.UserName))
            {
                result.StatusCode = "422";
                result.StatusMessage = "user name is mandatory";
                return result;
            }
            else if (string.IsNullOrEmpty(model.Password))
            {
                result.StatusCode = "422";
                result.StatusMessage = "Password is mandatory";
                return result;
            }
            else if (string.IsNullOrEmpty(model.Email))
            {
                result.StatusCode = "422";
                result.StatusMessage = "Email is mandatory";
                return result;
            }
            else if (string.IsNullOrEmpty(model.Address))
            {
                result.StatusCode = "422";
                result.StatusMessage = "Address is mandatory";
                return result;
            }
            else if (string.IsNullOrEmpty(model.ZipCode))
            {
                result.StatusCode = "422";
                result.StatusMessage = "ZipCode is mandatory";
                return result;
            }
            else if (string.IsNullOrEmpty(model.Province))
            {
                result.StatusCode = "422";
                result.StatusMessage = "Province is mandatory";
                return result;
            }

            if (model.AccountBranchMappings.Count == 0)
            {
                result.StatusCode = "422";
                result.StatusMessage = "Branch is mandatory";
                return result;
            }

            if (model.AccountRoleMappings.Count == 0)
            {
                result.StatusCode = "422";
                result.StatusMessage = "Role is mandatory";
                return result;
            }

            foreach (var item in model.AccountRoleMappings)
            {
                if (item.AccountRoleNavigationMappings.Count == 0)
                {
                    result.StatusCode = "422";
                    result.StatusMessage = "At least add one navigation";
                    return result;
                }
                foreach (var nav in item.AccountRoleNavigationMappings)
                {
                    if (nav.Privilege == null || nav.Privilege.Length == 0)
                    {
                        result.StatusCode = "422";
                        result.StatusMessage = "At least choose one privilege";
                        return result;
                    }
                }
            }

            var transOptions = new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted };
            using (var transScope = new TransactionScope(TransactionScopeOption.Required, transOptions))
            {
                try
                {
                    EFResponse eFResponse = new EFResponse();
                    Account _account = _accountRepository.GetById(model.ID);
                    if (_account == null)
                    {
                        result.StatusCode = "422";
                        result.StatusMessage = "Data not found";
                        return result;
                    }
                    _account.FullName = model.FullName;
                    _account.Username = model.UserName;
                    _account.Password = model.Password;
                    _account.Address = model.Address;
                    _account.Email = model.Email;
                    _account.ZipCode = model.ZipCode;
                    _account.Province = model.Province;
                    eFResponse = _accountRepository.Update(_account, By);
                    if (!eFResponse.Success)
                    {
                        result.StatusCode = "500";
                        result.StatusMessage = "Error database";
                        transScope.Dispose();
                        return result;
                    }
                    var branchDelete = _accountBranchMappingRepository.GetByAccountID(_account.ID);
                    eFResponse = _accountBranchMappingRepository.HardDelete(branchDelete.ToList());
                    if (!eFResponse.Success)
                    {
                        result.StatusCode = "500";
                        result.StatusMessage = "Error database";
                        transScope.Dispose();
                        return result;
                    }
                    foreach (var item in model.AccountBranchMappings)
                    {
                        AccountBranchMapping accountBranchMapping = new AccountBranchMapping();
                        accountBranchMapping.AccountID = _account.ID;
                        accountBranchMapping.BranchID = item.BranchID;
                        eFResponse = _accountBranchMappingRepository.Insert(accountBranchMapping);
                        if (!eFResponse.Success)
                        {
                            result.StatusCode = "500";
                            result.StatusMessage = "Error database";
                            transScope.Dispose();
                            return result;
                        }
                    }

                    foreach (var item in model.AccountRoleMappings)
                    {
                        AccountRoleMapping accountRoleMapping = new AccountRoleMapping();
                        accountRoleMapping.AccountID = _account.ID;
                        accountRoleMapping.RoleID = item.RoleID;

                        //remove all existing data navigation map

                        var roleDelete = _accountRoleMappingRepository.GetByAccountIDAndRoleID(accountRoleMapping.AccountID, accountRoleMapping.RoleID);

                        if (roleDelete != null)
                        {
                            var roleNavDelete = _accountRoleNavigationMappingRepository.GetByAccountRoleID(roleDelete.ID);
                            //remove child
                            if (roleNavDelete != null)
                            {
                                eFResponse = _accountRoleNavigationMappingRepository.HardDelete(roleNavDelete.ToList());
                                if (!eFResponse.Success)
                                {
                                    result.StatusCode = "500";
                                    result.StatusMessage = "Error database";
                                    transScope.Dispose();
                                    return result;
                                }
                            }
                            //remove parent
                            eFResponse = _accountRoleMappingRepository.HardDelete(roleDelete);
                            if (!eFResponse.Success)
                            {
                                result.StatusCode = "500";
                                result.StatusMessage = "Error database";
                                transScope.Dispose();
                                return result;
                            }
                        }

                        eFResponse = _accountRoleMappingRepository.Insert(accountRoleMapping);
                        if (!eFResponse.Success)
                        {
                            result.StatusCode = "500";
                            result.StatusMessage = "Error database";
                            transScope.Dispose();
                            return result;
                        }


                        foreach (var _accountRoleNavigationMapping in item.AccountRoleNavigationMappings)
                        {
                            AccountRoleNavigationMapping accountRoleNavigationMapping = new AccountRoleNavigationMapping();
                            accountRoleNavigationMapping.AccountRoleID = accountRoleMapping.ID;
                            accountRoleNavigationMapping.NavigationID = _accountRoleNavigationMapping.NavigationID;
                            accountRoleNavigationMapping.Privilege = _accountRoleNavigationMapping.Privilege;
                            eFResponse = _accountRoleNavigationMappingRepository.Insert(accountRoleNavigationMapping);
                            if (!eFResponse.Success)
                            {
                                result.StatusCode = "500";
                                result.StatusMessage = "Error database";
                                transScope.Dispose();
                                return result;
                            }
                        }

                    }

                    result.StatusCode = "200";
                    result.StatusMessage = "success";


                    transScope.Complete();
                    transScope.Dispose();
                }
                catch (Exception ex)
                {
                    transScope.Dispose();
                    result.StatusCode = "500";
                    result.StatusMessage = ex.Message;
                }

            }


            return result;
        }

        public ResultModel<AccountModel> DeleteAccount(int ID, string By)
        {

            ResultModel<AccountModel> result = new ResultModel<AccountModel>();

            try
            {
                Account _account = _accountRepository.GetById(ID);
                if (_account == null)
                {
                    result.StatusCode = "422";
                    result.StatusMessage = "Data not found";
                    return result;
                }
                EFResponse eFResponse = new EFResponse();

                eFResponse = _accountRepository.Delete(_account, By);

                if (!eFResponse.Success)
                {
                    result.StatusCode = "500";
                    result.StatusMessage = "Error database";
                }
                else
                {
                    result.StatusCode = "200";
                    result.StatusMessage = "success";
                }

            }
            catch (Exception ex)
            {
                result.StatusCode = "500";
                result.StatusMessage = ex.Message;
            }

            return result;
        }

        public AccountModel GetById(int ID)
        {
            Account Account = _accountRepository.GetById(ID);
            AccountModel model = new AccountModel(Account);
            return model;
        }
    }
}