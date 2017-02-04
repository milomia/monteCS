using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    using System;

        public class ProgressBar
        {
            int percent;
            public ProgressBar(int pct) { this.percent = pct; }

            // The event we publish
            public event EventHandler<ProgressChangedEventArgs> ProgressChanged;

            // The method which fires the Event
            public int Progress
            {
                get { return percent; }
                set
                {
                    if (percent == value) return;
                    OnProgressChanged(new ProgressChangedEventArgs(percent, value));
                    percent = value;
                }
            }

            protected virtual void OnProgressChanged(ProgressChangedEventArgs e)
            {
                if (ProgressChanged != null) ProgressChanged(this, e);
            }
        }

        public class ProgressChangedEventArgs : System.EventArgs
        {
            public readonly int LastPercent;
            public readonly int NewPercent;

            public ProgressChangedEventArgs(int lastPct, int newPct)
            {
                LastPercent = lastPct;
                NewPercent = newPct;
            }
        }

        class TestEvent
        {
            static void Main(string[] args)
            {
                ProgressBar bar = new ProgressBar(10);
                bar.Progress = 30;

                // register with the ProgressChanged event
                bar.ProgressChanged += bar_ProgressChanged;

                // value doesn't change, no event
                bar.Progress = 30;

                // value changes, fires event
                bar.Progress = 60;
            }

            static void bar_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                Console.WriteLine("bar_ProgressChanged() event");
                Console.WriteLine("Progressed from {0} to {1}", e.LastPercent, e.NewPercent);
            }
        }
    }

