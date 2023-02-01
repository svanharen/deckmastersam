using Microsoft.EntityFrameworkCore;
using WebSec_Lab3.Data;
using WebSec_Lab3.ViewModels;
using WebSec_Lab3.Models;

namespace WebSec_Lab3.Repository
{
    public class ShopRepo
    {
        ApplicationDbContext _context;
        public ShopRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            var prods = _context.Product;
            List<Product> prodList = new List<Product>();

            foreach (var product in prods)
            {
                prodList.Add(product);
            }
            return prodList;
        }
    }
}
