namespace BikeComp.API.Models;

public class BikeDTO
{
    public Guid Id { get; set; }
    public string BikeName { get; set; }
    public int DaysSinceService { get; set; }
    public string BikeType { get; set; }

}