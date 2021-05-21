using API_mk1.DTOs;
using API_mk1.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_mk1.Profiles
{
    public class PlansProfile : Profile
    {
        public PlansProfile()
        {
            CreateMap<Plan, PlanReadDto>();
            CreateMap<Exercise, ExerciseReadDto>();

            CreateMap<PlanCreateDto, Plan>();
            CreateMap<ExerciseCreateDto, Exercise>();

            CreateMap<PlanUpdateDto, Plan>();
            CreateMap<ExerciseUpdateDto, Exercise>();

            CreateMap<Plan, PlanUpdateDto>();
            CreateMap<Exercise, ExerciseUpdateDto>();
        }

    }
}
