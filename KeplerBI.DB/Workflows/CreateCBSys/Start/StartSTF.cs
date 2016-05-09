using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Workflows.CreateCBSys.Start
{
    public class StartSTF : KeplerBI.Workflows.CreateCBSys.Start.StartSTF
    {
        protected override KeplerBI.Workflows.CreateCBSys.SelectCentralBody.MoonAsCentralBodyContext CreateSelectMoonAsCentralBodyContext()
        {
            return new SelectCentralBody.MoonAsCentralBodyContext();
        }

        protected override KeplerBI.Workflows.CreateCBSys.SelectCentralBody.PlanetAsCentralBodyContext CreateSelectPlanetAsCentralBodyContext()
        {
            return new SelectCentralBody.PlanetAsCentralBodyContext();
        }

        protected override KeplerBI.Workflows.CreateCBSys.SelectCentralBody.StarAsCentralBodyContext CreateSelectStarAsCentralBodyContext()
        {
            return new SelectCentralBody.StarAsCentralBodyContext();
        }
    }
}
