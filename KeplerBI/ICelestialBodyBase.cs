using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI
{
    public interface ICelestialBodyBase
    {       

        /// <summary>
        /// Name des Himmelskörpers
        /// </summary>
        string Name { get; set; }

        //public virtual  AdditionalInformation { get; set; }

        mko.Newton.Mass Mass { get; set; }

        /// <summary>
        ///  Umlaufbahn des Himmelskörpers
        /// </summary>
        IOrbit Orbit { get; set; }

    }
}
