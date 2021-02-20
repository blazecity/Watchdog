using ExShift.Mapping;
using System.Collections.Generic;

namespace Watchdog.Entities
{
    public class DurationRule : Rule
    {
        [MultiValue]
        [ForeignKey]
        public List<DurationRuleEntry> DurationRuleEntries { get; set; }
    }
}
