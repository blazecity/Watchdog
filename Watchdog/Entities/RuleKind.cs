using ExShift.Mapping;
using System.Collections.Generic;

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

        public override bool Equals(object obj)
        {
            return obj is RuleKind kind &&
                   RuleCode == kind.RuleCode &&
                   Description == kind.Description;
        }

        public override int GetHashCode()
        {
            int hashCode = -455959837;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RuleCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            return hashCode;
        }
    }
}
