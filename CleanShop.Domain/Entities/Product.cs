using CleanShop.Domain.Common;

namespace CleanShop.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }

        //سازنده کنترل شده برای اطمینان از ساخت شیء معتبر 
        public Product(string name, decimal price, int stock)
        {
            if(string.IsNullOrWhiteSpace(name))
               throw new DomainException("نام محصول الزامی است.");

            if(price <= 0)
                throw new DomainException("قیمت باید بیشتر از صفر باشد.");

            if(stock <= 0 )
                throw new DomainException("موجودی نمی تواند منفی باشد.");

                Name = name;
                Price = price;
                Stock = stock;
        }

        //کاهش موجودی
        public void ReduceStock(int quantity)
        {
            if (quantity <= 0)
                throw new DomainException("تعداد باید بیشتر از صفر باشد");

            if (quantity > Stock)
                throw new DomainException("موجودی کافی نیست.");

            Stock -= quantity;
            setUpdated();
        }
        
        //افزایش موجودی
        public void AddStock(int quantity)
        {
            if (quantity <= 0)
                throw new DomainException("تعداد باید بیشتر از صفر باشد");

            Stock += quantity;
            setUpdated();
        }
        //Navigation Property
        public Category Category { get; set; } = null!;
    }
}
