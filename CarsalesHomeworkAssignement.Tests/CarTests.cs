using CarsalesHomeworkAssignment.DAL;
using CarsalesHomeworkAssignment.BLL;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using carsalesHomeworkAssignment;
using Microsoft.Extensions.Configuration;

namespace CarsalesHomeworkAssignement.Tests
{
	

	public class TestStartup : Startup
	{
		public TestStartup(IConfiguration configuration) : base(configuration)
		{
		}

		public override void ConfigureServices(IServiceCollection services)
		{
			services
				.AddEntityFrameworkInMemoryDatabase()
				.AddDbContext<CarsalesHomeworkAssignment.DAL.VehicleRecordDBContext>((sp, options) =>
				{
					options.UseInMemoryDatabase("VehicleRecordDB").UseInternalServiceProvider(sp);
				});
			base.ConfigureServices(services);
		}
	}

	public class Given_The_User_Is_Creating_A_Car
	{

		public class And_The_User_Fills_In_All_Fields
		{

			public HttpClient Client { get; set; }
			private readonly TestServer _server;

			[Fact]
			public void It_Saves_A_New_Car_With_All_The_Feilds()
			{

				string testCarMake = "Test new car with all feilds";
				string testCarModel = "A4";
				string testCarEngine = "4 cylinder Petrol Turbo Intercooled 2.0L";
				string testCarBodyType = "5 doors 5 seat Wagon";
				int testCarWheels = 4;
				int testCarDoors = 5;

				Car testCar = new Car();
				testCar.Make = testCarMake;
				testCar.Model = testCarModel;
				testCar.Engine = testCarEngine;
				testCar.BodyType = testCarBodyType;
				testCar.Wheels = testCarWheels;
				testCar.Doors = testCarDoors;
				VehicleService.CreateVehicle(testCar);

				var builder = new DbContextOptionsBuilder<VehicleRecordDBContext>();
				builder.UseInMemoryDatabase("VehicleRecordDB");

				using (VehicleRecordDBContext database = new VehicleRecordDBContext(builder.Options))
				{
					Vehicle resultVehicle = database.Vehicles.Where(v => v.Make == testCarMake).FirstOrDefault();
					Assert.Equal(testCarMake, resultVehicle.Make);
					Assert.Equal(testCarModel, resultVehicle.Model);
					Assert.Equal(testCarEngine, resultVehicle.Engine);
					Assert.Equal(testCarBodyType, resultVehicle.BodyType);
					Assert.Equal(testCarWheels, resultVehicle.Wheels);
					Assert.Equal(testCarDoors, resultVehicle.Doors);
					Assert.Equal((short)VehicleType.Car, resultVehicle.VehicleType);
				}
			}
		}

		public class And_The_User_Fills_In_None_Of_The_Fields
		{
			[Fact]
			public void It_Returns_A_No_Fields_Provided_Exception()
			{

				Car testCar = new Car();

				Assert.Throws<AllAttributesNullException>(() =>
									VehicleService.CreateVehicle(testCar));
			}
		}

		public class And_The_User_Fills_In_One_Field
		{
			[Fact]
			public void It_Saves_A_New_Car_With_Just_That_Feild()
			{
				
				string testCarEngine = "Test new car with only one feild";

				Car testCar = new Car();
				testCar.Engine = testCarEngine;
				VehicleService.CreateVehicle(testCar);

				var builder = new DbContextOptionsBuilder<VehicleRecordDBContext>();
				builder.UseInMemoryDatabase("VehicleRecordDB");

				using (VehicleRecordDBContext database = new VehicleRecordDBContext(builder.Options))
				{
					Vehicle resultVehicle = database.Vehicles.Where(v => v.Engine == testCarEngine).FirstOrDefault();
					Assert.Null(resultVehicle.Make);
					Assert.Null(resultVehicle.Model);
					Assert.Equal(testCarEngine, resultVehicle.Engine);
					Assert.Null(resultVehicle.BodyType);
					Assert.Null(resultVehicle.Wheels);
					Assert.Null(resultVehicle.Doors);
					Assert.Equal((short)VehicleType.Car, resultVehicle.VehicleType);

				}
			}
		}
	}

	public class Given_The_User_Wants_To_See_All_Their_Cars
	{

		public class And_There_Is_No_Cars_In_The_System
		{
			[Fact]
			public void It_Returns_An_Empty_List()
			{
				List<IVehicle> result = VehicleService.GetAllVehiclesOfType(VehicleType.Car);
				Assert.Empty(result);
			}
		}


		public class And_There_Is_One_Car_In_The_System
		{
			[Fact]
			public void It_Returns_That_One_Car()
			{
				var builder = new DbContextOptionsBuilder<VehicleRecordDBContext>();
				builder.UseInMemoryDatabase("VehicleRecordDB");

				using (VehicleRecordDBContext database = new VehicleRecordDBContext(builder.Options))
				{
					Vehicle testCar = new Vehicle();
					testCar.Make = "Test Searching for one car";
					testCar.VehicleType = (short)VehicleType.Car;
					database.Add(testCar);
					database.SaveChanges();
				}

				List<IVehicle> result = VehicleService.GetAllVehiclesOfType(VehicleType.Car);
				Assert.Single(result);

			}
		}

		public class And_There_Are_Many_Cars_In_The_System
		{
			[Fact]
			public void It_Returns_All_The_Cars_In_The_System()
			{
				int numberOfCarsInSystem = 3;
				var builder = new DbContextOptionsBuilder<VehicleRecordDBContext>();
				builder.UseInMemoryDatabase("VehicleRecordDB");

				using (VehicleRecordDBContext database = new VehicleRecordDBContext(builder.Options))
				{
					for (int testCarNo = 0; testCarNo < numberOfCarsInSystem; testCarNo++)
					{
						Vehicle testCar = new Vehicle();
						testCar.Make = "Test Searching for many cars: car " + testCarNo;
						testCar.VehicleType = (short)VehicleType.Car;
						database.Add(testCar);
					}
					database.SaveChanges();
				}


				List<IVehicle> result = VehicleService.GetAllVehiclesOfType(VehicleType.Car);
				Assert.Equal(numberOfCarsInSystem, result.Count);
			}
		}

	}

	public class Given_The_User_Is_Retrieving_A_Single_Car
	{
		public class Add_The_Car_Does_Not_Exist
		{
			[Fact]
			public void It_Throws_A_Vehicle_Not_Found_Exception()
			{
				Assert.Throws<VehicleNotFoundException>(() =>
									VehicleService.GetVehicle(89));
			}
		}


		public class Add_The_Car_Does_Exist
		{
			[Fact]
			public void It_Returns_The_Car()
			{
				int testCarId = 0;
				string testCarMake = "Testing getting one car that exisits";

				var builder = new DbContextOptionsBuilder<VehicleRecordDBContext>();
				builder.UseInMemoryDatabase("VehicleRecordDB");

				using (VehicleRecordDBContext database = new VehicleRecordDBContext(builder.Options))
				{
					Vehicle testCar = new Vehicle();
					testCar.Make = testCarMake;
					testCar.VehicleType = (short)VehicleType.Car;
					database.Add(testCar);
					database.SaveChanges();
					testCarId = testCar.Id;
				}

				Car result = (Car)VehicleService.GetVehicle(testCarId);
				Assert.Equal(testCarMake, result.Make);
			}

		}
	}

	public class Given_The_User_Is_Editing_A_Car
	{

		public class And_The_Car_Does_Not_Exist
		{
			[Fact]
			public void It_Throws_A_Vehicle_Not_Found_Exception()
			{

				string testCarModel = "Test edit car with only one feild";

				Car testCar = new Car();
				testCar.Model = testCarModel;

				Assert.Throws<VehicleNotFoundException>(() =>
									VehicleService.EditVehicle(89, testCar));
			}
		}

		public class And_The_Car_Does_Exist
		{
			public class And_The_User_Fills_In_All_Fields
			{
				[Fact]
				public void It_Changes_All_The_Fields_On_That_Car()
				{
					string testCarMake = "Test new car with all feilds";
					string testCarModel = "A4";
					string testCarEngine = "4 cylinder Petrol Turbo Intercooled 2.0L";
					string testCarBodyType = "5 doors 5 seat Wagon";
					int testCarWheels = 4;
					int testCarDoors = 5;
					int testCarId = 0;

					Vehicle seedCar = new Vehicle();
					seedCar.Make = "Non-edited";
					seedCar.Model = "Non-edited";
					seedCar.Engine = "Non-edited";
					seedCar.BodyType = "Non-edited";
					seedCar.Wheels = 9;
					seedCar.Doors = 10;
					seedCar.VehicleType = (short)VehicleType.Car;

					var builder = new DbContextOptionsBuilder<VehicleRecordDBContext>();
					builder.UseInMemoryDatabase("VehicleRecordDB");

					using (VehicleRecordDBContext database = new VehicleRecordDBContext(builder.Options))
					{
						database.Add(seedCar);
						database.SaveChanges();
						testCarId = seedCar.Id;
					}

					Car testCar = new Car();
					testCar.Make = testCarMake;
					testCar.Model = testCarModel;
					testCar.Engine = testCarEngine;
					testCar.BodyType = testCarBodyType;
					testCar.Wheels = testCarWheels;
					testCar.Doors = testCarDoors;
					VehicleService.EditVehicle(testCarId, testCar);

					using (VehicleRecordDBContext database = new VehicleRecordDBContext(builder.Options))
					{
						Vehicle resultVehicle = database.Vehicles.Where(v => v.Id == testCarId).FirstOrDefault();
						Assert.Equal(testCarMake, resultVehicle.Make);
						Assert.Equal(testCarModel, resultVehicle.Model);
						Assert.Equal(testCarEngine, resultVehicle.Engine);
						Assert.Equal(testCarBodyType, resultVehicle.BodyType);
						Assert.Equal(testCarWheels, resultVehicle.Wheels);
						Assert.Equal(testCarDoors, resultVehicle.Doors);
						Assert.Equal((short)VehicleType.Car, resultVehicle.VehicleType);
					}

				}
			}

			public class And_The_User_Fills_In_None_Of_The_Fields
			{
				[Fact]
				public void It_Makes_No_Change_To_The_Car_And_Throws_An_AllAttributesNullException()
				{
					string seedCarMake = "Test new car with all feilds";
					string seedCarModel = "A4";
					string seedCarEngine = "4 cylinder Petrol Turbo Intercooled 2.0L";
					string seedCarBodyType = "5 doors 5 seat Wagon";
					int seedCarWheels = 4;
					int seedCarDoors = 5;
					int seedCarId = 0;

					Vehicle seedCar = new Vehicle();
					seedCar.Make = seedCarMake;
					seedCar.Model = seedCarModel;
					seedCar.Engine = seedCarEngine;
					seedCar.BodyType = seedCarBodyType;
					seedCar.Wheels = seedCarWheels;
					seedCar.Doors = seedCarDoors;
					seedCar.VehicleType = (short)VehicleType.Car;

					var builder = new DbContextOptionsBuilder<VehicleRecordDBContext>();
					builder.UseInMemoryDatabase("VehicleRecordDB");

					using (VehicleRecordDBContext database = new VehicleRecordDBContext(builder.Options))
					{
						database.Add(seedCar);
						database.SaveChanges();
						seedCarId = seedCar.Id;
					}

					Car testCar = new Car();

					Assert.Throws<AllAttributesNullException>(() =>
										VehicleService.EditVehicle(seedCarId, testCar));

					using (VehicleRecordDBContext database = new VehicleRecordDBContext(builder.Options))
					{
						Vehicle resultVehicle = database.Vehicles.Where(v => v.Id == seedCarId).FirstOrDefault();
						Assert.Equal(seedCarMake, resultVehicle.Make);
						Assert.Equal(seedCarModel, resultVehicle.Model);
						Assert.Equal(seedCarEngine, resultVehicle.Engine);
						Assert.Equal(seedCarBodyType, resultVehicle.BodyType);
						Assert.Equal(seedCarWheels, resultVehicle.Wheels);
						Assert.Equal(seedCarDoors, resultVehicle.Doors);
						Assert.Equal((short)VehicleType.Car, resultVehicle.VehicleType);

					}
				}
			}

			public class And_The_User_Fills_In_One_Field
			{
				[Fact]
				public void It_Changes_That_Field_And_Sets_All_Other_Fields_To_Null()
				{
					string seedCarMake = "Test new car with all feilds";
					string seedCarModel = "A4";
					string seedCarEngine = "4 cylinder Petrol Turbo Intercooled 2.0L";
					string seedCarBodyType = "5 doors 5 seat Wagon";
					int seedCarWheels = 4;
					int seedCarDoors = 5;
					int seedCarId = 0;
					string testCarModel = "Test editing single feild";

					Vehicle seedCar = new Vehicle();
					seedCar.Make = seedCarMake;
					seedCar.Model = seedCarModel;
					seedCar.Engine = seedCarEngine;
					seedCar.BodyType = seedCarBodyType;
					seedCar.Wheels = seedCarWheels;
					seedCar.Doors = seedCarDoors;
					seedCar.VehicleType = (short)VehicleType.Car;

					var builder = new DbContextOptionsBuilder<VehicleRecordDBContext>();
					builder.UseInMemoryDatabase("VehicleRecordDB");

					using (VehicleRecordDBContext database = new VehicleRecordDBContext(builder.Options))
					{
						database.Add(seedCar);
						database.SaveChanges();
						seedCarId = seedCar.Id;
					}

					Car testCar = new Car();
					testCar.Model = testCarModel;
					VehicleService.EditVehicle(seedCarId, testCar);

					using (VehicleRecordDBContext database = new VehicleRecordDBContext(builder.Options))
					{
						Vehicle resultVehicle = database.Vehicles.Where(v => v.Id == seedCarId).FirstOrDefault();
						Assert.Null(resultVehicle.Make);
						Assert.Equal(testCarModel, resultVehicle.Model);
						Assert.Null(resultVehicle.Engine);
						Assert.Null(resultVehicle.BodyType);
						Assert.Null(resultVehicle.Wheels);
						Assert.Null(resultVehicle.Doors);
						Assert.Equal((short)VehicleType.Car, resultVehicle.VehicleType);
					}
				}
			}
		}
	}
}
