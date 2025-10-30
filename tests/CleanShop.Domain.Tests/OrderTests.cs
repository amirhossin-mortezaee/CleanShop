using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using Xunit;
using CleanShop.Domain.Entities;
using CleanShop.Domain.Exceptions;


namespace CleanShop.Domain.Tests;

public class OrderTests
{
  [Fact]
  public void CreateOrder_WithValidCustomerId_ShouldSucceed()
  {
        var customerId = Guid.NewGuid();
        var order = new Order(customerId);
        Assert.Equal(customerId, order.CustomerId);
        Assert.Empty(order.Items);
        Assert.Equal(0 , order.TotalAmount);
  }

  [Fact]
  public void CreateOrder_WithEmptyCustomerId_ShouldThrowException()
  {
        Assert.Throws<DomainException>(() => new Order(Guid.Empty));
  }

  [Fact]
  public void AddItem_ShouldIncreaseItemsCount_AndUpdateTotalAmount()
  {
        var order = new Order(Guid.NewGuid());
        var product = new Product("Laptop" , 1000m, 5);
        order.AddItem(product, 2);
        Assert.Single(order.Items);
        Assert.Equal(2000m, order.TotalAmount);
  }

  [Fact]
  public void AddItem_WithInvalidQuantity_ShouldThrowException()
  {
        var Order = new Order(Guid.NewGuid());
        var product = new Product("Phone" , 500m , 10);
        Assert.Throws<DomainException>(() => Order.AddItem(product, 0));
  }

  [Fact]
  public void AddItem_WithNullProduct_ShouldThrowException()
  {
        var order = new Order(Guid.NewGuid());
        Assert.Throws<DomainException>(() => order.AddItem(null!, 1));
  }
}
