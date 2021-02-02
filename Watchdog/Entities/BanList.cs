using ExShift.Mapping;
using System.Collections.Generic;

namespace Watchdog.Entities
{
    public class BanList<T> : Rule where T : IPersistable, new()
    {
        [ForeignKey]
        [MultiValue]
        public List<T> Banned { get; set; }

        public BanList()
        {

        }
    }
}
