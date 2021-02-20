namespace Watchdog.Entities
{
    public class RatingRatioRule : Rule
    {
        public int RatingClass { get; set; }
        public double MaxRatio { get; set; }

        public RatingRatioRule()
        {

        }
    }
}
