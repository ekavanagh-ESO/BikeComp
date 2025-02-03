using BikeComp.API.DbContexts;
using BikeComp.API.Entities; 
using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeComp.API.Services
{
    public class BikeCompRepository : IBikeCompRepository, IDisposable
    {
        private readonly BikeCompContext _context;

        public BikeCompRepository(BikeCompContext context )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddComponent(Guid manufacturerId, Components components)
        {
            if (manufacturerId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(manufacturerId));
            }

            if (components == null)
            {
                throw new ArgumentNullException(nameof(components));
            }
            components.ManufacturerId = manufacturerId; //this sucks and is wrong, look back 
            _context.Components.Add(components); 
        }         

        public void DeleteComponent(Components components)
        {
            _context.Components.Remove(components);
        }
  
        public Components GetComponent(Guid manufacturerId, Guid courseId)
        {
            if (manufacturerId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(manufacturerId));
            }

            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            return _context.Components.FirstOrDefault(c => c.ManufacturerId == manufacturerId && c.Id == courseId);
        }

        public IEnumerable<Components> GetComponents(Guid manufacturerId)
        {
            if (manufacturerId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(manufacturerId));
            }

            return _context.Components
                        .Where(c => c.ManufacturerId == manufacturerId)
                        .OrderBy(c => c.ComponentName).ToList();
        }

        public void UpdateComponent(Components components)
        {
            // no code in this implementation
        }

        public void AddBike(Bike bike)
        {
            if (bike == null)
            {
                throw new ArgumentNullException(nameof(bike));
            }
            bike.Id = Guid.NewGuid();

            foreach (var comp in bike.Components)
            {
                comp.Id = Guid.NewGuid();
            }

            _context.Bikes.Add(bike);
        }

        public bool BikeExists(Guid BikeId)
        {
            if (BikeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(BikeId));
            }

            return _context.Bikes.Any(a => a.Id == BikeId);
        }

        public void DeleteBike(Bike bike)
        {
            if (bike == null)
            {
                throw new ArgumentNullException(nameof(bike));
            }

            _context.Bikes.Remove(bike);
        }
        
        public Bike GetBike(Guid bikeId)
        {
            if (bikeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(bikeId));
            }

            return _context.Bikes.FirstOrDefault(a => a.Id == bikeId);
        }

        public Bike GetManufacturer(Guid bikeId)
        {
                if (bikeId == Guid.Empty)
                {
                    throw new ArgumentNullException(nameof(bikeId));
                }

                return _context.Bikes.FirstOrDefault(a => a.Id == bikeId); 
        }

        public IEnumerable<Bike> GetBikes()
        {
            return _context.Bikes.ToList();
        }

        public IEnumerable<Bike> GetBikes(IEnumerable<Guid> BikeIds)
        {
            if (BikeIds == null)
            {
                throw new ArgumentNullException(nameof(BikeIds));
            }

            return _context.Bikes.Where(a => BikeIds.Contains(a.Id))
                .OrderBy(a => a.BikeName)
                .ToList();
        }

        public void UpdateBike(Bike bike)
        {
            // no code in this implementation
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
               // dispose resources when needed
            }
        }
    }
}
