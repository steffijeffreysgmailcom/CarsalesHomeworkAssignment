using System;
using Xunit;

namespace CarsalesHomeworkAssignement.Tests
{
	public class Given_The_User_Is_Creating_A_Car
	{

		public class And_The_User_Fills_In_All_Fields
		{
			[Fact]
			public void It_Saves_A_New_Car_With_All_The_Feilds()
			{
				throw new NotImplementedException();
			}
		}

		public class And_The_User_Fills_In_None_Of_The_Fields
		{
			[Fact]
			public void It_Returns_A_No_Fields_Provided_Exception()
			{
				throw new NotImplementedException();
			}
		}

		public class And_The_User_Fills_In_One_Field
		{
			[Fact]
			public void It_Saves_A_New_Car_With_All_The_Feilds()
			{
				throw new NotImplementedException();
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
				throw new NotImplementedException();
			}
		}


		public class And_There_Is_One_Car_In_The_System
		{
			[Fact]
			public void It_Returns_That_One_Car()
			{
				throw new NotImplementedException();
			}
		}

		public class And_There_Are_Many_Cars_In_The_System
		{
			[Fact]
			public void It_Returns_All_The_Cars_In_The_System()
			{
				throw new NotImplementedException();
			}
		}

	}

	public class Given_The_User_Is_Retrieving_A_Single_Car
	{
		public class Add_The_Car_Does_Not_Exist
		{
			public void It_Throws_A_Vehicle_Not_Found_Exception()
			{
				throw new NotImplementedException();
			}
		}

		public class Add_The_Car_Does_Exist
		{
			public void It_Returns_The_Car()
			{
				throw new NotImplementedException();
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
				throw new NotImplementedException();
			}
		}

		public class And_The_Car_Does_Exist
		{
			public class And_The_User_Fills_In_All_Fields
			{
				[Fact]
				public void It_Changes_All_The_Fields_On_That_Car()
				{
					throw new NotImplementedException();
				}
			}

			public class And_The_User_Fills_In_None_Of_The_Fields
			{
				[Fact]
				public void It_Makes_No_Change_To_The_Car()
				{
					throw new NotImplementedException();
				}
			}

			public class And_The_User_Fills_In_One_Field
			{
				[Fact]
				public void It_Changes_That_Signle_Feilds()
				{
					throw new NotImplementedException();
				}
			}
		}
	}
}
