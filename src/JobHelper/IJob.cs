using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHelper
{
    public interface IJob
    {
        void Execute(string[] args);
    }
}
