using Microsoft.AspNetCore.Mvc;
using CustomersApi.Services;
using CustomersApi.DTO.Requests;

namespace CustomersApi.Controllers;

[ApiController]
[Route("/v1/Customer")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _customerService.GetAll();
        return Ok(customers);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetCustomers(Guid id)
    {
        var customer = await _customerService.GetById(id);
        return Ok(customer);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest createCustomerRequest)
    {
        var customer = await _customerService.Insert(createCustomerRequest);
        return Ok(customer);
    }

    [HttpPut]
    [Route("")]
    public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerRequest updateCustomerRequest)
    {
        await _customerService.Update(updateCustomerRequest);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        await _customerService.Delete(id);
        return Ok();
    }
}
