using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace API_mk1.DTOs
{
    public class PlanReadDto
    {
        //public ObjectId Id { get; set; }  //gives the user more information (comment both out for production)
        public string Id { get; set; } //gives the user less information   
        
        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("name")]
        public string PlanName { get; set; }

        [JsonProperty("pattern")]
        public List<string> Pattern { get; set; }

        [JsonProperty("days")]
        public Dictionary<string,Dictionary<string, ExerciseReadDto>>? Days { get; set; }

    }
    public class DayReadDto
    {
        public Dictionary<string,ExerciseReadDto> Exercises { get; set; }
    }

    public class ExerciseReadDto
    {
        [JsonProperty("sets")]
        public int Sets { get; set; }

        [JsonProperty("reps")]
        public int Reps { get; set; }

        [JsonProperty("weight")]
        public float Weight { get; set; }

        [JsonProperty("unilateral")]
        public bool Unilateral { get; set; }
    }
}