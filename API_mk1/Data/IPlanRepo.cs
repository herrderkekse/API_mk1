using API_mk1.DTOs;
using API_mk1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_mk1.Data
{
    public interface IPlanRepo
    {
        //Get
        IEnumerable<Plan> GetPlans();
        IEnumerable<Plan> GetPlansByAuthorName(string author);
        Plan GetPlanById(string id);

        //Post
        void CreatePlan(Plan plan);

        //Put
        void UpdatePlan(Plan plan);

        //Patch

        //Delete
        void DeletePlan(string id);
    }
}
