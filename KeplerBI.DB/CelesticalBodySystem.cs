using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB
{
    public class CelesticalBodySystem : ICelesticalBodySystem
    {
        public virtual int ID {get; set;}

        public virtual CelestialBodyBase CentralBody { get; set; }

        public virtual ICollection<Orbit> Orbits { get; set; }


        ICelestialBodyBase ICelesticalBodySystem.CentralBody
        {
            get
            {
                return CentralBody;
            }
        }        

        IEnumerable<IOrbit> ICelesticalBodySystem.Orbits
        {
            get { return Orbits.Select(e => (IOrbit)e).ToArray(); }
        }
    }
}
