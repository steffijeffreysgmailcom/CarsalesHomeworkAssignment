using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CarsalesHomeworkAssignment.DAL
{
    public class VehicleRecordDBContext : DbContext
	{
        public VehicleRecordDBContext(DbContextOptions<VehicleRecordDBContext> options) 
			: base(options)
		{
		}

		public DbSet<Vehicle> Vehicles { get; set; }
		
	}
}
