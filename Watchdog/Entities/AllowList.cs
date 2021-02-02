using ExShift.Mapping;
using System.Collections.Generic;

namespace Watchdog.Entities
{
    public class AllowList : Rule
    {
        [ForeignKey]
        [MultiValue]
        public List<Asset> Allowed { get; set; }

        public AllowList()
        {

        }
    }
}
