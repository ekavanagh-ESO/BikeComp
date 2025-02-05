using BikeComp.API.Entities;
namespace BikeComp.API.Helpers;


public static class DateTimeOffSetExtensions
{
    public static int GetTimeFromlastService(this Bike bike )
    {
        var currTime = DateTime.Now;
        var diff = currTime - bike.DateOfService;
        return diff.Hours;
    }
}