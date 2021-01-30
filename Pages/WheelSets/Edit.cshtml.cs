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

namespace VehicleShowroom.Pages.WheelSets
{
    public class EditModel : PageModel
    {
        private readonly VehicleShowroom.Data.VehicleShowroomContext _context;

        public EditModel(VehicleShowroom.Data.VehicleShowroomContext context)
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
           ViewData["WheelSizeID"] = new SelectList(_context.WheelSize, "Id", "SizeName");
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

            _context.Attach(WheelSet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WheelSetExists(WheelSet.Id))
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

        private bool WheelSetExists(int id)
        {
            return _context.WheelSet.Any(e => e.Id == id);
        }
    }
}
