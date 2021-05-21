using API_mk1.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_mk1.DTOs
    //here did definetly something change
{
    public class PlanCreateDto
    {
        [Required]
        [JsonProperty("author")]
        public string Author { get; set; }

        [Required]
        [JsonProperty("name")]
        public string PlanName { get; set; }

        [Required]
        [JsonProperty("pattern")]
        public List<string> Pattern { get; set; }

        [Required]
        [JsonProperty("days")]
        public Dictionary<string, Dictionary<string, ExerciseCreateDto>> Days { get; set; }

    }

    public class ExerciseCreateDto
    {
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} can not be null")]
        [JsonProperty("sets")]
        public int Sets { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} can not be null")]
        [JsonProperty("reps")]
        public int Reps { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Value for {0} can not be null")]
        [JsonProperty("weight")]
        public float Weight { get; set; }

        [Required]
        [JsonProperty("unilateral")]
        public bool Unilateral { get; set; }
    }
}