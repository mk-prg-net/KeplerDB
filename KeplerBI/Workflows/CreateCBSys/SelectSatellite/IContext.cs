using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Workflows.CreateCBSys.SelectSatellite
{
    public interface IContext
    {
        ContextCore Core { get; }
    }
}
