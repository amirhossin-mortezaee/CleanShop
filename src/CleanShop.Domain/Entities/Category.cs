using CleanShop.Domain.Common;
using CleanShop.Domain.Exceptions;

namespace CleanShop.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }

    private readonly List<Product> _products = new();
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

    public Category(string name, string? description = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("نام دسته‌بندی الزامی است.");

        Name = name.Trim();
        Description = description?.Trim();
    }

    public void AddProduct(Product product)
    {
        if (product == null)
            throw new DomainException("محصول نمی‌تواند null باشد.");

        _products.Add(product);
        SetUpdated();
    }
}

