using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VehicleShowroom.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Car's name")]
        [StringLength(30, ErrorMessage = "Limit to 30 characters.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "The max speed of the car")]
        public string MaxSpeed { get; set; }

        public WheelSet WheelSet { get; set; }
        public int WheelSetID { get; set; }

        public Brand Brand { get; set; }
        public int BrandID { get; set; }

        public Location Location {get; set;}
        public int LocationID { get; set; }
    }
}
