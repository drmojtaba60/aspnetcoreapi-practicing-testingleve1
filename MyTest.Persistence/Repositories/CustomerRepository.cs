namespace MyTest.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using MyTest.Domain.Abstractions;
using MyTest.Domain.Entities;
public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public Task DeleteAsync(Customer customer)
    {
        _context.Customers.Remove(customer);
        return Task.CompletedTask;
    }
}
