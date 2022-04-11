using CustomersApi.Domain;

namespace CustomersApi.Repositories;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAll();
    Task<Customer?> GetById(Guid id);
    Task<Customer> Insert(Customer customer);
    Task Update(Customer customer);
    Task Delete(Guid id);
}