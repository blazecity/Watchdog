using ExShift.Mapping;

namespace Watchdog.Entities
{
    public class RuleKind : IPersistable
    {
        [PrimaryKey]
        public string RuleCode { get; set; }
        public string Description { get; set; }

        public RuleKind()
        {

        }
    }
}
