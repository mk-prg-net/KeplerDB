using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.SpaceShips
{
    public class MannedSpacecraft : SpaceShip, KeplerBI.SpaceShips.IMannedSpacecraft
    {
        public MannedSpacecraft() { Type = CelesticalBodyType.MannedSpaceCraft; }
        public virtual int CrewSize { get; set; }

    }
}
