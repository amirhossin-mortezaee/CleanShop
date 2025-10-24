namespace CleanShop.Domain;

/// <summary>
/// خطاهای منطقی (Business Logic) در لایه دامنه
/// </summary>
public class DomainException : Exception
{
    public DomainException(string message) : base(message) {}
}
