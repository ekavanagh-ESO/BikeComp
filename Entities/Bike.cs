using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BikeComp.API.Entities
{
    public class Bike
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string BikeName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Manufacturer { get; set; }

        [Required]
        public DateTimeOffset DateOfService { get; set; }          

        [Required]
        [MaxLength(50)]
        public string BikeType { get; set; }

        public ICollection<Components> Components { get; set; }
            = new List<Components>();
        
    }
}
