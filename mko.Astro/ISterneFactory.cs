using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.Astro
{
    public interface ISterneFactory
    {
        /// <summary>
        /// Einen einzelnen Stern in einer Galaxie anlegen. 
        /// </summary>
        /// <param name="Heimatgalaxie">Galaxie, in welcher der Stern sich befindet</param>
        /// <param name="name">Name des Sterns</param>
        /// <param name="masse_in_kg">Masse des Sterns in Kilogramm</param>
        /// <param name="spektralklasse">Spektralklasse des Sterns</param>
        /// <returns></returns>
        Stern Create(Galaxie Heimatgalaxie, string name, double masse_in_kg, Astro.Licht.ISpektralklasse spektralklasse);

        Doppelstern CreateDoppelsternsystem(Stern A, Stern B);
        
        Planetensystem CreatePlanetensystem(Stern zentralkoerper, IEnumerable<Planet> planeten);
    }
}
