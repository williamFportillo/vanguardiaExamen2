namespace Hotel.Rates.Data
{
    public class NightlyRatePlan : RatePlan
    {
        public NightlyRatePlan()
        {
            RatePlanType = (int)Data.RatePlanType.Nightly;
        }
    }
}
