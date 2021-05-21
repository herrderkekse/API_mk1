using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace API_mk1.Models
{
    [BsonIgnoreExtraElements]
    public class Plan
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("author")]
        public string Author { get; set; }

        [BsonElement("name")]
        public string PlanName { get; set; }

        [BsonElement("pattern")]
        public List<string> Pattern { get; set; }

        //[BsonIgnore]
        [BsonElement("days")]
        public Dictionary<string, Dictionary<string, Exercise>> Days { get; set; }
    }

    public class Day
    {
        public Dictionary<string, Exercise> DayName { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Exercise   //TODO doesnt work yet (well more or less)
    {
        [BsonElement("sets")]
        public int Sets { get; set; }

        [BsonElement("reps")]
        public int Reps { get; set; }

        [BsonElement("weight")]
        public float Weight { get; set; }

        [BsonElement("unilateral")]
        public bool Unilateral { get; set; }
    }
}
