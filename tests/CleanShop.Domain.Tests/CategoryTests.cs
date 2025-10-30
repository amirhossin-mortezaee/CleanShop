using CleanShop.Domain.Entities;
using CleanShop.Domain.Exceptions;

namespace CleanShop.Domain.Tests;

public class CategoryTests
{
    [Fact]
    public void CreateCategory_WithValidName_ShouldSucceed()
    {
        var category = new Category("Electronics", "Devices and gadgets");
        Assert.Equal("Electronics", category.Name);
        Assert.Equal("Devices and gadgets", category.Description);
        Assert.Empty(category.Products);
    }

    [Fact]
    public void CreateCategory_WithEmptyName_ShouldThrowException()
    {
        Assert.Throws<DomainException>(() => new Category(""));
    }

    [Fact]
    public void AddProduct_ShouldAddToProductsList()
    {
        var category = new Category("Computers");
        var product = new Product("Laptop" , 200m , 10);

        category.AddProduct(product);

        Assert.Single(category.Products);
        Assert.Contains(product, category.Products);
    }

    [Fact]
    public void AddProduct_WithNullProduct_ShouldThrowException()
    {
        var category = new Category("Accessories");
        Assert.Throws<DomainException>(() => category.AddProduct(null!));
    }
}
