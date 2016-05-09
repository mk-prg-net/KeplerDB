using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Workflows.CreateCBSys.SelectCentralBody
{
    public class PlanetAsCentralBodySTF : KeplerBI.Workflows.CreateCBSys.SelectCentralBody.PlanetAsCentralBodySTF
    {
        public override KeplerBI.Workflows.CreateCBSys.SelectSatellite.SatellitesOfPlanet CreateSatellitesOfPlanetContext(KeplerBI.NaturalCelesticalBodies.IPlanet Planet)
        {
            return new SelectSatellite.SatellitesOfPlanetContext((NaturalCelesticalBodies.Planet)Planet);
        }
    }
}
