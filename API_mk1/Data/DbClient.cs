using API_mk1.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_mk1.Data
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Plan> _collection;

        public DbClient()
        {
            //TODO better/more secure implementation of the connection string
            var client = new MongoClient("mongodb+srv://dbUserAdm:notSecurePSW@cluster0.nro4e.mongodb.net/sample_geospatial?retryWrites=true&w=majority");
            var database = client.GetDatabase("training");
            _collection = database.GetCollection<Plan>("plans");
        }

        public IMongoCollection<Plan> GetPlanCollection() => _collection;
    }
}

