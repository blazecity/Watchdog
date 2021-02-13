using ExShift.Mapping;
using System.Collections.Generic;

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

        public override bool Equals(object obj)
        {
            return obj is Currency currency &&
                   IsoCode == currency.IsoCode &&
                   Name == currency.Name;
        }

        public override int GetHashCode()
        {
            int hashCode = -299326063;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(IsoCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
