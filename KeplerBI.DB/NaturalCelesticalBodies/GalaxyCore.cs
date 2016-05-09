using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.NaturalCelesticalBodies
{
    public class GalaxyCore : NaturalCelesticalBody, KeplerBI.NaturalCelesticalBodies.IGalaxyCore
    {
        public GalaxyCore() { Type = CelesticalBodyType.GalaxyCore; }
    }
}
