using System.Collections.Generic;

namespace Hotel.Rates.Core.Entities
{
    public class Room
    {
        public Room()
        {
            RatePlanRooms = new List<RatePlanRoom>();
        }
        public int Id { get; set; }

        public int MaxAdults { get; set; }

        public int MaxChildren { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public ICollection<RatePlanRoom> RatePlanRooms { get; set; }
    }
}
