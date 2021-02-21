using ExShift.Mapping;
using System.Collections.Generic;

namespace Watchdog.Entities
{
    public class RatingAgency : IPersistable
    {
        [PrimaryKey]
        public string ShortName { get; set; }
        public string Name { get; set; }

        public RatingAgency() 
        { 
        }

        public override bool Equals(object obj)
        {
            return obj is RatingAgency agency &&
                   ShortName == agency.ShortName &&
                   Name == agency.Name;
        }

        public override int GetHashCode()
        {
            int hashCode = 1671284716;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ShortName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
