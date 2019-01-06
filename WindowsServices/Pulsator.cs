using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsServices
{
    public class Pulsator
    {
        private readonly Timer _timer;
        public Pulsator()
        {
            _timer = new Timer(1000) { AutoReset = true }; //odliczaj 1s i tak w kółko
            _timer.Elapsed += TimerElapsed;  // tworzenie eventu =>2x"TAB"
        }


        // Własny event
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(@"C:\Temp\DemoFolder\Heartbeat.txt", lines);
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

    }
}
