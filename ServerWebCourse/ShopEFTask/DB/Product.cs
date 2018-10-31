using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopEFTask
{
    public class Product
    {
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

        public int Price { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
