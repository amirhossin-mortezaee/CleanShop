using CleanShop.Domain.Common;

namespace CleanShop.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }

        //Navigation Property

        public Category Category { get; set; } = null!;
    }
}
