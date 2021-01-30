using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Data;
using VehicleShowroom.Models;

namespace VehicleShowroom.Pages.WheelSizes
{
    public class DeleteModel : PageModel
    {
        private readonly VehicleShowroom.Data.VehicleShowroomContext _context;

        public DeleteModel(VehicleShowroom.Data.VehicleShowroomContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WheelSize WheelSize { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WheelSize = await _context.WheelSize.FirstOrDefaultAsync(m => m.Id == id);

            if (WheelSize == null)
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

            WheelSize = await _context.WheelSize.FindAsync(id);

            if (WheelSize != null)
            {
                _context.WheelSize.Remove(WheelSize);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
