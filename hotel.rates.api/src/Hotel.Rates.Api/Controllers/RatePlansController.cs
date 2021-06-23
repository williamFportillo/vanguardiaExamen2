using Hotel.Rates.Core.Interfaces;
using Hotel.Rates.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hotel.Rates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatePlansController : ControllerBase
    {
        private readonly IRatePlansService ratePlansService;

        public RatePlansController(IRatePlansService ratePlansService)
        {
            this.ratePlansService = ratePlansService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = ratePlansService.GetRatesPlans();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ratePlan = ratePlansService.GeyById(id);

            return Ok(new
            {
                RatePlanId = ratePlan.Result.Id,
                RatePlanName = ratePlan.Result.Name,
                ratePlan.Result.RatePlanType,
                ratePlan.Result.Price,
                Seasons = ratePlan.Result.Seasons.Select(s => new
                {
                    s.Id,
                    s.StartDate,
                    s.EndDate
                }),
                Rooms = ratePlan.Result.RatePlanRooms.Select(r => new
                {
                    r.Room.Name,
                    r.Room.MaxAdults,
                    r.Room.MaxChildren,
                    r.Room.Amount
                })
            });
        }
    }
}
