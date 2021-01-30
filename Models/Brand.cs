using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VehicleShowroom.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Brand's Creation Date")]

        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
    }
}
