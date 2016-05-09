using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Workflows.CreateCBSys.SelectSatellite
{
    public class SatellitesOfMoonContext : KeplerBI.Workflows.CreateCBSys.SelectSatellite.SatellitesOfMoonContext
    {
        KeplerDBContext ORM = new KeplerDBContext();
        SpaceShips.Repositories.SpaceShipsCo Repo;

        public SatellitesOfMoonContext(NaturalCelesticalBodies.NaturalCelesticalBody ncb) : base(ncb) 
        {
            Repo = new SpaceShips.Repositories.SpaceShipsCo(ORM);
        }

        protected override KeplerBI.Workflows.CreateCBSys.SelectSatellite.ContextCore CreateCore(KeplerBI.NaturalCelesticalBodies.INaturalCelesticalBody NCB)
        {
            return new ContextCore((NaturalCelesticalBodies.NaturalCelesticalBody)NCB);
        }

        public override mko.BI.Repositories.BoCoBase<KeplerBI.SpaceShips.ISpaceShip, string> SpaceShips
        {
            get { return Repo; }
        }
    }
}
