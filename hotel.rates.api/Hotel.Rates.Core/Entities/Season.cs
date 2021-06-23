using System;

namespace Hotel.Rates.Core.Entities
{
    public class Season
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public RatePlan RatePlan { get; set; }

        public int RatePlanId { get; set; }
    }
}
