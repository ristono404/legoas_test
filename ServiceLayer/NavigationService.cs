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
    public class NavigationService : INavigationService
    {
        private INavigationRepository _navigationRepository;
        public NavigationService(INavigationRepository NavigationRepository)
        {
            _navigationRepository = NavigationRepository;
        }

        private List<ErrorModel> getErrorList(NavigationModel model)
        {
            List<ErrorModel> errorList = new List<ErrorModel>();

            Navigation _Navigation = _navigationRepository.GetById(model.ID);
            if (_Navigation == null)
            {
                errorList.Add(new ErrorModel { Key = "ID", ErrorMessage = "ID is not registered in system" });
            }
            else
            {

                if (string.IsNullOrEmpty(model.NavigationName))

                    errorList.Add(new ErrorModel { Key = "Error", ErrorMessage = "Navigation name is mandatory" });

            }

            return errorList;
        }

        public IQueryable<Navigation> GetAll()
        {
            return _navigationRepository.GetAll();
        }

        public ResultModel<NavigationModel> AddNavigation(NavigationModel model, string By)
        {

            ResultModel<NavigationModel> result = new ResultModel<NavigationModel>();

            if (string.IsNullOrEmpty(model.NavigationName))
            {
                result.StatusCode = "422";
                result.StatusMessage = "Navigation name is mandatory";
                return result;
            }
            try
            {
                EFResponse eFResponse = new EFResponse();
                Navigation navigation = new Navigation();
                navigation.Name = model.NavigationName;
                navigation.Controller = model.ControllerName;
                eFResponse = _navigationRepository.Insert(navigation, By);
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

        public ResultModel<NavigationModel> EditNavigation(NavigationModel model, string By)
        {

            ResultModel<NavigationModel> result = new ResultModel<NavigationModel>();

            if (string.IsNullOrEmpty(model.NavigationName))
            {
                result.StatusCode = "422";
                result.StatusMessage = "Navigation name is mandatory";
                return result;
            }
            try
            {
                Navigation navigation = _navigationRepository.GetById(model.ID);
                if (navigation == null)
                {
                    result.StatusCode = "422";
                    result.StatusMessage = "Data not found";
                    return result;
                }
                EFResponse eFResponse = new EFResponse();

                navigation.Name = model.NavigationName;
                navigation.Controller = model.ControllerName;
                eFResponse = _navigationRepository.Update(navigation, By);

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

        public ResultModel<NavigationModel> DeleteNavigation(int ID, string By)
        {

            ResultModel<NavigationModel> result = new ResultModel<NavigationModel>();

            try
            {
                Navigation _Navigation = _navigationRepository.GetById(ID);
                if (_Navigation == null)
                {
                    result.StatusCode = "422";
                    result.StatusMessage = "Data not found";
                    return result;
                }
                EFResponse eFResponse = new EFResponse();

                eFResponse = _navigationRepository.Delete(_Navigation, By);

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

        public NavigationModel GetById(int ID)
        {
            Navigation Navigation = _navigationRepository.GetById(ID);
            NavigationModel model = new NavigationModel(Navigation);
            return model;
        }
        }
}