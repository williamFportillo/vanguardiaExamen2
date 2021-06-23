using Hotel.Rates.Api.Models;
using Hotel.Rates.Core.Entities;
using Hotel.Rates.Core.Enums;
using Hotel.Rates.Core.Interfaces;
using Hotel.Rates.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hotel.Rates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ReservationModel reservationModel)
        {
            var entity = new Reservation
            {
                AmountOfAdults = reservationModel.AmountOfAdults,
                AmountOfChildren = reservationModel.AmountOfChildren,
                 RatePlanId = reservationModel.RatePlanId,
                 ReservationEnd = reservationModel.ReservationEnd,
                 ReservationStart = reservationModel.ReservationStart,
                 RoomId = reservationModel.RoomId
            };
            var reservation = reservationService.AddReservation(entity);
            if (reservation.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(reservation.Error);
            }
            return Ok(reservation);
        }
    }
}
