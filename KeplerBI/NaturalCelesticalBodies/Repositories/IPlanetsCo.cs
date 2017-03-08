using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IRepo = mko.BI.Repositories.Interfaces;

namespace KeplerBI.NaturalCelesticalBodies.Repositories
{
    public interface IPlanetsCo : IRepo.IGet<IPlanet, string>
    {
        IPlanetsCo_FilteredSortedSetBuilder createFiltertedSortedSetBuilder();
    }
     
    public interface IPlanetsCo_FilteredSortedSetBuilder : INCB_FilteredSortedSetBuilder<IPlanet>
    {
        /// <summary>
        /// Einschränken auf Planeten eines Planetensystems um einen Stern.
        /// </summary>
        /// <param name="NameOfStar">Name des Sterns, den die Pleneten umkreisen</param>
        void defPlanetSys(string NameOfStar);


        /// <summary>
        /// Filtern bezüglich der Anzahl von Monde
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        void defMoonCountBetween(int min, int max);


        /// <summary>
        /// Sortiieren nach der Anzahl von Monden
        /// </summary>
        /// <param name="descending"></param>
        void OrderByMoonCount(bool descending);

    }

        
    
}
