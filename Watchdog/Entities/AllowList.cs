using ExShift.Mapping;
using System.Collections.Generic;

namespace Watchdog.Entities
{
    public class AllowList<T> : Rule
    {
        [ForeignKey]
        [MultiValue]
        public List<T> Allowed { get; set; }

        public AllowList()
        {

        }
    }
}
