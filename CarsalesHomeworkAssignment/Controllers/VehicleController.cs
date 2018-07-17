using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarsalesHomeworkAssignment.BLL;

namespace carsalesHomeworkAssignment.WebPortal.Controllers
{
    [Route("api/Vehicle")]
    public class VehicleController : Controller
    {
		[HttpGet]
		[Route("api/Vehicle/Index")]
		public IEnumerable<Car> Index()
        {
			List<Car> cars = VehicleService.GetAllVehiclesOfType(VehicleType.Car).ConvertAll(x => (Car)x);
			
			return cars;
        }

		[HttpPost]
		[Route("api/Vehicle/CreateCar")]
		public int CreateCar([FromBody] Car car)
		{
			VehicleService.CreateVehicle(car);
			return 0;
		}

		[HttpPut]
		[Route("api/Vehicle/EditCar")]
		public int Edit([FromBody]Car car)
		{
			VehicleService.EditVehicle(car.Id, car);
			return 0;
		}

		[HttpGet]
		[Route("api/Vehicle/CarDetails/{id}")]
		public Car Details(int id)
		{
			IVehicle vehicle = VehicleService.GetVehicle(id);
			if (vehicle.GetType() == typeof(Car))
			{
				return (Car)VehicleService.GetVehicle(id);
			}

			return null;
		}

		public class CarView
		{
			public string Make { get; set; }
			public int Id { get; set; }
			public string Model { get; set; }
		}
    }
}
