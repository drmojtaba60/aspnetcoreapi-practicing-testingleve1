using MyTest.Domain.Entities;

namespace MyTest.Domain.Abstractions;
public interface ICustomerRepository
{
    Task AddAsync(Customer customer);
    Task<Customer?> GetByIdAsync(Guid id);
    Task<List<Customer>> GetAllAsync();
    Task DeleteAsync(Customer customer);
}
