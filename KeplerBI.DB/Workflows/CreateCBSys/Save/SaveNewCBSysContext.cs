using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Workflows.CreateCBSys
{
    public class SaveNewCBSysContext : KeplerBI.Workflows.CreateCBSys.Save.SaveNewCBSysContext
    {
        public SaveNewCBSysContext(KeplerBI.ICelesticalBodySystem CBSys) : base(CBSys) { }

        public override void Save(string Name, ICelesticalBodySystem CBSys)
        {
            using (var ORM = new KeplerDBContext())
            {
                if (ORM.CelesticalBodySystems.Any(r => r.CentralBody.Name == CBsys.CentralBody.Name))
                    throw new Exception("Für den Himmelskörper " + CBSys.CentralBody.Name + " existiert bereits ein System in der Datenbank. Ein neues kann erst hinzugefügt werden, wenn das alte gelöscht wird.");

                // Aufbauen des neuen Systems
                var dbCBsys = ORM.CelesticalBodySystems.Create();
                ORM.CelesticalBodySystems.Add(dbCBsys);

                // Zentralkörper Entity
                dbCBsys.CentralBody = ORM.CelesticalBodies.Single(r => r.Name == CBSys.CentralBody.Name);

                foreach (var orbit in CBSys.Orbits)
                {
                    var dbOrbit = ORM.Orbits.Create();
                    dbOrbit.Satellite = ORM.CelesticalBodies.Single(r => r.Name == orbit.Satellite.Name);
                    dbOrbit.MeanVelocitiOfCirculationInKmPerSec = mko.Newton.Velocity.KilometerPerSec(orbit.MeanVelocityOfCirculation).Vector.Length;
                    dbOrbit.SemiMajorAxisInKilometer = mko.Newton.Length.Kilometer(orbit.SemiMajorAxis).Vector.Length;

                    dbCBsys.Orbits.Add(dbOrbit);
                }

                ORM.SaveChanges();
            }
        }
    }
}
