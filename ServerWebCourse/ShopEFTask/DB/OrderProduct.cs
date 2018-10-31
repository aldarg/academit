using System.ComponentModel.DataAnnotations;

namespace ShopEFTask
{
    public class OrderProduct
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}