using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Data;
using VehicleShowroom.Models;

namespace VehicleShowroom.Pages.WheelSets
{
    public class DetailsModel : PageModel
    {
        private readonly VehicleShowroom.Data.VehicleShowroomContext _context;

        public DetailsModel(VehicleShowroom.Data.VehicleShowroomContext context)
        {
            _context = context;
        }

        public WheelSet WheelSet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WheelSet = await _context.WheelSet
                .Include(w => w.WheelSize).FirstOrDefaultAsync(m => m.Id == id);

            if (WheelSet == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
