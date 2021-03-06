using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace SimpleHeartbeat_Service
{
    public class Heartbeat
    {
        // what is this going to do
        // timer every sec and write to a file

        private readonly System.Timers.Timer _heartbeatTimer;

        public Heartbeat()
        {
            _heartbeatTimer = new System.Timers.Timer(1000) { AutoReset = true };
            _heartbeatTimer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new[] { DateTime.Now.ToShortDateString() };
            File.AppendAllLines(@"D:\_TEMP\Heartbeat.txt", lines);
        }

        public void Start()
        {
            _heartbeatTimer?.Start();
        }

        public void Stop()
        {
            if (_heartbeatTimer != null)
                _heartbeatTimer.Stop();
        }

    }
}
