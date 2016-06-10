using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB
{
    public abstract class CelestialBodyBase : KeplerBI.ICelestialBodyBase
    {
        public virtual int ID { get; set; }

        /// <summary>
        /// Definiert den Typ des Himmelskörpers
        /// </summary>
        public virtual CelesticalBodyType Type { get; set; }

        /// <summary>
        /// Naviugationseigenschaft zum Type- Deskriptor
        /// </summary>
        public virtual CelesticalBodyTypeDescriptor TypeDescriptor { get; set; }

        /// <summary>
        /// Name des Himmelskörpers
        /// </summary>
        public virtual string Name { get; set; }

        //public virtual  AdditionalInformation { get; set; }

        public abstract mko.Newton.Mass Mass { get; set; }


        //public virtual int OrbitId { get; set; }
        public virtual Orbit Orbit { get; set; }

        IOrbit ICelestialBodyBase.Orbit
        {
            get
            {
                return Orbit;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
