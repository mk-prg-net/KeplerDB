using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Workflows.CreateCBSys.SelectCentralBody
{
    public class PlanetAsCentralBodyContext : KeplerBI.Workflows.CreateCBSys.SelectCentralBody.PlanetAsCentralBodyContext
    {
        KeplerDBContext ORM = new KeplerDBContext();
        KeplerBI.DB.NaturalCelesticalBodies.Repositories.PlanetCo Repo;

        public PlanetAsCentralBodyContext()
        {
            Repo = new NaturalCelesticalBodies.Repositories.PlanetCo(ORM);
        }

        public override KeplerBI.NaturalCelesticalBodies.Repositories.PlanetsCo Planets
        {
            get { return Repo; }
        }
    }
}
