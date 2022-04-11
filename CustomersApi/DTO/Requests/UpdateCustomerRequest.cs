namespace CustomersApi.DTO.Requests;

public class UpdateCustomerRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}