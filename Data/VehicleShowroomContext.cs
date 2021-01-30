using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Models;

namespace VehicleShowroom.Data
{
    public class VehicleShowroomContext : DbContext
    {
        public VehicleShowroomContext (DbContextOptions<VehicleShowroomContext> options)
            : base(options)
        {
        }

        public DbSet<VehicleShowroom.Models.Brand> Brand { get; set; }

        public DbSet<VehicleShowroom.Models.Location> Location { get; set; }

        public DbSet<VehicleShowroom.Models.WheelSet> WheelSet { get; set; }

        public DbSet<VehicleShowroom.Models.Car> Car { get; set; }

        public DbSet<VehicleShowroom.Models.WheelSize> WheelSize { get; set; }
    }
}
