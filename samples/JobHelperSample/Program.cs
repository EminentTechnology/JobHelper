using JobHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobHelperSample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //To run in GUI - pass /Debug
            //Need help? - pass /Help
            JobRunner.Init(args, GetSwitches());
        }

        public static Dictionary<string, JobSwitch> GetSwitches()
        {
            Dictionary<string, JobSwitch> switches = new Dictionary<string, JobSwitch>();

            //this means passing no arguments will run MyCustomDailyJob
            JobSwitch defaultSwitch = new JobSwitch(String.Empty, "Custom Daily Job", new MyCustomDailyJob());
            switches.Add(defaultSwitch.Switch, defaultSwitch);

            //this means passing argument cleanup will run MyCustomUtilityJob
            JobSwitch anotherSwitch = new JobSwitch("cleanup", "Custom Utility Job - eg Cleanup", new MyCustomUtilityJob());
            switches.Add(anotherSwitch.Switch, anotherSwitch);

            return switches;

        }
    }
}
