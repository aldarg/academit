using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopEFRepositoryTask
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public DateTime Birthday { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
