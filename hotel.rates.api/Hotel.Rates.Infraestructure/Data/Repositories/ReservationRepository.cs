using Hotel.Rates.Core.Entities;
using Hotel.Rates.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Infraestructure.Data.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly InventoryContext inventoryContext;

        public ReservationRepository(InventoryContext inventoryContext)
        {
            this.inventoryContext = inventoryContext;
        }
        public double addReservation(Room room)
        {
            var result = room.Amount -= 1;
            inventoryContext.SaveChanges();
            return  result; 
        }
    }
}
