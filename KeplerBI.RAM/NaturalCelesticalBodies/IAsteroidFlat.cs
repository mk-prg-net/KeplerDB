using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.RAM.NaturalCelesticalBodies
{
    public interface IAsteroidFlat
    {
        string Name { get; }

        double MassInEarthMoonMasses { get; }

        double SemiMajorAxisLengthInAU { get;  }

        double MeanOrbitVelocityInKmPerSec { get;  }

        double DiameterInKm { get; }

        double Albedo { get;  }

    }
}
