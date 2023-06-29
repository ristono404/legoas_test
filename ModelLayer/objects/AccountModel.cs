using Legoas.Model.Entities;
using Legoas.Model.objects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Legoas.Model.objects
{
    public class AccountModel
    {
        public AccountModel() { }

        public AccountModel(Entities.Account param)
        {
            if (param != null)
            {
                this.ID = param.ID;
                this.FullName = param.FullName;
                this.UserName = param.Username;
                this.Password = param.Password;
                this.Email = param.Email;
                this.Address = param.Address;
                this.ZipCode = param.ZipCode;
                this.Province = param.Province;
                if (param.AccountBranchMappings != null)
                {
                    this.AccountBranchMappings = new List<AccountBranchMappingModel>();
                    foreach (var item in param.AccountBranchMappings)
                    {
                        this.AccountBranchMappings.Add(new AccountBranchMappingModel { BranchID = item.BranchID, BranchName = item.Branch.Name });
                    }
                    
                }

                if (param.AccountRoleMappings != null)
                {
                    this.AccountRoleMappings = new List<AccountRoleMappingModel>();
                    foreach (var item in param.AccountRoleMappings)
                    {
                        var accountRoleMappingModel = new AccountRoleMappingModel();
                        accountRoleMappingModel.RoleID = item.RoleID;
                        accountRoleMappingModel.RoleName = item.Role.Name;
                        accountRoleMappingModel.AccountRoleNavigationMappings = new List<AccountRoleNavigationMappingModel>();
                        foreach (var nav in item.AccountRoleNavigationMappings)
                        {
                            var accountRoleNavigationMappingModel = new AccountRoleNavigationMappingModel();
                            accountRoleNavigationMappingModel.NavigationID = nav.NavigationID;
                            accountRoleNavigationMappingModel.NavigationName = nav.Navigation.Name;
                            accountRoleNavigationMappingModel.Privilege = nav.Privilege;
                            accountRoleMappingModel.AccountRoleNavigationMappings.Add(accountRoleNavigationMappingModel);
                        }
                        this.AccountRoleMappings.Add(accountRoleMappingModel);
                    }
                }
            }

        }

        public int ID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Province { get; set; }
        public List<AccountRoleMappingModel> AccountRoleMappings { get; set; }
        public List<AccountBranchMappingModel> AccountBranchMappings { get; set; }
    }

    public class AccountBranchMappingModel
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public int BranchID  { get; set; }
        public string BranchName { get; set; }
    }

    public class AccountRoleMappingModel
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public List<AccountRoleNavigationMappingModel> AccountRoleNavigationMappings { get; set; }
    }
    public class AccountRoleNavigationMappingModel
    {
        public int ID { get; set; }
        public int AccountRoleID { get; set; }
        public int NavigationID { get; set; }
        public string NavigationName { get; set; }
        public string Privilege { get; set; }
    }


    public class AccountListModel
    {
        public AccountListModel() { }

        public AccountListModel(Entities.Account param)
        {
            if (param != null)
            {
                this.ID = param.ID;
                this.FullName = param.FullName;
                this.UserName = param.Username;
                this.Password = param.Password;
                this.Email = param.Email;
                this.Address = param.Address;
                this.ZipCode = param.ZipCode;
                this.Province = param.Province;
                if (param.AccountBranchMappings != null && param.AccountBranchMappings.Count > 0)
                {
                    foreach (var item in param.AccountBranchMappings)
                    {
                        this.Branchs += item.Branch.Name + "|";
                    }
                    this.Branchs = this.Branchs.Remove(this.Branchs.Length - 1, 1);
                }
            }

        }

        public int ID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Province { get; set; }
        public string Branchs { get; set; }
    }

}

