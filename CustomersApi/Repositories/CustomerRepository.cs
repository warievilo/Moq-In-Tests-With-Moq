using CustomersApi.Data;
using CustomersApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace CustomersApi.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;
    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAll() =>
        await _context.Customers.ToListAsync();

    public async Task<Customer?> GetById(Guid id) =>
        await _context.Customers.Where(x => x.Id == id).SingleOrDefaultAsync();

    public async Task<Customer> Insert(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return customer;
    }

    public async Task Update(Customer customer)
    {
        _context.Customers.Update(customer);
        
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var customer = await GetById(id);

        if (customer != null)
            _context.Customers.Remove(customer);

        await _context.SaveChangesAsync();
    }
}