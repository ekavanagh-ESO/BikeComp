namespace BikeComp.API.Models;

public class ComponentDTO
{
    public Guid Id { get; set; }
    public string  ComponentName { get; set; }
    public string Manufacturer { get; set; }
    public int DaysSinceService { get; set; }
}