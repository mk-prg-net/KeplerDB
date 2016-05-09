using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.NaturalCelesticalBodies
{
    public class Comet : NaturalCelesticalBody, KeplerBI.NaturalCelesticalBodies.IComet
    {
        public Comet() { Type = CelesticalBodyType.Comet; }
    }
}
