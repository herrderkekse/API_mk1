using API_mk1.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_mk1
{
    public static class Verifier
    {
        public static bool verifyId(string id)
        {
            //trys to cast the id as an ObjectId. If it doesn't work the user used an invalid id
            try
            {
                new ObjectId(id);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static string verify(PlanModel plan)
        {
            //validate the PlanCreateDto by checking if all attributes needed exist
            //return null if it is valid, else return an error message

            //validation of the data
            foreach (string day in plan.Pattern)
            {
                if (!plan.Days.ContainsKey(day))
                {

                    var msgJson = "{\n\"errors\":{\n\"" + day + "\":[\n\"The " + day + " field is required.\n\"]\n},\"type\":\"https://tools.ietf.org/html/rfc7231#section-6.5.1\",\n\"title\":\"One or more validation errors occurred.\",\n\"status\":400,\n\"traceId\":\"|9b5ae080-4bf362489ba1c24b.\n\"}";
                    //var msgJson = "{'errors':{'PlanName':['The " + day + " field is required.']},'type':'https://tools.ietf.org/html/rfc7231#section-6.5.1\\','title':'One or more validation errors occurred.','status':400,'traceId':'|9b5ae080-4bf362489ba1c24b.'}";
                    //var msgJson = "{'errors':{'PlanName':['field is required.']},'title':'One or more validation errors occurred.','status':400,'traceId':'|9b5ae080-4bf362489ba1c24b.'}";
                    //var msgJson = "{ 'foo' : 'bar' }";
                    //var msgJson = msg.ToJson<string>();
                    BsonDocument msgBson = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(msgJson);
                    return msgJson; //TODO vernünftigen Error
                }

            }
            foreach(var day in plan.Days.Keys)
            {

            }
            //TODO check if the user passed exercises in for every day specified in the pattern (and not more) and if the exercises have all the requiered atributes

            return null;
        }
    }
}
