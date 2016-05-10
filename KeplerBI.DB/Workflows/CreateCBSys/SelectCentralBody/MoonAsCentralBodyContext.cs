using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Workflows.CreateCBSys.SelectCentralBody
{
    public class MoonAsCentralBodyContext : KeplerBI.Workflows.CreateCBSys.SelectCentralBody.MoonAsCentralBodyContext
    {
        KeplerDBContext ORM;
        KeplerBI.DB.NaturalCelesticalBodies.Repositories.MoonCo Repo;

        public MoonAsCentralBodyContext()
        {
            ORM = new KeplerDBContext();
            Repo = new NaturalCelesticalBodies.Repositories.MoonCo(ORM);
        }

        public override KeplerBI.NaturalCelesticalBodies.Repositories.IMoonsCo Moons
        {
            get { return Repo; }
        }
    }
}
