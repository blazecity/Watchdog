using ExShift.Mapping;
using System.Collections.Generic;

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

        public override bool Equals(object obj)
        {
            return obj is Rating rating &&
                   Id == rating.Id &&
                   RatingCode == rating.RatingCode &&
                   RatingNumericValue == rating.RatingNumericValue &&
                   EqualityComparer<RatingAgency>.Default.Equals(Agency, rating.Agency);
        }

        public override int GetHashCode()
        {
            int hashCode = 139755935;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RatingCode);
            hashCode = hashCode * -1521134295 + RatingNumericValue.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<RatingAgency>.Default.GetHashCode(Agency);
            return hashCode;
        }
    }
}
