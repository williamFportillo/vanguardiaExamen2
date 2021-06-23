using Hotel.Rates.Core.Entities;
using Hotel.Rates.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Infraestructure.Data.Repositories
{
    public class RatePlansRepository : IRatePlansRepository
    {
        private readonly InventoryContext inventoryContext;

        public RatePlansRepository(InventoryContext inventoryContext)
        {
            this.inventoryContext = inventoryContext;
        }
        public RatePlan GetById(int id)
        {
            return  inventoryContext.RatePlans
                .Include(r => r.Seasons)
                .Include(r => r.RatePlanRooms)
                .ThenInclude(r => r.Room)
                .FirstOrDefault(x => x.Id == id);
        }

        public IReadOnlyList<RatePlan> GetRatesPlan()
        {
            return (IReadOnlyList<RatePlan>)inventoryContext.RatePlans.Include(r => r.Seasons).Include(r => r.RatePlanRooms).ThenInclude(r => r.Room)
                .Select(x => new
                {
                    RatePlanId = x.Id,
                    RatePlanName = x.Name,
                    x.RatePlanType,
                    x.Price,
                    Seasons = x.Seasons.Select(s => new
                    {
                        s.Id,
                        s.StartDate,
                        s.EndDate
                    }),
                    Rooms = x.RatePlanRooms.Select(r => new
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
