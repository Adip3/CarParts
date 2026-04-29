namespace VehicleParts.API.Models;

public class Invoice
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime Date { get; set; }
}
