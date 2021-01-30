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
    public class IndexModel : PageModel
    {
        private readonly VehicleShowroom.Data.VehicleShowroomContext _context;

        public IndexModel(VehicleShowroom.Data.VehicleShowroomContext context)
        {
            _context = context;
        }

        public IList<WheelSet> WheelSet { get;set; }

        public async Task OnGetAsync()
        {
            WheelSet = await _context.WheelSet
                .Include(w => w.WheelSize).ToListAsync();
        }
    }
}
