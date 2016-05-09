using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Workflows.CreateCBSys.SelectCentralBody
{
    public class MoonAsCentralBodySTF : KeplerBI.Workflows.CreateCBSys.SelectCentralBody.MoonCentralBodySTF
    {
        public override KeplerBI.Workflows.CreateCBSys.SelectSatellite.SatellitesOfMoonContext CreateSatellitesOfMoonContext(KeplerBI.NaturalCelesticalBodies.IMoon Moon)
        {
            return new SelectSatellite.SatellitesOfMoonContext((NaturalCelesticalBodies.NaturalCelesticalBody)Moon);
        }
    }
}
