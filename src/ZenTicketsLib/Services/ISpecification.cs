namespace ZenTicketsLib.Services;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T t);
}