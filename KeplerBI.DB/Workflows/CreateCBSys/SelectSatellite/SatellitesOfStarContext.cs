using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Workflows.CreateCBSys.SelectSatellite
{
    public class SatellitesOfStarContext : KeplerBI.Workflows.CreateCBSys.SelectSatellite.SatellitesOfStarContext
    {
        KeplerDBContext ORM = new KeplerDBContext();
        SpaceShips.Repositories.SpaceShipsCo SpaceShipsRepo;
        NaturalCelesticalBodies.Repositories.MoonCo MoonsRepo;
        NaturalCelesticalBodies.Repositories.PlanetCo PlanetsRepo;
        NaturalCelesticalBodies.Repositories.AsteroidsCo AsteroidsRepo;
        NaturalCelesticalBodies.Repositories.CometsCo CometsRepo;

        public SatellitesOfStarContext(NaturalCelesticalBodies.NaturalCelesticalBody ncb)
            : base(ncb)
        {
            PlanetsRepo = new NaturalCelesticalBodies.Repositories.PlanetCo(ORM);
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

        public override mko.BI.Repositories.BoCoBase<KeplerBI.NaturalCelesticalBodies.IAsteroid, string> Asteroids
        {
            get { return AsteroidsRepo; }
        }

        public override mko.BI.Repositories.BoCoBase<KeplerBI.NaturalCelesticalBodies.IComet, string> Comets
        {
            get { return CometsRepo; }
        }

        public override KeplerBI.NaturalCelesticalBodies.Repositories.PlanetsCo Planets
        {
            get { return PlanetsRepo; }
        }
    }
}
