using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.NaturalCelesticalBodies
{
    public class Moon : NaturalCelesticalBody, KeplerBI.NaturalCelesticalBodies.IMoon
    {
        public Moon() { Type = CelesticalBodyType.Moon; }
    }
}
