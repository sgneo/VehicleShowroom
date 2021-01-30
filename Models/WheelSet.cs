using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleShowroom.Models
{
    public class WheelSet
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "WheelSet's brand name")]
        [StringLength(30, ErrorMessage = "Limit to 30 characters.")]
        public string BrandName { get; set; }

        public WheelSize WheelSize { get; set; }
        public int WheelSizeID { get; set; }

    }
}
