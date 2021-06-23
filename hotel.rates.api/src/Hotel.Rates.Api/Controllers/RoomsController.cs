using Hotel.Rates.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Rates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService roomService;

        public RoomsController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(roomService.GetRooms());
        }
    }
}
