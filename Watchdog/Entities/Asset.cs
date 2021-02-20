using ExShift.Mapping;

namespace Watchdog.Entities
{
    public class Asset : IPersistable
    {
        [PrimaryKey]
        public int AssetId { get; set; }
        public string Name { get; set; }

        public Asset()
        {

        }
    }
}
