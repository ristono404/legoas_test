using System.Linq;
using System.Web.Mvc;
using Legoas.Model.objects;
using Legoas.Service.Interfaces;

namespace Legoas.UserManagementDashboard.Controllers
{
    public class RoleController : Controller
    {
        private IRoleService _RoleService;

        public RoleController(IRoleService RoleService)
        {
            _RoleService = RoleService;
            ViewBag.Navigation = "Role";
        }
        // GET: Role
        public ActionResult Index()
        {
            var Roles = _RoleService.GetAll();
            return View(Roles);
        }


        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public JsonResult Create(RoleModel model)
        {
            return Json(_RoleService.AddRole(model, "user"));
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _RoleService.GetById(id);
            return View(data);
        }

        // POST: Role/Edit/5
        [HttpPost]
        public JsonResult Edit(RoleModel model)
        {
            return Json(_RoleService.EditRole(model, "user"));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return Json(_RoleService.DeleteRole(id, "user"), JsonRequestBehavior.AllowGet);
        }
    }
}
