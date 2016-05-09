using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Workflows.CreateCBSys.SelectCentralBody
{
    public class StarAsCentralBodySTF : KeplerBI.Workflows.CreateCBSys.SelectCentralBody.StarAsCentralBodySTF
    {
        public override KeplerBI.Workflows.CreateCBSys.SelectSatellite.SatellitesOfStar CreateSatellitesOfStarContext(KeplerBI.NaturalCelesticalBodies.IStar Star)
        {
            return new SelectSatellite.SatellitesOfStarContext((NaturalCelesticalBodies.Star)Star);
        }
    }
}
