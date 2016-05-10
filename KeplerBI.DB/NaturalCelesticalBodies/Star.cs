using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.NaturalCelesticalBodies
{
    public class Star : NaturalCelesticalBody, KeplerBI.NaturalCelesticalBodies.IStar
    {
        public Star() { Type = CelesticalBodyType.Star; SpectralClass = KeplerBI.NaturalCelesticalBodies.SpectralClasses.O; }  

        public virtual KeplerBI.NaturalCelesticalBodies.SpectralClasses SpectralClass{ get; set; }


        public double LuminosityInMulitiplesOfSun
        {
            get;
            set;
        }
    }
}
