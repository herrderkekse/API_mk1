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
        private readonly IMongoCollection<PlanModel> _collection;

        public PlanRepo(IDbClient client)
        {
            _collection = client.GetPlanCollection();
        }
        

        //Get
        public IEnumerable<PlanModel> GetPlans()
        {
            //TODO add exeption handling in case the mongodb atlas server isnt responding
            var res = _collection.Find(plan => true).ToList();  //finds all plans for which true is ture, so it finds all
            return res;
        }


        public IEnumerable<PlanModel> GetPlansByAuthorName(string author)
        {
            var res = _collection.Find(plan => plan.Author == author).ToList();
            return res;

        }

        public PlanModel GetPlanById(string id)
        {  
            var obId = new ObjectId(id);
            var res = _collection.Find(plan => plan.Id == obId).ToList();
            try
            {
                return res[0];
            }
            catch
            {
                return null;
            }
        }

        public DayModel GetDayById(string id, string day)
        {

            var obId = new ObjectId(id);
            var res = _collection.Find(plan => plan.Id == obId).ToList();


            if (!res[0].Days.TryGetValue(day, out Dictionary<string, ExerciseModel> returnedDay))
            {
                return null;
            }

            return new DayModel()
            {
                Exercises = returnedDay
            };
        }


        //Post
        public void CreatePlan(PlanModel plan)
        {
            _collection.InsertOne(plan);
        }

        //Put
        public void UpdatePlan(PlanModel plan)
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
