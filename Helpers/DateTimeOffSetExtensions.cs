using BikeComp.API.Entities;
namespace BikeComp.API.Helpers;


public static class DateTimeOffSetExtensions
{
    public static int GetTimeFromlastService(this DateTimeOffset serviceDate )
    {
        var currTime = DateTime.Now;
        var diff = currTime - serviceDate;
        return diff.Days;
    }
}