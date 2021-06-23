using Hotel.Rates.Core.Entities;
using Hotel.Rates.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.Rates.Infraestructure.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly InventoryContext inventoryContext;

        public RoomRepository(InventoryContext inventoryContext)
        {
            this.inventoryContext = inventoryContext;
        }
        public IReadOnlyList<Room> getRooms()
        {
            return inventoryContext.Rooms.ToList();
        }
    }
}
