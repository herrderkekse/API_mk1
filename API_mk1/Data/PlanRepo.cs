using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MongoDB.Driver;
using MongoDB.Bson;
using API_mk1.Models;
using API_mk1.DTOs;

namespace API_mk1.Data
{
    public class PlanRepo : IPlanRepo
    {
        private readonly IMongoCollection<Plan> _collection;

        public PlanRepo(IDbClient client)
        {
            _collection = client.GetPlanCollection();
        }
        

        //Get
        public IEnumerable<Plan> GetPlans()
        {
            //TODO add exeption handling in case the mongodb atlas server isnt responding
            var res = _collection.Find(plan => true).ToList();  //finds all plans for which true is ture, so it finds all
            return res;
        }


        public IEnumerable<Plan> GetPlansByAuthorName(string author)
        {
            var res = _collection.Find(plan => plan.Author == author).ToList();
            return res;

        }

        public Plan GetPlanById(string id)
        {  
            var obId = new ObjectId(id);
            var res = _collection.Find(plan => plan.Id == obId).ToList();
            //var res = _collection.Find(plan => plan.Id == id).ToList();
            try
            {
                return res[0];
            }
            catch
            {
                return null;
            }
        }

        //Post
        public void CreatePlan(Plan plan)
        {
            _collection.InsertOne(plan);
        }

        //Put
        public void UpdatePlan(Plan plan)
        {

            _collection.ReplaceOne(p => p.Id == plan.Id, plan);

        }

        //Delete
        public void DeletePlan(string id)
        {
            var obId = new ObjectId(id);
            _collection.DeleteOne(p => p.Id == obId);
        }
    }
}
