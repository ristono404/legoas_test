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
    public class BranchService : IBranchService
    {
        private IBranchRepository _branchRepository;
        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        private List<ErrorModel> getErrorList(BranchModel model)
        {
            List<ErrorModel> errorList = new List<ErrorModel>();

            Branch _branch = _branchRepository.GetById(model.ID);
            if (_branch == null)
            {
                errorList.Add(new ErrorModel { Key = "ID", ErrorMessage = "ID is not registered in system" });
            }
            else
            {

                if (string.IsNullOrEmpty(model.BranchName))

                    errorList.Add(new ErrorModel { Key = "Error", ErrorMessage = "Branch name is mandatory" });

            }

            return errorList;
        }

        public IQueryable<Branch> GetAll()
        {
            return _branchRepository.GetAll();
        }

        public ResultModel<BranchModel> AddBranch(BranchModel model, string By)
        {

            ResultModel<BranchModel> result = new ResultModel<BranchModel>();

            if (string.IsNullOrEmpty(model.BranchName))
            {
                result.StatusCode = "422";
                result.StatusMessage = "Branch name is mandatory";
                return result;
            }
            try
            {
                EFResponse eFResponse = new EFResponse();
                Branch branch = new Branch();
                branch.Name = model.BranchName;
                eFResponse = _branchRepository.Insert(branch, By);
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

        public ResultModel<BranchModel> EditBranch(BranchModel model, string By)
        {

            ResultModel<BranchModel> result = new ResultModel<BranchModel>();

            if (string.IsNullOrEmpty(model.BranchName))
            {
                result.StatusCode = "422";
                result.StatusMessage = "Branch name is mandatory";
                return result;
            }
            try
            {
                Branch _branch = _branchRepository.GetById(model.ID);
                if (_branch == null)
                {
                    result.StatusCode = "422";
                    result.StatusMessage = "Data not found";
                    return result;
                }
                EFResponse eFResponse = new EFResponse();

                _branch.Name = model.BranchName;

                eFResponse = _branchRepository.Update(_branch, By);

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

        public ResultModel<BranchModel> DeleteBranch(int ID, string By)
        {

            ResultModel<BranchModel> result = new ResultModel<BranchModel>();

            try
            {
                Branch _branch = _branchRepository.GetById(ID);
                if (_branch == null)
                {
                    result.StatusCode = "422";
                    result.StatusMessage = "Data not found";
                    return result;
                }
                EFResponse eFResponse = new EFResponse();

                eFResponse = _branchRepository.Delete(_branch, By);

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

        public BranchModel GetById(int ID)
        {
            Branch branch = _branchRepository.GetById(ID);
            BranchModel model = new BranchModel(branch);
            return model;
        }
        }
}