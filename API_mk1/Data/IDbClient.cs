using API_mk1.Models;
using MongoDB.Driver;


namespace API_mk1.Data
{
    public interface IDbClient
    {
        //Get
        IMongoCollection<Plan> GetPlanCollection();
    }
}
