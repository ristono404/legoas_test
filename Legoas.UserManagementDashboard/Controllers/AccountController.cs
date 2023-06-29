using System.Linq;
using System.Web.Mvc;
using Legoas.Model.objects;
using Legoas.Service.Interfaces;

namespace Legoas.UserManagementDashboard.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService _accountService;
        private IRoleService _roleService;
        private INavigationService _navigationService;
        private IBranchService _branchService;

        public AccountController(IAccountService accountService, IRoleService roleService, INavigationService navigationService, IBranchService branchService)
        {
            _accountService = accountService;
            _roleService = roleService;
            _navigationService = navigationService;
            _branchService = branchService;
            ViewBag.Navigation = "Account";
        }
        // GET: Account
        public ActionResult Index()
        {
            var Accounts = _accountService.GetAll();
            return View(Accounts);
        }


        // GET: Account/Create
        public ActionResult Create()
        {
            ViewBag.ListRole = _roleService.GetAll().ToList();
            ViewBag.ListNavigation = _navigationService.GetAll().ToList();
            ViewBag.ListBranch = _branchService.GetAll().ToList();
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public JsonResult Create(AccountModel model)
        {
            return Json(_accountService.AddAccount(model, "user"));
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ListRole = _roleService.GetAll().ToList();
            ViewBag.ListNavigation = _navigationService.GetAll().ToList();
            ViewBag.ListBranch = _branchService.GetAll().ToList();
            var data = _accountService.GetById(id);
            return View(data);
        }

        // POST: Account/Edit/5
        [HttpPost]
        public JsonResult Edit(AccountModel model)
        {
            return Json(_accountService.EditAccount(model, "user"));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return Json(_accountService.DeleteAccount(id, "user"), JsonRequestBehavior.AllowGet);
        }
    }
}
