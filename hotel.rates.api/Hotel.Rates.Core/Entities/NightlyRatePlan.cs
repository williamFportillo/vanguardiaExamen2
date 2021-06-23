namespace Hotel.Rates.Core.Entities
{
    public class NightlyRatePlan : RatePlan
    {
        public NightlyRatePlan()
        {
            RatePlanType = (int)Enums.RatePlanType.Nightly;
        }
    }
}
