using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebSec_Lab3.Data;
using WebSec_Lab3.Models;

namespace WebSec_Lab3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Home page shows list of items.
        // Item price is set through the ViewBag.
        public IActionResult Index()
        {
            return View("Index", "3.55|CAD");
        }

        // Home page shows list of items.
        // Item price is set through the ViewBag.
        [Authorize]
        public IActionResult Transactions()
        {
            DbSet<IPN> items = _context.IPNs;

            IPN tran1 = new IPN {
                paymentID = "MPIXJIA3WD80960RK998944A",
                create_time = "25/01/2023, 18:44",
                payerFirstName = "Jimmy",
                payerEmail = "jimmy@email.ca",
                amount = "3.55",
                currency = "CAD",
                paymentMethod = "paypal"
            };

            IPN tran2 = new IPN
            {
                paymentID = "MPIXLCA6Y558451U6165562H",
                create_time = "25/01/2023, 18:36",
                payerFirstName = "Bob",
                payerEmail = "bob@email.ca",
                amount = "3.55",
                currency = "CAD",
                paymentMethod = "paypal"
            };

            IPN[] hardCodes = { tran1, tran2 };


            return View(items);
        }

        // This method receives and stores
        // the Paypal transaction details.
        [HttpPost]
        public JsonResult PaySuccess([FromBody] IPN ipn)
        {
            try
            {
                _context.IPNs.Add(ipn);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return Json(ipn);
        }

        // Home page shows list of items.
        // Item price is set through the ViewBag.
        public IActionResult Confirmation(string confirmationId)
        {
            IPN transaction =
            _context.IPNs.FirstOrDefault(t => t.paymentID == confirmationId);

            IPN transaction2 = new IPN
            {
                paymentID = "MPIXJIA3WD80960RK998944A",
                create_time = "25/01/2023, 18:44",
                payerFirstName = "Sam",
                payerEmail = "samemail@email.com",
                amount = "3.55",
                paymentMethod = "paypal"
            };

            return View("Confirmation", transaction);
        }

    }
}