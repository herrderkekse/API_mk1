using API_mk1.Data;
using API_mk1.DTOs;
using API_mk1.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//This is a github testchange

namespace API_mk1.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class PlansController : Controller
    {
        private readonly IPlanRepo _repository;
        private readonly IMapper _mapper;

        public PlansController(IPlanRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //Get
        //api/Plans
        [HttpGet]
        public ActionResult<IEnumerable<PlanReadDto>> GetPlans()
        {
            var planItems = _repository.GetPlans();
            return Ok(_mapper.Map<IEnumerable<PlanReadDto>>(planItems));
        }

        //api/Plans/byAothor?author=<someUser>
        [HttpGet("byAuthor", Name = "GetPlanByAuthor")]
        public ActionResult<IEnumerable<PlanReadDto>> GetPlanByAuthorName([FromQuery] string author)
        {
            var planItems = _repository.GetPlansByAuthorName(author);

            if (planItems.Count() > 0)
            {
                return Ok(_mapper.Map<IEnumerable<PlanReadDto>>(planItems));
            }
            return NotFound();
        }

        //api/Plans/byId?id=<someId>
        [HttpGet("byId", Name = "GetPlanByID")]
        public ActionResult<PlanReadDto> GetPlanById([FromQuery] string id)
        {
            if (!Verifier.verifyId(id))
            {
                return BadRequest();
            }

            var planItem = _repository.GetPlanById(id);

            if (planItem != null)
            {
                return Ok(_mapper.Map<PlanReadDto>(planItem));
            }
            return NotFound();
        }

        //api/Plans/day/byId?id=<someId>&day=<someDay>
        [HttpGet("day/byId", Name = "GetDayByID")]
        public ActionResult<DayReadDto> GetDayById([FromQuery] string id, [FromQuery] string day)
        {
            if (!Verifier.verifyId(id))
            {
                return BadRequest();
            }

            var dayItem = _repository.GetDayById(id, day);

            if (dayItem != null)
            {
                return Ok(_mapper.Map<DayReadDto>(dayItem));
            }
            return NotFound();
        }


        //Post
        //api/Plans
        [HttpPost]
        public ActionResult<PlanReadDto> CreatePlan(PlanCreateDto planCreateDto)
        {
            PlanModel plan = _mapper.Map<PlanModel>(planCreateDto);

            //verify the user Input
            var msg = Verifier.verify(plan);
            if (msg != null)
            {
                return BadRequest(msg);
            }

            _repository.CreatePlan(plan);

            var planReadDto = _mapper.Map<PlanReadDto>(plan);

            return CreatedAtRoute(nameof(GetPlanById), new { id = planReadDto.Id }, planReadDto);
        }


        //Put
        //api/Plans?id=<someId>
        [HttpPut]
        public ActionResult UpdatePlan([FromQuery] string id, PlanUpdateDto planUpdateDto)
        {
            //verify Id
            if (!Verifier.verifyId(id))
            {
                return BadRequest();
            }

            var planFromRepo = _repository.GetPlanById(id);

            if(planFromRepo == null)
            {
                return NotFound();
            }

            var plan = _mapper.Map<PlanModel>(planUpdateDto);
            plan.Id = new ObjectId(id); //assigns the id from the URL to the plan.Id property

            //verify user input
            var msg = Verifier.verify(plan);
            if(msg != null)
            {
                return BadRequest(msg);
            }

            _repository.UpdatePlan(plan);

            return NoContent();
        }


        //Patch
        //api/Plans?id=<someId>
        [HttpPatch]
        public ActionResult UpdatePartialPlan([FromQuery] string id, JsonPatchDocument<PlanUpdateDto> patchDocument)
        {
            //verify Id
            if (!Verifier.verifyId(id))
            {
                return BadRequest();
            }

            var planFromRepo = _repository.GetPlanById(id);

            if (planFromRepo == null)
            {
                return NotFound();
            }

            var plan = _mapper.Map<PlanUpdateDto>(planFromRepo);

            patchDocument.ApplyTo(plan, ModelState);

            if (!TryValidateModel(plan))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(plan, planFromRepo);

            _repository.UpdatePlan(planFromRepo);

            return NoContent();
        }


        //Delete
        //api/Plans?id=<someId>
        [HttpDelete]
        public ActionResult DeletePlan([FromQuery] string id)
        {
            //verify id
            if (!Verifier.verifyId(id))
            {
                return BadRequest();
            }

            _repository.DeletePlan(id);

            return NoContent();
        }
    }
}
