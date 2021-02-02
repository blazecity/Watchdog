using ExShift.Mapping;

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
    }
}
