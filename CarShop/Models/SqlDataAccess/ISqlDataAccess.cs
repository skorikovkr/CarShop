namespace CarShop.Models.SqlDataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string sqlCommand, U parameters, string connectingStringId = "Default");
        Task SaveData<T>(string sqlCommand, T parameters, string connectingStringId = "Default");
    }
}