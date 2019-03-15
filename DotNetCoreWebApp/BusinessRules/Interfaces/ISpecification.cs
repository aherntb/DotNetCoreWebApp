namespace DotNetCoreWebApp.BusinessRules.Interfaces
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T candidate);
    }
}
