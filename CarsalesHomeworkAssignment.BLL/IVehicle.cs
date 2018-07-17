namespace CarsalesHomeworkAssignment.BLL
{
    public interface IVehicle
    {
		int Id { get; set; }
		string Make { get; set; }
		string Model { get; set; }

		bool AllAttributesNull();
	}
}
