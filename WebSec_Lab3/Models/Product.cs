using System.ComponentModel.DataAnnotations;

namespace WebSec_Lab3.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; } 
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }
        public string Image { get; set; }
    }
}
