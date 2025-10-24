using Xunit;
using CleanShop.Domain.Entities;
using CleanShop.Domain.Exceptions;

namespace CleanShop.Domain.Tests
{
    public class ProductTests
    {
        [Fact]
        public void ReduceStock_ShouldDecreaseStock_WhenQuantityIsValid()
        {
            // Arrange 
            var product = new Product("Laptop", 1000m, 10);

            // Act
            product.ReduceStock(3);

            // Assert
            Assert.Equal(7, product.Stock); // 10 - 3 = 7
        }

        [Fact]
        public void ReduceStock_ShouldThrowException_WhenQuantityExceedsStock()
        {
            // Arrange
            var product = new Product("Phone", 200m, 5);

            // Act & Assert
            Assert.Throws<DomainException>(() => product.ReduceStock(6));
        }

        [Fact]
        public void AddStock_ShouldIncreaseStock_WhenQuantityIsValid()
        {
            // Arrange
            var product = new Product("Mouse", 100m, 5);

            // Act
            product.AddStock(5);

            // Assert
            Assert.Equal(10, product.Stock);
        }
    }
}
