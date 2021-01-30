using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VehicleShowroom.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name of the location")]
        [StringLength(30, ErrorMessage = "Limit to 30 characters.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Locationn's Address")]
        [StringLength(30, ErrorMessage = "Limit to 30 characters.")]
        public string Address { get; set; }
    }
}
