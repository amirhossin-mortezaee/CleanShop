using CleanShop.Domain.Common;
using CleanShop.Domain.Entities;

namespace CleanShop.Domain;

public class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    // Navigation
    public ICollection<Product> Products { get; set; } = new List<Product>();

}
