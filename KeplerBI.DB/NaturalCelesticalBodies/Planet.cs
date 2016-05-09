using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.NaturalCelesticalBodies
{
    public class Planet : NaturalCelesticalBody, KeplerBI.NaturalCelesticalBodies.IPlanet
    {
        public Planet() { Type = CelesticalBodyType.Planet; }
    }
}
