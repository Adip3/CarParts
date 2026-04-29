using Microsoft.AspNetCore.Mvc;
using VehicleParts.API.Data;
using VehicleParts.API.Models;

namespace VehicleParts.API.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersController : ControllerBase
{
    private readonly AppDbContext _context;

    public CustomersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return Ok(customer);
    }

    [HttpGet]
    public IActionResult GetCustomers()
    {
        return Ok(_context.Customers.ToList());
    }

    [HttpGet("search")]
    public IActionResult Search(string query)
    {
        var result = _context.Customers
            .Where(c => c.Phone.Contains(query) || c.VehicleNumber.Contains(query))
            .ToList();

        return Ok(result);
    }
}
