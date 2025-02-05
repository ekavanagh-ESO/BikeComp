namespace BikeComp.API.Models;

public class ComponentDTO
{
    public Guid Id { get; set; }
    public string  ComponentName { get; set; }
    public string Manufacturer { get; set; }
    public DateTimeOffset ServiceDate { get; set; }
    public Guid BikeId { get; set; }
}