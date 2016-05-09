using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Workflows.CreateCBSys
{
    public class StateFactory : KeplerBI.Workflows.CreateCBSys.StateFactory
    {
        public override KeplerBI.Workflows.CreateCBSys.Start.StartSTF CreateStartSTF()
        {
            return new Start.StartSTF();
        }


        public override KeplerBI.Workflows.CreateCBSys.SelectCentralBody.MoonCentralBodySTF CreateMoonAsCentralBodySTF()
        {
            return new SelectCentralBody.MoonAsCentralBodySTF();
        }


        public override KeplerBI.Workflows.CreateCBSys.SelectCentralBody.PlanetAsCentralBodySTF CreatePlanetAsCentralBodySTF()
        {
            return new SelectCentralBody.PlanetAsCentralBodySTF();
        }


        public override KeplerBI.Workflows.CreateCBSys.SelectCentralBody.StarAsCentralBodySTF CreateStarAsCentralBodySTF()
        {
            return new SelectCentralBody.StarAsCentralBodySTF();
        }


        public override KeplerBI.Workflows.CreateCBSys.SelectSatellite.SatellitesOfMoonSTF CreateSatellitesOfMoonSTF()
        {
            return new SelectSatellite.SatellitesOfMoonSTF();
        }


        public override KeplerBI.Workflows.CreateCBSys.SelectSatellite.SatellitesOfPlanetSTF CreateSatellitesOfPlanetSTF()
        {
            return new SelectSatellite.SatellitesOfPlanetSTF();
        }


        public override KeplerBI.Workflows.CreateCBSys.SelectSatellite.SatellitesOfStarSTF CreateSatellitesOfStarSTF()
        {
            return new SelectSatellite.SatellitesOfStarSTF();
        }


    }
}
