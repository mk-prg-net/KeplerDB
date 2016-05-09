using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Workflows.CreateCBSys.SelectSatellite
{
    public abstract class ContextCore
    {
        protected abstract ICBSysDraft CreateNewCBSys();

        public ContextCore(ICelestialBodyBase cb)
        {
            _CBSys = CreateNewCBSys();
            _CBSys.SetCentralBody(cb);
        }

        ICBSysDraft _CBSys;
        public ICBSysDraft CBSys {
            get
            {
                return _CBSys;
            }
        }
    }
}
