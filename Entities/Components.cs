using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeComp.API.Entities
{
    public class Components
    {
        [Key]       
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string  ComponentName { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }

        [ForeignKey("BikeId")]
        public Bike Bike { get; set; }
        public string Manufacturer { get; set; }
        public Guid ManufacturerId { get; set; }
        public DateTimeOffset ServiceDate { get; set; }
        public Guid BikeId { get; set; }
    }
}
