using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.SpaceShips
{
    public interface IMannedSpacecraft : ISpaceShip
    {
        int CrewSize { get; set; }

    }
}
