using System;
using System.Linq;

namespace CarsalesHomeworkAssignment.DAL
{
    public class Vehicle
	{
		public int Id { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public string Engine { get; set; }
		public string BodyType { get; set; }
		public int ? Wheels { get; set; }
		public int ? Doors { get; set; }
		public short VehicleType { get; set; }
	}
}
