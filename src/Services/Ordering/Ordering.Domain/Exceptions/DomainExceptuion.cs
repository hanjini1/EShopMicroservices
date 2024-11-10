namespace Ordering.Domain.Exceptions
{
    public class DomainExceptuion : Exception
    {
        public DomainExceptuion(string message) : base($"Domain Exception: \"{message}\" throws from Domain Layer.")
        {
        }
    }
}
