using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.NaturalCelesticalBodies
{
    public class NaturalCelesticalBody : CelestialBodyBase, KeplerBI.NaturalCelesticalBodies.INaturalCelesticalBody
    {
        public virtual double MassInEarthmasses
        {
            get;
            set;
        }

        public override mko.Newton.Mass Mass
        {
            get
            {
                return mko.Newton.Mass.EarthMasses(MassInEarthmasses);
            }
            set
            {
                MassInEarthmasses = mko.Newton.Mass.EarthMasses(value).Value;
            }
        }

        
        public virtual double MeanSurfaceTemp { get; set; }

        public virtual double GravityInMeterPerSec { get; set; }
        public virtual mko.Newton.AccelerationInMeterPerSec<mko.Newton.OrderOfMagnitude.One> Gravity
        {
            get
            {
                return mko.Newton.Acceleration.MeterPerSec2(GravityInMeterPerSec);
            }
            set
            {
                GravityInMeterPerSec = mko.Newton.Acceleration.MeterPerSec2(value).Vector[0];
            }
        }
        public virtual double PolarDiameterInKilometer { get; set; }
        public virtual mko.Newton.LengthInMeter<mko.Newton.OrderOfMagnitude.Kilo> PolarDiameter {
            get
            {
                return mko.Newton.Length.Kilometer(PolarDiameterInKilometer);
            }
            set
            {
                PolarDiameterInKilometer = mko.Newton.Length.Kilometer(value).Vector[0];
            }
        }


        public virtual double EquatorialDiameterInKilometer { get; set; }
        public virtual mko.Newton.LengthInMeter<mko.Newton.OrderOfMagnitude.Kilo> EquatorialDiameter
        {
            get
            {
                return mko.Newton.Length.Kilometer(EquatorialDiameterInKilometer);
            }
            set
            {
                EquatorialDiameterInKilometer = mko.Newton.Length.Kilometer(value).Vector[0];
            }
        }

    }
}
