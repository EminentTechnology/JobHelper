using JobHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHelperSample
{
    public class MyCustomDailyJob : IJob
    {
        public void Execute(string[] args)
        {
            try
            {
                //do some work here

                JobRunner.LogInfo("Started my custom job");


                JobRunner.LogDebug("Some debug level comment");


                JobRunner.LogInfo("Completed my custom job");
            }
            catch (Exception ex)
            {
                bool rethrowException = false;

                JobRunner.LogDebug("oops something went wrong - log exception");
                JobRunner.LogException(ex, rethrowException);
            }
        }
    }
}
