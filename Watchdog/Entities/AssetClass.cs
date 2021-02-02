using ExShift.Mapping;

namespace Watchdog.Entities
{
    public class AssetClass : IPersistable
    {
        [PrimaryKey]
        public string ShortName { get; set; }
        public string Name { get; set; }

        public AssetClass()
        {
        }
    }
}
