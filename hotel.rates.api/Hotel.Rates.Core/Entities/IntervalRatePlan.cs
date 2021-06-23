namespace Hotel.Rates.Core.Entities
{
    public class IntervalRatePlan : RatePlan
    {
        public IntervalRatePlan()
        {
            RatePlanType = (int)Enums.RatePlanType.Interval;
        }

        public int IntervalLength { get; set; }
    }
}
