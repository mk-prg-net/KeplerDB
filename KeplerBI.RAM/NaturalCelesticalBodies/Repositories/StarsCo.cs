using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeplerBI.NaturalCelesticalBodies;
using KeplerBI.NaturalCelesticalBodies.Repositories;

namespace KeplerBI.RAM.NaturalCelesticalBodies.Repositories
{
    public class StarsCo : KeplerBI.NaturalCelesticalBodies.Repositories.IStarsCo
    {
        public IStarsCo_FilteredAndSortedSetBuilder createNewFilteredSortedSetBuilder()
        {
            throw new NotImplementedException();
        }

        public bool ExistsBo(string id)
        {
            throw new NotImplementedException();
        }

        public IStar GetBo(string id)
        {
            if(id == "Sonne")
            {
                return Star.Sun;
            } else
            {
                throw new NotImplementedException();
            }
        }
    }
}
