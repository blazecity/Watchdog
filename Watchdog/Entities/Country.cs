using ExShift.Mapping;

namespace Watchdog.Entities
{
    public class Country : IPersistable
    {
        [PrimaryKey]
        public string IsoCode { get; set; }
        public string Name { get; set; }

        public Country()
        {

        }
    }
}
