using CustomersApi.Repositories;
using CustomersApi.DTO.Requests;
using CustomersApi.DTO.Responses;
using AutoMapper;
using CustomersApi.Domain;

namespace CustomersApi.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;


    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAllCustomersResponse>> GetAll()
    {
        var customers = await _customerRepository.GetAll();
        
        return _mapper.Map<IEnumerable<Customer>, IEnumerable<GetAllCustomersResponse>>(customers);
    }

    public async Task<GetCustomerByIdResponse> GetById(Guid id)
    {
        var customer = await _customerRepository.GetById(id);

        return _mapper.Map<GetCustomerByIdResponse>(customer);
    }

    public async Task<CreateCustomerResponse> Insert(CreateCustomerRequest createCustomerRequest)
    {
        var customerInput = _mapper.Map<Customer>(createCustomerRequest);

        var customerOutput = await _customerRepository.Insert(customerInput);

        return _mapper.Map<CreateCustomerResponse>(customerOutput);
    }

    public async Task Update(UpdateCustomerRequest updateCustomerRequest)
    {
        var customer = _mapper.Map<Customer>(updateCustomerRequest);

        await _customerRepository.Update(customer);
    }

    public async Task Delete(Guid id)
    {
        await _customerRepository.Delete(id);
    }
}