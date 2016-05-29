using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB
{
    public class Orbit : KeplerBI.IOrbit
    {
        //public virtual int ID { get; set; }

        public virtual int SatelliteId { get; set; }
        public virtual CelestialBodyBase Satellite { get; set; }
        ICelestialBodyBase IOrbit.Satellite
        {
            get { return Satellite; }
        }


        public virtual int CentralBodyId { get; set; }
        public virtual CelestialBodyBase CentralBody { get; set; }
        ICelestialBodyBase IOrbit.CentralBody
        {
            get { return CentralBody; }
        }


        public  virtual double SemiMajorAxisInKilometer { get; set; }
        public mko.Newton.Length SemiMajorAxis {
            get
            {
                return mko.Newton.Length.Kilometer(SemiMajorAxisInKilometer);
            }
            set
            {
                SemiMajorAxisInKilometer = mko.Newton.Length.Kilometer(value).Vector[0];
            } 
        }

        public virtual double MeanVelocitiOfCirculationInKmPerSec { get; set; }
        public virtual mko.Newton.Velocity MeanVelocityOfCirculation {
            get
            {
                return mko.Newton.Velocity.KilometerPerSec(MeanVelocitiOfCirculationInKmPerSec);
            }
            set
            {
                MeanVelocitiOfCirculationInKmPerSec = mko.Newton.Velocity.KilometerPerSec(value).Vector[0];
            }
        }

    }
}
