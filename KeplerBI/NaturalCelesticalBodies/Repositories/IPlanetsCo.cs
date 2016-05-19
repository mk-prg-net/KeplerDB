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
     
    public interface IPlanetsCo_FilteredSortedSetBuilder : IRepo.IFilteredSortedSetBuilder<IPlanet>
    {
        /// <summary>
        /// Einschränken auf Planeten, deren äquatorialdurchmesser im def. Intervall liegt
        /// </summary>
        /// <param name="diammeterRange"></param>
        void defAequatorialDiameterRange(mko.Newton.Length minDiammeter, mko.Newton.Length maxDiammeter);

        /// <summary>
        /// Einschränken auf Planeten, deren Masse im def Bereich liegt
        /// </summary>
        /// <param name="massRange"></param>
        void defMassRange(mko.Newton.Mass minMass, mko.Newton.Mass maxMass);

        /// <summary>
        /// Filtern bezüglich der Anzahl von Monde
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        void defMoonCountBetween(int min, int max);

        /// <summary>
        /// Sortieren nach Durchmesser
        /// </summary>
        /// <param name="descending"></param>
        void OrderByAequatorialDiameter(bool descending);

        /// <summary>
        /// sortieren nach Masse
        /// </summary>
        /// <param name="descending"></param>
        void OrderByMass(bool descending);

        /// <summary>
        /// sortieren nach Durchmesser der großen Achse der Umlaufbahn
        /// </summary>
        /// <param name="descending"></param>
        void OrderBySemiMajorAxisLength(bool descending);

        /// <summary>
        /// Sortiieren nach der Anzahl von Monden
        /// </summary>
        /// <param name="descending"></param>
        void OrderByMoonCount(bool descending);

    }

        
    
}
