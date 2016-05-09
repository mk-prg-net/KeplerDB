using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Workflows.CreateCBSys.SelectCentralBody
{
    public class StarAsCentralBodyContext : KeplerBI.Workflows.CreateCBSys.SelectCentralBody.StarAsCentralBodyContext
    {
        KeplerDBContext ORM = new KeplerDBContext();
        KeplerBI.DB.NaturalCelesticalBodies.Repositories.StarsCo Repo;

        public StarAsCentralBodyContext()
        {
            Repo = new NaturalCelesticalBodies.Repositories.StarsCo(ORM);
        }


        public override mko.BI.Repositories.BoCoBase<KeplerBI.NaturalCelesticalBodies.IStar, string> Stars
        {
            get { return Repo; }
        }
    }
}
