using CarShop.Models.SqlDataAccess;

namespace CarShop.Models.ModelData
{
    public class CarData
    {
		private ISqlDataAccess _db;

		public CarData(ISqlDataAccess db)
		{
			_db = db;
		}

		public Task<IEnumerable<Car>> GetAllCars() =>
			_db.LoadData<Car, dynamic>("select * from public.\"Cars\"", new { });

		public async Task<Car?> GetCar(int carId)
		{
			var result =
				await _db.LoadData<Car, dynamic>("select * from public.\"Cars\" where @carId", new { carId = carId });
			return result.FirstOrDefault();
		}
	}
}
