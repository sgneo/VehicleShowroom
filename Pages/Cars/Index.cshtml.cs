using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Data;
using VehicleShowroom.Models;

namespace VehicleShowroom.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly VehicleShowroom.Data.VehicleShowroomContext _context;

        public IndexModel(VehicleShowroom.Data.VehicleShowroomContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Car
                .Include(c => c.Brand)
                .Include(c => c.Location)
                .Include(c => c.WheelSet).ToListAsync();
        }
    }
}
