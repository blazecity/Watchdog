using ExShift.Mapping;

namespace Watchdog.Entities
{
    public class Currency : IPersistable
    {
        [PrimaryKey]
        public string IsoCode { get; set; }
        public string Name { get; set; }

        public Currency()
        {

        }
    }
}
