using ExShift.Mapping;

namespace Watchdog.Entities
{
    public class DurationRuleEntry : IPersistable
    {
        [PrimaryKey]
        public string Id { get; set; }
        [ForeignKey]
        public Currency Currency { get; set; }
        public double TargetValue { get; set; }
        public double MaxDelta { get; set; }
    }
}
