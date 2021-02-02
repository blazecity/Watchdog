using ExShift.Mapping;

namespace Watchdog.Entities
{
    public class Fund : IPersistable
    {
        public string Name { get; set; }
        [PrimaryKey]
        public string Isin { get; set; }
        public string CustodyAccountNumber { get; set; }
        [ForeignKey]
        public Currency Currency { get; set; }

        public Fund() 
        {
        }
    }
}
