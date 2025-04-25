namespace BikeComp.API.Models;

public class CompCreationDTO
{
    public string ComponentName { get; set; }
    public string Manufacturer { get; set; }
    public string Description { get; set; }
    public int DaysSinceService { get; set; }
}