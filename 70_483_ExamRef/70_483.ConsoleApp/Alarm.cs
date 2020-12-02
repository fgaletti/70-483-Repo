using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _70_483.ConsoleApp
{
    // INFO 
    public class AlarmEventArgs : EventArgs
    {
        public string Location { get; set; }
        public AlarmEventArgs(string location)
        {
            Location = location;
        }
    }


    public class Alarm
    {
        // event = secure

        // delegate
        // 1 . simple  public Action OnAlarmRaised { get; set; }
        // 2 . eventHandle : public event EventHandler OnAlarmRaised = delegate { };
        // Delegate for the alarm event
        public event EventHandler<AlarmEventArgs> OnAlarmRaised = delegate { };




        // called toi raise an alart
        public void RaiseAlarm(string location)

        {
            // only raise y someone s subscribed
            if (OnAlarmRaised != null)
            {
                // 2. 
                // 2.  OnAlarmRaised(this, EventArgs.Empty ); 
                // 3 pass EventArgs
                OnAlarmRaised(this, new AlarmEventArgs(location));

            }
        }
    }
}
