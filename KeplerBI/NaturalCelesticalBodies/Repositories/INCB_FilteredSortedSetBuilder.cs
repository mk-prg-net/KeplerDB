//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 7.11.2016
//
//  Projekt.......: KeplerBI
//  Name..........: INCB_FilteredSortedSetBuilder
//  Aufgabe/Fkt...: Schnittstelle mit Filterdefinitionen, die auf alle 
//                  natürlichen Himmelskörper (Sterne, Planeten, Monde)
//                  anwendbar sind.
//
//
//
//<unit_environment>
//------------------------------------------------------------------
//  Zielmaschine..: PC 
//  Betriebssystem: Windows 7 mit .NET 4.5
//  Werkzeuge.....: Visual Studio 2013
//  Autor.........: Martin Korneffel (mko)
//  Version 1.0...: 
//
// </unit_environment>
//
//<unit_history>
//------------------------------------------------------------------
//
//  Version.......: 1.1
//  Autor.........: Martin Korneffel (mko)
//  Datum.........: 
//  Änderungen....: 
//
//</unit_history>
//</unit_header>        
        

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IRepo = mko.BI.Repositories.Interfaces;

namespace KeplerBI.NaturalCelesticalBodies.Repositories
{
    /// <summary>
    /// out TEntity (Covarianz), da TEntity nur ein Rückgabetyp der funktion GetSet ist
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface INCB_FilteredSortedSetBuilder<out TEntity> :  IRepo.IFilteredSortedSetBuilder<TEntity> 
        where TEntity : INaturalCelesticalBody
    {
        /// <summary>
        /// Einschränken auf Planeten, die den Zentralstern in einem Abstand von- bis umkreisen
        /// </summary>
        /// <param name="min">Kleinster Bahnradius</param>
        /// <param name="max">Größter Bahnradius</param>
        void defSemiMajorAxisLengthRange(mko.Newton.Length min, mko.Newton.Length max);

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
