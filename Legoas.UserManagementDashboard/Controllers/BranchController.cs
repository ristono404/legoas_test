using System.Linq;
using System.Web.Mvc;
using Legoas.Model.objects;
using Legoas.Service.Interfaces;

namespace Legoas.UserManagementDashboard.Controllers
{
    public class BranchController : Controller
    {
        private IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
            ViewBag.Navigation = "Branch";
        }
        // GET: Branch
        public ActionResult Index()
        {
            var branchs = _branchService.GetAll();
            return View(branchs);
        }


        // GET: Branch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Branch/Create
        [HttpPost]
        public JsonResult Create(BranchModel model)
        {
            return Json(_branchService.AddBranch(model, "user"));
        }

        // GET: Branch/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _branchService.GetById(id);
            return View(data);
        }

        // POST: Branch/Edit/5
        [HttpPost]
        public JsonResult Edit(BranchModel model)
        {
            return Json(_branchService.EditBranch(model, "user"));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return Json(_branchService.DeleteBranch(id, "user"), JsonRequestBehavior.AllowGet);
        }
    }
}
