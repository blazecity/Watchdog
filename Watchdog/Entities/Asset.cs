using ExShift.Mapping;
using System.Collections.Generic;

namespace Watchdog.Entities
{
    public class Asset : IPersistable
    {
        [PrimaryKey]
        public int AssetId { get; set; }
        public string Name { get; set; }

        public Asset()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is Asset asset &&
                   AssetId == asset.AssetId &&
                   Name == asset.Name;
        }

        public override int GetHashCode()
        {
            int hashCode = 83193292;
            hashCode = hashCode * -1521134295 + AssetId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
