using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.NaturalCelesticalBodies
{
    public interface INaturalCelesticalBody : ICelestialBodyBase
    {
        /// <summary>
        /// Masse des Himmelskörpers in Erdmassen
        /// </summary>
        double MassInEarthmasses { get; set; }

        /// <summary>
        /// Mittlere Temperatur der Oberfläche
        /// </summary>
        double MeanSurfaceTemp { get; set; }

        /// <summary>
        /// Fallbeschleunigung durch die Anziehungskraft
        /// </summary>
        mko.Newton.AccelerationInMeterPerSec<mko.Newton.OrderOfMagnitude.One> Gravity
        {
            get;
            set;
        }

        /// <summary>
        /// Durchmesser von Pol zu Pol
        /// </summary>
        mko.Newton.LengthInMeter<mko.Newton.OrderOfMagnitude.Kilo> PolarDiameter
        {
            get;
            set;

        }

        /// <summary>
        /// Durchmesser des Äquators
        /// </summary>
        mko.Newton.LengthInMeter<mko.Newton.OrderOfMagnitude.Kilo> EquatorialDiameter
        {
            get;
            set;
        }


    }
}
