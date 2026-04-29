using Microsoft.AspNetCore.Mvc;
using VehicleParts.API.Data;
using VehicleParts.API.Models;

namespace VehicleParts.API.Controllers;

[ApiController]
[Route("api/invoices")]
public class InvoiceController : ControllerBase
{
    private readonly AppDbContext _context;

    public InvoiceController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CreateInvoice(Invoice invoice)
    {
        if (invoice.TotalAmount > 5000)
        {
            invoice.TotalAmount *= 0.9m;
        }

        _context.Invoices.Add(invoice);
        _context.SaveChanges();
        return Ok(invoice);
    }

    [HttpGet]
    public IActionResult GetInvoices()
    {
        return Ok(_context.Invoices.ToList());
    }
}
