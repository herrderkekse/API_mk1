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
        IEnumerable<PlanModel> GetPlans();
        IEnumerable<PlanModel> GetPlansByAuthorName(string author);
        PlanModel GetPlanById(string id);
        DayModel GetDayById(string id, string day);

        //Post
        void CreatePlan(PlanModel plan);

        //Put
        void UpdatePlan(PlanModel plan);

        //Patch

        //Delete
        void DeletePlan(string id);
    }
}
