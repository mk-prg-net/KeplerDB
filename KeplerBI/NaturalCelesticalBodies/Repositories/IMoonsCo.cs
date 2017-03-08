using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IRepo = mko.BI.Repositories.Interfaces;

namespace KeplerBI.NaturalCelesticalBodies.Repositories
{
    public interface IMoonsCo : IRepo.IGet<IMoon, string>
    {
        IMoonsCo_FilteredAndSortedSetBuilder createNewFilteredSortedSetBuilder();
    }

    public interface IMoonsCo_FilteredAndSortedSetBuilder : INCB_FilteredSortedSetBuilder<IMoon>
    {
        /// <summary>
        /// Schränkt auf Monde ein, die einen bestimmten Planeten umkreisen
        /// </summary>
        /// <param name="PlanetName"></param>
        void defPlanet(string PlanetName);
    }
}
