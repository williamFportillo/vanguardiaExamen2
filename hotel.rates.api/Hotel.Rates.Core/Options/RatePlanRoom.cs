﻿namespace Hotel.Rates.Core.Entities
{
    public class RatePlanRoom
    {
        public int RatePlanId { get; set; }

        public RatePlan Rateplan { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }
    }
}
