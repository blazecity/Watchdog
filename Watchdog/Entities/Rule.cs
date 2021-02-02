using ExShift.Mapping;
using System.Collections.Generic;

namespace Watchdog.Entities
{
    public class Rule : IPersistable
    {
        [PrimaryKey]
        public string Name { get; set; }
        [ForeignKey]
        [MultiValue]
        public List<Fund> FundList { get; set; }
        [ForeignKey]
        public RuleKind RuleKind { get; set; }

        public Rule()
        {
            FundList = new List<Fund>();
        }
    }
}
