using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Workflows.CreateCBSys.SelectSatellite
{
    public class SatellitesOfMoonSTF : KeplerBI.Workflows.CreateCBSys.SelectSatellite.SatellitesOfMoonSTF
    {
        protected override KeplerBI.Workflows.CreateCBSys.Save.SaveNewCBSysContext CreateSaveNewCBsysContext(ICelesticalBodySystem CBSys)
        {
            return new SaveNewCBSysContext(CBSys);
        }
    }
}
