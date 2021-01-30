using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleShowroom.Models
{
    public class WheelSize
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(6, 1)")]
        public decimal Size { get; set; }

        [Required]
        [Display(Name = "Wheel Size Name")]
        [StringLength(30, ErrorMessage = "Limit first name to 30 characters.")]
        public string SizeName { get; set; }
    }
}
