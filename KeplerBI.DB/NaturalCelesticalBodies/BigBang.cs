using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.NaturalCelesticalBodies
{
    public class BigBang : NaturalCelesticalBody, KeplerBI.NaturalCelesticalBodies.IBigBang
    {
        public BigBang() { Type = CelesticalBodyType.BigBang; }
    }
}
