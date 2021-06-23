﻿namespace Hotel.Rates.Data
{
    public class IntervalRatePlan : RatePlan
    {
        public IntervalRatePlan()
        {
            RatePlanType = (int)Data.RatePlanType.Interval;
        }

        public int IntervalLength { get; set; }
    }
}
