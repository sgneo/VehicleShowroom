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
    public class DeleteModel : PageModel
    {
        private readonly VehicleShowroom.Data.VehicleShowroomContext _context;

        public DeleteModel(VehicleShowroom.Data.VehicleShowroomContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WheelSet = await _context.WheelSet.FindAsync(id);

            if (WheelSet != null)
            {
                _context.WheelSet.Remove(WheelSet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
