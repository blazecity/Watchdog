using ExShift.Mapping;

namespace Watchdog.Entities
{
    public class Rating : IPersistable
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string RatingCode { get; set; }
        // Rating class according to concordance table of federal authorities
        public double RatingNumericValue { get; set; }
        [ForeignKey]
        public RatingAgency Agency { get; set; }

        public Rating()
        {
            
        }
    }
}
