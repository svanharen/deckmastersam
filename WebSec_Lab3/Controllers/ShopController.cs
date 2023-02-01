using Microsoft.AspNetCore.Mvc;
using WebSec_Lab3.Data;
using WebSec_Lab3.Repository;

namespace WebSec_Lab3.Controllers
{
    public class ShopController : Controller
    {
        ApplicationDbContext _context;
        ShopRepo _shopRepo;

        public ShopController(ApplicationDbContext context)
        {
            _context = context;
            _shopRepo = new ShopRepo(_context);
        }

        public IActionResult Index()
        {
            var products = _shopRepo.GetAllProducts();

            return View(products);
        }


    }
}
