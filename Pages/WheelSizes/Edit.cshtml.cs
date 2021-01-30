using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Data;
using VehicleShowroom.Models;

namespace VehicleShowroom.Pages.WheelSizes
{
    public class EditModel : PageModel
    {
        private readonly VehicleShowroom.Data.VehicleShowroomContext _context;

        public EditModel(VehicleShowroom.Data.VehicleShowroomContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WheelSize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WheelSizeExists(WheelSize.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WheelSizeExists(int id)
        {
            return _context.WheelSize.Any(e => e.Id == id);
        }
    }
}
