using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using Watchdog.Entities;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Watchdog.Forms.Util
{
    public class UIThreadHelper
    {

        // No instances allowed
        private UIThreadHelper()
        {

        }

        public static void StartUIThread<T>() where T : Window, new()
        {
            Thread thread = new Thread(() =>
            {
                T window = new T();
                window.Show();
                window.Closed += (o, p) => window.Dispatcher.InvokeShutdown();
                Dispatcher.Run();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
