using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Workflows.CreateCBSys
{
    public class CBSysDraft : KeplerBI.Workflows.CreateCBSys.ICBSysDraft
    {
        CelesticalBodySystem CBS = new CelesticalBodySystem();

        public void SetCentralBody(ICelestialBodyBase centralBody)
        {
            using (var ORM = new KeplerDBContext())
            {
                var centralBodyEntity =  ORM.CelesticalBodies.Single(r => r.Name == centralBody.Name);
                CBS.CentralBody = centralBodyEntity;
            }            
        }

        public void AddSatelliteOrbit(IOrbit satelliteOrbit)
        {
            using (var ORM = new KeplerDBContext())
            {
                var SatelliteEntity = ORM.CelesticalBodies.Single(r => r.Name == satelliteOrbit.Satellite.Name);

                if (CBS.Orbits == null)
                    CBS.Orbits = new List<KeplerBI.DB.Orbit>();

                if (CBS.Orbits.Any(r => r.Satellite.Name == satelliteOrbit.Satellite.Name))
                    throw new Exception("Der Satellite " + satelliteOrbit.Satellite.Name + " wurde bereits hinzugefügt");

                var orbit = new KeplerBI.DB.Orbit()
                {
                    Satellite = SatelliteEntity,
                    MeanVelocitiOfCirculationInKmPerSec = mko.Newton.Velocity.KilometerPerSec(satelliteOrbit.MeanVelocityOfCirculation).Vector.Length,
                    SemiMajorAxisInKilometer = mko.Newton.Length.Kilometer(satelliteOrbit.SemiMajorAxis).Vector.Length
                };

                CBS.Orbits.Add(orbit);
            }
        }

        public IOrbit RemoveLastSatelliteOrbit()
        {
            var lastOrbit = CBS.Orbits.Last();
            CBS.Orbits.Remove(lastOrbit);
            return lastOrbit;
        }

        public void ClearSatelliteOrbits()
        {
            CBS.Orbits.Clear();
        }

        public ICelestialBodyBase CentralBody
        {
            get { return CBS.CentralBody; }
        }

        public IEnumerable<IOrbit> Orbits
        {
            get { return CBS.Orbits; }
        }
    }

}
