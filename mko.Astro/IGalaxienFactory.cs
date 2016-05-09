using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.Astro
{
    public interface IGalaxienFactory
    {
        /// <summary>
        /// Erzeugt eine Galaxie
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Galaxie Create(string name);

    }
}
