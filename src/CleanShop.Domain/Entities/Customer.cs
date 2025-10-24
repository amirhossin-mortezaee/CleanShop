using CleanShop.Domain.Common;
using CleanShop.Domain.Exceptions;

namespace CleanShop.Domain.Entities;

public class Customer : BaseEntity
{
    public string FullName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string PhoneNumber { get; private set; } = null!;
    public string Address { get; private set; } = null!;

    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

    public Customer(string fullName, string email, string phone, string address)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new DomainException("نام مشتری الزامی است.");
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("ایمیل الزامی است.");

        FullName = fullName.Trim();
        Email = email.Trim();
        PhoneNumber = phone.Trim();
        Address = address.Trim();
    }

    public void AddOrder(Order order)
    {
        if (order == null)
            throw new DomainException("سفارش نمی‌تواند null باشد.");

        _orders.Add(order);
        SetUpdated();
    }
}

