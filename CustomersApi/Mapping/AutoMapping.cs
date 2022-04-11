using AutoMapper;
using CustomersApi.DTO.Requests;
using CustomersApi.DTO.Responses;
using CustomersApi.Domain;

namespace CustomersApi.Mapping;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<Customer, GetAllCustomersResponse>().ReverseMap();
        CreateMap<Customer, GetCustomerByIdResponse>().ReverseMap();
        CreateMap<Customer, CreateCustomerResponse>().ReverseMap();

        CreateMap<Customer, CreateCustomerRequest>().ReverseMap();
        CreateMap<Customer, UpdateCustomerRequest>().ReverseMap();
    }
}
