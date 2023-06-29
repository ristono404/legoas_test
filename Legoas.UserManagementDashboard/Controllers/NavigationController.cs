using System.Linq;
using System.Web.Mvc;
using Legoas.Model.objects;
using Legoas.Service.Interfaces;

namespace Legoas.UserManagementDashboard.Controllers
{
    public class NavigationController : Controller
    {
        private INavigationService _navigationService;

        public NavigationController(INavigationService NavigationStockService)
        {
            _navigationService = NavigationStockService;
            ViewBag.Navigation = "Navigation";
        }
        // GET: Navigation
        public ActionResult Index()
        {
            var Navigations = _navigationService.GetAll();
            return View(Navigations);
        }


        // GET: Navigation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Navigation/Create
        [HttpPost]
        public JsonResult Create(NavigationModel model)
        {
            return Json(_navigationService.AddNavigation(model, "user"));
        }

        // GET: Navigation/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _navigationService.GetById(id);
            return View(data);
        }

        // POST: Navigation/Edit/5
        [HttpPost]
        public JsonResult Edit(NavigationModel model)
        {
            return Json(_navigationService.EditNavigation(model, "user"));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return Json(_navigationService.DeleteNavigation(id, "user"), JsonRequestBehavior.AllowGet);
        }
    }
}
