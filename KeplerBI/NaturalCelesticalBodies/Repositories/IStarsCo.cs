using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IRepo = mko.BI.Repositories.Interfaces;

namespace KeplerBI.NaturalCelesticalBodies.Repositories
{
    public interface IStarsCo :
        IRepo.IGet<IStar, string>
    {
        IStarsCo_FilteredAndSortedSetBuilder createNewFilteredSortedSetBuilder();
    }

    public interface IStarsCo_FilteredAndSortedSetBuilder : IRepo.IFilteredSortedSetBuilder<IStar>
    {
        /// <summary>
        /// Einschränken auf Sterne, deren äquatorialdurchmesser im def. Intervall liegt
        /// </summary>
        /// <param name="diammeterRange"></param>
        void defAequatorialDiameterRange(mko.Newton.Length minDiammeter, mko.Newton.Length maxDiammeter);

        /// <summary>
        /// Einschränken auf Sterne, deren Masse im def Bereich liegt
        /// </summary>
        /// <param name="massRange"></param>
        void defMassRange(mko.Newton.Mass minMass, mko.Newton.Mass maxMass);

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

    }

}
