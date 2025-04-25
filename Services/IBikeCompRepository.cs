using BikeComp.API.Entities;
using BikeComp.API.ResourceParameters;

namespace BikeComp.API.Services
{
    public interface IBikeCompRepository
    {
        IEnumerable<Components> GetComponents(Guid compId);
        Components GetComponent(Guid manufacturerId, Guid compId);
        void AddComponent(Guid manufacturerId, Components components);
        void UpdateComponent(Components components);
        void DeleteComponent(Components components);
        IEnumerable<Bike> GetBikes();
        IEnumerable<Bike> GetBikes(BikeParameters bikeParameters);
        Bike GetBike(Guid bikeId);
        Bike GetManufacturer(Guid manufacturerId);
        IEnumerable<Bike> GetBikes(IEnumerable<Guid> manufacturerIds);
        void AddBike(Bike bike);
        void DeleteBike(Bike bike);
        void UpdateBike(Bike bike);
        bool BikeExists(Guid BikeId);
        bool Save();
    }
}
