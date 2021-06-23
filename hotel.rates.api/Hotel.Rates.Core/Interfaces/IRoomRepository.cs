using Hotel.Rates.Core.Entities;
using System.Collections.Generic;

namespace Hotel.Rates.Core.Interfaces
{
    public interface IRoomRepository
    {
        IReadOnlyList<Room> getRooms();
    }
}
