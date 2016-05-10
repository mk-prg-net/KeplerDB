using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Workflows.CreateCBSys.SelectSatellite
{
    public class SatellitesOfPlanetContext : KeplerBI.Workflows.CreateCBSys.SelectSatellite.SatellitesOfPlanetContext
    {

        KeplerDBContext ORM = new KeplerDBContext();
        SpaceShips.Repositories.SpaceShipsCo SpaceShipsRepo;
        NaturalCelesticalBodies.Repositories.MoonCo MoonsRepo;

        public SatellitesOfPlanetContext(NaturalCelesticalBodies.NaturalCelesticalBody ncb)
            : base(ncb)
        {
            SpaceShipsRepo = new SpaceShips.Repositories.SpaceShipsCo(ORM);
            MoonsRepo = new NaturalCelesticalBodies.Repositories.MoonCo(ORM);
        }


        protected override KeplerBI.Workflows.CreateCBSys.SelectSatellite.ContextCore CreateCore(KeplerBI.NaturalCelesticalBodies.INaturalCelesticalBody NCB)
        {
            return new ContextCore((NaturalCelesticalBodies.NaturalCelesticalBody)NCB);
        }

        public override mko.BI.Repositories.BoCoBase<KeplerBI.SpaceShips.ISpaceShip, string> SpaceShips
        {
            get { return SpaceShipsRepo; }
        }

        public override KeplerBI.NaturalCelesticalBodies.Repositories.IMoonsCo Moons
        {
            get { return MoonsRepo; }
        }
    }
}
