using JobHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHelperSample
{
    class MyCustomUtilityJob : IJob
    {
        public void Execute(string[] args)
        {
            try
            {
                //do some work here

                JobRunner.LogInfo("Started my custom utility - cleanup");


                JobRunner.LogDebug("Some debug level comment - eg number of files deleted");


                JobRunner.LogInfo("Completed custom utility - cleanup");
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
