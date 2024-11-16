namespace DAL.Interfaces;

public interface IUnitOfWork
{
    ICustomerRepository CustomerRepository { get; }
    
    Task SaveAsync();
}