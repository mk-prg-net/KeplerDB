using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.NaturalCelesticalBodies
{
    public class Galaxy : NaturalCelesticalBody, KeplerBI.NaturalCelesticalBodies.IGalaxy
    {
        public Galaxy() { Type = CelesticalBodyType.Galaxy; }
    }
}
