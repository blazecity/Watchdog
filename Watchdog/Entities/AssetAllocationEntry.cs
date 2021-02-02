using ExShift.Mapping;

namespace Watchdog.Entities
{
    public class AssetAllocationEntry : IPersistable
    {
        [PrimaryKey]
        public int Id { get; set; }
        [ForeignKey]
        public AssetClass AssetClass { get; set; }
        [ForeignKey]
        public Currency Currency { get; set; }
        [ForeignKey]
        public Fund Fund { get; set; }
        public double StrategicMinValue { get; set; }
        public double StrategicOptValue { get; set; }
        public double StrategicMaxValue { get; set; }

        public AssetAllocationEntry() 
        { 
        }
    }
}
