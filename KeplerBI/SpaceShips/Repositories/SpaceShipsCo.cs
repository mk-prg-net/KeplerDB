using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.SpaceShips.Repositories
{
    public abstract class SpaceShipsCo : mko.BI.Repositories.BoCoBase<SpaceShips.ISpaceShip, string>
    {
        public class SortName : mko.BI.Repositories.DefSortOrderCol<ISpaceShip, string>
        {
            public SortName(bool Descending) : base(r => r.Name, Descending) { }
        }

        public SpaceShipsCo() : base(new SortName(false)) { }

        public override Func<SpaceShips.ISpaceShip, bool> GetBoIDTest(string id)
        {
            return r => r.Name == id;
        }
    }
}
