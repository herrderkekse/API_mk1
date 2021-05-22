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
            CreateMap<PlanModel, PlanReadDto>();
            CreateMap<ExerciseModel, ExerciseReadDto>();
            CreateMap<DayModel, DayReadDto>();

            CreateMap<PlanCreateDto, PlanModel>();
            CreateMap<ExerciseCreateDto, ExerciseModel>();

            CreateMap<PlanUpdateDto, PlanModel>();
            CreateMap<ExerciseUpdateDto, ExerciseModel>();

            CreateMap<PlanModel, PlanUpdateDto>();
            CreateMap<ExerciseModel, ExerciseUpdateDto>();
        }

    }
}
