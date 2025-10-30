using CleanShop.Domain.Common;
using CleanShop.Domain.Entities;
using CleanShop.Domain.Exceptions;


namespace CleanShop.Domain;

public class OrderItem : BaseEntity
{
    public Guid ProductId { get; private set; }
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }
    public decimal TotalPrice => UnitPrice * Quantity;

    public OrderItem(Guid productId, decimal unitPrice, int quantity)
    {
        if (quantity <= 0)
            throw new DomainException("تعداد باید بیشتر از صفر باشد.");

        if (productId == Guid.Empty)
            throw new DomainException("شناسه محصول معتبر نیست.");

        if (unitPrice <= 0)
                throw new DomainException("قیمت باید بیشتر از صفر باشد.");

            
        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }
}
