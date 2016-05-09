using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.NaturalCelesticalBodies
{
    public class Asteroid : NaturalCelesticalBody, KeplerBI.NaturalCelesticalBodies.IAsteroid
    {
        public Asteroid() { Type = CelesticalBodyType.Asteroid; }

        public double Albedo
        {
            get;
            set;
        }
    }
}
