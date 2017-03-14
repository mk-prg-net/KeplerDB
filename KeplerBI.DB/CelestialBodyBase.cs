using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB
{
    public abstract class CelestialBodyBase : ICelestialBodyBase
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
        }

        /// <summary>
        /// Summe aller abgegebener Bewertungen
        /// </summary>
        public int RankSum
        {
            get;

            set;
        }

        /// <summary>
        /// Anzahl aller abgegebener Bewertungen
        /// </summary>
        public int RankCount
        {
            get;
            set;
        }

        /// <summary>
        /// Verweist auf ein Bild, das den Himmeslköprer darstellt
        /// </summary>
        public IImage Image
        {
            get
            {
                return ImageDB;
            }

        }


        internal protected Image ImageDB
        {
            get;
            set;
        }
    }
}
