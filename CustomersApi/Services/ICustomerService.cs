using CustomersApi.DTO.Requests;
using CustomersApi.DTO.Responses;

namespace CustomersApi.Services;

public interface ICustomerService
{
    Task<IEnumerable<GetAllCustomersResponse>> GetAll();
    Task<GetCustomerByIdResponse> GetById(Guid id);
    Task<CreateCustomerResponse> Insert(CreateCustomerRequest createCustomerRequest);
    Task Update(UpdateCustomerRequest updateCustomerRequest);
    Task Delete(Guid id);
}