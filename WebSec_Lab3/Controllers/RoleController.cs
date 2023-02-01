using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSec_Lab3.Data;
using WebSec_Lab3.Repository;
using WebSec_Lab3.ViewModels;

namespace WebSec_Lab3.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        ApplicationDbContext _context;
        RoleRepo _roleRepo;

        public RoleController(ApplicationDbContext context)
        {
            _context = context;
            _roleRepo = new RoleRepo(context);
        }

        // GET: Role
        public ActionResult Index()
        {
            return View(_roleRepo.GetAllRoles());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // POST: Home/Create
        public IActionResult Create([Bind("Id, RoleName")] RoleVM role)
        {
            // Ensure data is valid.
            if (ModelState.IsValid)
            {
                _roleRepo.CreateRole(role.RoleName);

                // Save is successful so show updated listing.
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }
    }

}
