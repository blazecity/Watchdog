using ExShift.Mapping;
using System.Collections.Generic;

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

        public override bool Equals(object obj)
        {
            return obj is AssetClass @class &&
                   ShortName == @class.ShortName &&
                   Name == @class.Name;
        }

        public override int GetHashCode()
        {
            int hashCode = 1671284716;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ShortName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
