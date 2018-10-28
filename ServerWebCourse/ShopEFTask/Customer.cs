using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopEFTask
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Fio { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
