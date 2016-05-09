using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.SpaceShips
{
    public interface ISpaceShip : ICelestialBodyBase
    {
        double MassInKg { get; set; }       

        ICountry Homeland { get; }

        IEnumerable<Application> AreasOfApplication { get; }        
    }
}
