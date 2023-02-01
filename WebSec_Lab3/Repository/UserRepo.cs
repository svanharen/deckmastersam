using WebSec_Lab3.Data;
using WebSec_Lab3.ViewModels;

namespace WebSec_Lab3.Repository
{
    public class UserRepo
    {
        ApplicationDbContext _context;
        public UserRepo(ApplicationDbContext context) 
        {
            _context = context;
        }

        public IEnumerable<UserVM> GetAllUserEmails()
        {
            IEnumerable<UserVM> users = _context.Users.Select(u => new UserVM() { Email = u.Email });
            return users;
        }
    }
}
