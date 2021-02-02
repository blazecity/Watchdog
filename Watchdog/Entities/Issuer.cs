using ExShift.Mapping;
using System.Collections.Generic;

namespace Watchdog.Entities
{
    public class Issuer : IPersistable
    {
        [PrimaryKey]
        public int Id { get; }
        public string Name { get; }
        public string Domicile { get; }
        [ForeignKey]
        [MultiValue]
        public List<Rating> Ratings { get; }

        public Issuer()
        {
            Ratings = new List<Rating>();
        }
    }
}
