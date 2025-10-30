using CleanShop.Domain.Common;
using CleanShop.Domain.Exceptions;

namespace CleanShop.Domain.Entities;

public class Order : BaseEntity
{
    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public Guid CustomerId { get; private set; }
    public decimal TotalAmount => _items.Sum(i => i.TotalPrice);

    public Order(Guid customerId)
    {
        if (customerId == Guid.Empty)
            throw new DomainException("شناسه مشتری معتبر نیست.");
        CustomerId = customerId;
    }

    public void AddItem(Product product, int quantity)
    {
        if (product == null)
            throw new DomainException("محصول نمی‌تواند null باشد.");

        if (quantity <= 0)
            throw new DomainException("تعداد باید بیشتر از صفر باشد.");

        var item = new OrderItem(product.Id, product.Price, quantity);
        _items.Add(item);
        SetUpdated();
    }

    public void RemoveItem(Guid productId)
    {
        var item = _items.FirstOrDefault(i => i.ProductId == productId);
        if(item == null)
          throw new DomainException("محصول مورد نظر در سفارش وجود ندارد");
        _items.Remove(item);
        SetUpdated();
    }

    public void ClearItems()
    {
        _items.Clear();
        SetUpdated();
    }
}
