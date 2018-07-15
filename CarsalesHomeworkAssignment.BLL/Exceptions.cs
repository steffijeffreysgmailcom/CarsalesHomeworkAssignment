using System;
using System.Collections.Generic;
using System.Text;

namespace CarsalesHomeworkAssignment.BLL
{

	public class VehicleNotFoundException : Exception
	{
		public VehicleNotFoundException()
		{
		}

		public VehicleNotFoundException(string message)
			: base(message)
		{
		}

		public VehicleNotFoundException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
