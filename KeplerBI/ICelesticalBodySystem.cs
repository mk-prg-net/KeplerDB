using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI
{
    public interface ICelesticalBodySystem
    {
        ICelestialBodyBase CentralBody { get; }
        IEnumerable<IOrbit> Orbits { get; }

    }
}
