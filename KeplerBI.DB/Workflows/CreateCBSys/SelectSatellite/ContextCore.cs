using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Workflows.CreateCBSys.SelectSatellite
{
    public class ContextCore : KeplerBI.Workflows.CreateCBSys.SelectSatellite.ContextCore
    {        
        public ContextCore(NaturalCelesticalBodies.NaturalCelesticalBody ncb) : base(ncb) { }

        protected override KeplerBI.Workflows.CreateCBSys.ICBSysDraft CreateNewCBSys()
        {
            return new CBSysDraft();
        }
    }
}
