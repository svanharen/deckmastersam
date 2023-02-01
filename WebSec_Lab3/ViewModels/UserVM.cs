using System.ComponentModel.DataAnnotations;

namespace WebSec_Lab3.ViewModels
{
    public class UserVM
    {
        [Key]
        public string Email { get; set; }
    }
}
