using CarsalesHomeworkAssignment.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsalesHomeworkAssignment.BLL
{
    public class Car : IVehicle
    {
		public int Id { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public string Engine { get; set; }
		public string BodyType { get; set; }
		public int ? Wheels { get; set; }
		public int ? Doors { get; set; }

		public static Car ConvertFromDbVehicle(Vehicle car)
		{
			if (car.VehicleType != (short)VehicleType.Car)
			{
				throw new ArgumentException("The vehicle is not a car");
			}
			Car resultCar = new Car();
			resultCar.Make = car.Make;
			resultCar.Model = car.Model;
			resultCar.Engine = car.Engine;
			resultCar.BodyType = car.BodyType;
			resultCar.Wheels = car.Wheels;
			resultCar.Doors = car.Doors;
			return resultCar;

		}

		public static Vehicle ConvertToDbVehicle(Car car)
		{
			Vehicle resultCar = new Vehicle();
			resultCar.Make = car.Make;
			resultCar.Model = car.Model;
			resultCar.Engine = car.Engine;
			resultCar.BodyType = car.BodyType;
			resultCar.Wheels = car.Wheels;
			resultCar.Doors = car.Doors;
			resultCar.VehicleType = (short)VehicleType.Car;
			return resultCar;

		}

		public bool AllAttributesNull()
		{
			return this.Make == null
						&& this.Model == null
						&& this.BodyType == null
						&& this.Engine == null
						&& !this.Wheels.HasValue
						&& !this.Doors.HasValue;
		}
	}
}
