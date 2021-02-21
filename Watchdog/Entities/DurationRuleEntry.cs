using ExShift.Mapping;
using System.Collections.Generic;

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

        public override bool Equals(object obj)
        {
            return obj is DurationRuleEntry entry &&
                   Id == entry.Id &&
                   EqualityComparer<Currency>.Default.Equals(Currency, entry.Currency) &&
                   TargetValue == entry.TargetValue &&
                   MaxDelta == entry.MaxDelta;
        }

        public override int GetHashCode()
        {
            int hashCode = -1897361724;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<Currency>.Default.GetHashCode(Currency);
            hashCode = hashCode * -1521134295 + TargetValue.GetHashCode();
            hashCode = hashCode * -1521134295 + MaxDelta.GetHashCode();
            return hashCode;
        }
    }
}
