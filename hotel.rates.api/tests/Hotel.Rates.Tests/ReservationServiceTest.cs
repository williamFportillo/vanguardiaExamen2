using Hotel.Rates.Api.Models;
using Hotel.Rates.Core.Entities;
using Hotel.Rates.Core.Enums;
using Hotel.Rates.Core.Interfaces;
using Hotel.Rates.Core.Services;
using Hotel.Rates.Infraestructure.Data.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hotel.Rates.Tests
{
    [Fact]
    public void InvalidRatePlann_ReturnNotFound()
    {

        var reservationRepositoryMock = new Mock<IReservationRepository>();
        var RatePlanRepositoryMock = new Mock<IRatePlansRepository>();

        RatePlanRepositoryMock.Setup(n => n.GetById(It.IsAny<int>())).Returns(new RatePlan
        {
            Id = -5
        }) ;



        var result = new ReservationService(reservationRepositoryMock.Object, RatePlanRepositoryMock.Object);

        var reservation = new Reservation
        {
            AmountOfAdults = 1,
            AmountOfChildren = 0,
            RatePlanId = -5,
            ReservationStart = new DateTime(2020, 07, 01),
            ReservationEnd = new DateTime(2020, 07, 03),
            RoomId = -1
        };
        var x = result.AddReservation(reservation);


        Assert.True(x.Error == "No existe un rateplan con ese id.");
    }


    public void IntervalIsValid_ReturnOk()
    {

        var reservationRepositoryMock = new Mock<IReservationRepository>();
        var RatePlanRepositoryMock = new Mock<IRatePlansRepository>();

        RatePlanRepositoryMock.Setup(n => n.GetById(It.IsAny<int>())).Returns(new RatePlan
        {
            Id = -1
        });



        var result = new ReservationService(reservationRepositoryMock.Object, RatePlanRepositoryMock.Object);

        var reservation = new Reservation
        {
            AmountOfAdults = 1,
            AmountOfChildren = 0,
            RatePlanId = -1,
            ReservationStart = new DateTime(2020, 07, 01),
            ReservationEnd = new DateTime(2020, 07, 03),
            RoomId = -1
        };
        var x = result.AddReservation(reservation);


        Assert.True(x.Error != "No existe un rateplan con ese id." && x.Error != "No se pudo hacer la reservacion.");
    }


    public void NightyBadDateRange_ReturnError() // la fecha al reves
    {

        var reservationRepositoryMock = new Mock<IReservationRepository>();
        var RatePlanRepositoryMock = new Mock<IRatePlansRepository>();

        RatePlanRepositoryMock.Setup(n => n.GetById(It.IsAny<int>())).Returns(new RatePlan
        {
            Id = -1
        });



        var result = new ReservationService(reservationRepositoryMock.Object, RatePlanRepositoryMock.Object);

        var reservation = new Reservation
        {
            AmountOfAdults = 1,
            AmountOfChildren = 0,
            RatePlanId = -1,
            ReservationStart = new DateTime(2020, 07, 03),     
            ReservationEnd = new DateTime(2020, 07, 01),
            RoomId = -1
        };
        var x = result.AddReservation(reservation);


        Assert.True(x.Error != "No existe un rateplan con ese id." && x.Error != "No se pudo hacer la reservacion.");
    }
}
