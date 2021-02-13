using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Watchdog.Forms.Util
{
    public class AllocationTotal : IAllocation, INotifyPropertyChanged
    {
        private double strategicMinValue;
        private double strategicOptValue;
        private double strategicMaxValue;

        public double StrategicMinValue 
        {
            get
            {
                return strategicMinValue;
            }
            set 
            {
                strategicMinValue = value;
                NotifyPropertyChanged();    
            } 
        }

        public double StrategicOptValue
        {
            get
            {
                return strategicOptValue;
            }
            set
            {
                if (value != strategicOptValue)
                {
                    strategicOptValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public double StrategicMaxValue
        {
            get
            {
                return strategicMaxValue;
            }
            set
            {
                if (value != strategicMaxValue)
                {
                    strategicMaxValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
