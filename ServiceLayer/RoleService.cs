using Legoas.Service.Interfaces;
using Legoas.Data.Interfaces;
using Legoas.Model.Entities;
using System.Linq;
using Legoas.Model.objects;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System;

namespace Legoas.Service
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _RoleRepository;
        public RoleService(IRoleRepository RoleRepository)
        {
            _RoleRepository = RoleRepository;
        }

        private List<ErrorModel> getErrorList(RoleModel model)
        {
            List<ErrorModel> errorList = new List<ErrorModel>();

            Role _Role = _RoleRepository.GetById(model.ID);
            if (_Role == null)
            {
                errorList.Add(new ErrorModel { Key = "ID", ErrorMessage = "ID is not registered in system" });
            }
            else
            {

                if (string.IsNullOrEmpty(model.RoleName))

                    errorList.Add(new ErrorModel { Key = "Error", ErrorMessage = "Role name is mandatory" });

            }

            return errorList;
        }

        public IQueryable<Role> GetAll()
        {
            return _RoleRepository.GetAll();
        }

        public ResultModel<RoleModel> AddRole(RoleModel model, string By)
        {

            ResultModel<RoleModel> result = new ResultModel<RoleModel>();

            if (string.IsNullOrEmpty(model.RoleName))
            {
                result.StatusCode = "422";
                result.StatusMessage = "Role name is mandatory";
                return result;
            }
            try
            {
                EFResponse eFResponse = new EFResponse();
                Role Role = new Role();
                Role.Name = model.RoleName;
                eFResponse = _RoleRepository.Insert(Role, By);
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

        public ResultModel<RoleModel> EditRole(RoleModel model, string By)
        {

            ResultModel<RoleModel> result = new ResultModel<RoleModel>();

            if (string.IsNullOrEmpty(model.RoleName))
            {
                result.StatusCode = "422";
                result.StatusMessage = "Role name is mandatory";
                return result;
            }
            try
            {
                Role _Role = _RoleRepository.GetById(model.ID);
                if (_Role == null)
                {
                    result.StatusCode = "422";
                    result.StatusMessage = "Data not found";
                    return result;
                }
                EFResponse eFResponse = new EFResponse();

                _Role.Name = model.RoleName;

                eFResponse = _RoleRepository.Update(_Role, By);

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

        public ResultModel<RoleModel> DeleteRole(int ID, string By)
        {

            ResultModel<RoleModel> result = new ResultModel<RoleModel>();

            try
            {
                Role _Role = _RoleRepository.GetById(ID);
                if (_Role == null)
                {
                    result.StatusCode = "422";
                    result.StatusMessage = "Data not found";
                    return result;
                }
                EFResponse eFResponse = new EFResponse();

                eFResponse = _RoleRepository.Delete(_Role, By);

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

        public RoleModel GetById(int ID)
        {
            Role Role = _RoleRepository.GetById(ID);
            RoleModel model = new RoleModel(Role);
            return model;
        }
        }
}