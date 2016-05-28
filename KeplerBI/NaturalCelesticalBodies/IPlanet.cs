using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.NaturalCelesticalBodies
{
    public interface IPlanet : INaturalCelesticalBody
    {
        /// <summary>
        /// True, wenn der Planet Ringe hat
        /// </summary>
        bool HasRings { get; set; }
    }
}
