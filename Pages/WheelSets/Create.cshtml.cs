using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VehicleShowroom.Data;
using VehicleShowroom.Models;

namespace VehicleShowroom.Pages.WheelSets
{
    public class CreateModel : PageModel
    {
        private readonly VehicleShowroom.Data.VehicleShowroomContext _context;

        public CreateModel(VehicleShowroom.Data.VehicleShowroomContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["WheelSizeID"] = new SelectList(_context.WheelSize, "Id", "SizeName");
            return Page();
        }

        [BindProperty]
        public WheelSet WheelSet { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.WheelSet.Add(WheelSet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
