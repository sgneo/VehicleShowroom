using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VehicleShowroom.Data;
using VehicleShowroom.Models;

namespace VehicleShowroom.Pages.WheelSizes
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
            return Page();
        }

        [BindProperty]
        public WheelSize WheelSize { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.WheelSize.Add(WheelSize);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
