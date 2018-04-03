using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHelper
{
    public class JobSwitch
    {
        public string Description
        {
            get;
            set;
        }

        public IJob Job
        {
            get;
            set;
        }

        public string Switch
        {
            get;
            set;
        }

        public JobSwitch()
        {
        }

        public JobSwitch(string pSwitch)
        {
            this.Switch = pSwitch;
        }

        public JobSwitch(string pSwitch, IJob pJob)
        {
            this.Switch = pSwitch;
            this.Job = pJob;
        }

        public JobSwitch(string pSwitch, string pDescription, IJob pJob)
        {
            this.Switch = pSwitch;
            this.Description = pDescription;
            this.Job = pJob;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Switch, this.Description);
        }
    }
}
