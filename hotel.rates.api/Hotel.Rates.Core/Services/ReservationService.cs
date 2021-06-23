using Hotel.Rates.Core.Entities;
using Hotel.Rates.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository reservationRepository;
        private readonly IRatePlansRepository ratePlansRepository;

        public ReservationService(IReservationRepository reservationRepository, IRatePlansRepository ratePlansRepository)
        {
            this.reservationRepository = reservationRepository;
            this.ratePlansRepository = ratePlansRepository;
        }
        public ServiceResult<double> AddReservation(Reservation reservation)
        {
            var ratePlan = ratePlansRepository.GetById(reservation.RatePlanId);
            if (ratePlan == null)
            {
                return ServiceResult<double>.ErrorResult("No existe un rateplan con ese id.");
            }
            var canReserve = ratePlan.Seasons
                .Any(s => s.StartDate <= reservation.ReservationStart && s.EndDate >= reservation.ReservationEnd);
            var room = ratePlan.RatePlanRooms
                .First(r => r.RoomId == reservation.RoomId && r.RatePlanId == reservation.RatePlanId);
            var isRoomAvailable = room.Room.Amount > 0 &&
                room.Room.MaxAdults >= reservation.AmountOfAdults &&
                room.Room.MaxChildren >= reservation.AmountOfChildren;

            if (canReserve && isRoomAvailable)
            {
                if (ratePlan.RatePlanType == 1) // esto es el caso que sea IntervalType
                {
                    reservationRepository.addReservation(room.Room);
                    var days = (reservation.ReservationEnd - reservation.ReservationStart).TotalDays;
                    if (days >= 2)
                    {
                        return ServiceResult<double>.SuccessResult(30 / days);
                    }

                }
                if (ratePlan.RatePlanType == 0)
                {
                    reservationRepository.addReservation(room.Room);
                    var days = (reservation.ReservationEnd - reservation.ReservationStart).TotalDays;
                    return ServiceResult<double>.SuccessResult(days * ratePlan.Price);
                }
                
                
            }

            return ServiceResult<double>.ErrorResult("No se pudo hacer la reservacion.");
        }
    }
}
