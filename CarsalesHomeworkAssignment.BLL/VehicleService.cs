using CarsalesHomeworkAssignment.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsalesHomeworkAssignment.BLL
{
    public class VehicleService
    {
		public static List<IVehicle> GetAllVehiclesOfType(VehicleType type)
		{
			var builder = new DbContextOptionsBuilder<VehicleRecordDBContext>();
			builder.UseInMemoryDatabase("VehicleRecordDB");
			using (DAL.VehicleRecordDBContext database = new DAL.VehicleRecordDBContext(builder.Options))
			{
				List<Vehicle> vehicles = database.Vehicles.Where(v => v.VehicleType == (short)type).ToList();
				
				if (type == VehicleType.Car)
				{
					List<Car> result = new List<Car>();
					foreach (Vehicle car in vehicles)
					{
						result.Add(Car.ConvertFromDbVehicle(car));
					}
					return result.ConvertAll(x => (IVehicle)x);
				} else
				{
					return null;
				}

			}
			
		}

		public static IVehicle GetVehicle(int id)
		{
			var builder = new DbContextOptionsBuilder<VehicleRecordDBContext>();
			builder.UseInMemoryDatabase("VehicleRecordDB");
			using (DAL.VehicleRecordDBContext database = new DAL.VehicleRecordDBContext(builder.Options))
			{
				Vehicle vehicle = database.Vehicles.Where(v => v.Id == id).FirstOrDefault();

				if (vehicle == null)
				{
					throw new VehicleNotFoundException("The vehicle with id " + id.ToString() + " was not found");
				}

				if ((VehicleType)vehicle.VehicleType == VehicleType.Car)
				{
					return Car.ConvertFromDbVehicle(vehicle);
				}
				else
				{
					return null;
				}

			}
		}

		public static void CreateVehicle(IVehicle vehicle)
		{
			Vehicle dbVehicle = null;
			if (vehicle.AllAttributesNull())
			{
				throw new AllAttributesNullException("None of the attributes in the vehicle had a value");
			}

			if (vehicle.GetType() == typeof(Car))
			{
				dbVehicle = Car.ConvertToDbVehicle((Car)vehicle);
			}

			if (dbVehicle != null)
			{
				var builder = new DbContextOptionsBuilder<VehicleRecordDBContext>();
				builder.UseInMemoryDatabase("VehicleRecordDB");
				using (DAL.VehicleRecordDBContext database = new DAL.VehicleRecordDBContext(builder.Options))
				{
					database.Vehicles.Add(dbVehicle);
					database.SaveChanges();
				}
			}
		}
		
		public static void EditVehicle(int id, IVehicle vehicle)
		{
			if (vehicle.AllAttributesNull())
			{
				throw new AllAttributesNullException("None of the attributes in the vehicle had a value");
			}

			var builder = new DbContextOptionsBuilder<VehicleRecordDBContext>();
			builder.UseInMemoryDatabase("VehicleRecordDB");
			using (DAL.VehicleRecordDBContext database = new DAL.VehicleRecordDBContext(builder.Options))
			{
				Vehicle dbVehicle = database.Vehicles.Where(v => v.Id == id).FirstOrDefault();
				
				if (dbVehicle == null)
				{
					throw new VehicleNotFoundException("The vehicle with id " + id.ToString() + " was not found");
				}
				
				dbVehicle.Make = vehicle.Make;
				dbVehicle.Model = vehicle.Model;

				if ((VehicleType)dbVehicle.VehicleType == VehicleType.Car)
				{
					Car car = (Car)vehicle;
					dbVehicle.Engine = car.Engine;
					dbVehicle.BodyType = car.BodyType;
					dbVehicle.Wheels = car.Wheels;
					dbVehicle.Doors = car.Doors;

				}

				database.SaveChanges();
			}
		}
	}
}
