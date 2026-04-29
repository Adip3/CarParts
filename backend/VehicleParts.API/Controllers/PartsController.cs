using Microsoft.AspNetCore.Mvc;
using VehicleParts.API.Data;
using VehicleParts.API.Models;

namespace VehicleParts.API.Controllers;

[ApiController]
[Route("api/parts")]
public class PartsController : ControllerBase
{
    private readonly AppDbContext _context;

    public PartsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddPart(Part part)
    {
        _context.Parts.Add(part);
        _context.SaveChanges();
        return Ok(part);
    }

    [HttpGet]
    public IActionResult GetParts()
    {
        return Ok(_context.Parts.ToList());
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePart(int id)
    {
        var part = _context.Parts.Find(id);
        if (part == null) return NotFound();

        _context.Parts.Remove(part);
        _context.SaveChanges();
        return Ok();
    }
}
