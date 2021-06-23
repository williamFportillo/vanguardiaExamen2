using Hotel.Rates.Core.Entities;
using Hotel.Rates.Core.Interfaces;
using System.Collections.Generic;

namespace Hotel.Rates.Core.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }
        public ServiceResult<IReadOnlyList<Room>> GetRooms()
        {
            var rooms = roomRepository.getRooms();
            return ServiceResult<IReadOnlyList<Room>>.SuccessResult(rooms);
        }
    }
}
