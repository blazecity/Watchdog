using ExShift.Mapping;

namespace Watchdog.Entities
{
    public class Country : IPersistable
    {
        public string Name { get; set; }
        [PrimaryKey]
        public string IsoCode { get; set; }

        public Country()
        {

        }
    }
}
