﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopEFRepositoryTask
{
    public class Category
    {
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
