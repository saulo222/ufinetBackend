using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN_AGGREGATES.Base
{
    public interface IWorkUnit : IDisposable
    {
        int Save();
    }
}
