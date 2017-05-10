//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 05.06.2016
//
//  Projekt.......: KeplerBI
//  Name..........: IAsteroidsCo.cs
//  Aufgabe/Fkt...: Repository für Asteroiden
//                  
//
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
//  Autor.........: Martin Korneffel (mko)
//  Datum.........: 4.4.2017
//  Änderungen....: GetMinMaxdiameter(...) definiert
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
    public interface IAsteroidsCo : IRepo.IGet<IAsteroid, string>
    {
        IAsteroidsCo_FilteredSortedSetBuilder createFiltertedSortedSetBuilder();

        mko.BI.Bo.Interval<double> GetMinMaxDiameter();

        /// <summary>
        /// Liefert den kleinsten und den größten Wert der Spalte, deren Namen im Parameter übergeben wird
        /// </summary>
        /// <param name="ColName"></param>
        /// <returns></returns>
        Tuple<mko.BI.Bo.Interval<double>, string> GetMinMaxRng(string ColName);
        

        void BulkInsertOn();

        void BulkInsertOff();
    }

    /// <summary>
    /// Builder für eine gefilterte und sortierte Menge über den Asteroiden
    /// </summary>
    public interface IAsteroidsCo_FilteredSortedSetBuilder : INCB_FilteredSortedSetBuilder<IAsteroid>
    {


        /// <summary>
        /// Einschränken auf alle Asteroiden deren Albedo (Helligkeit) im definierten Bereich liegt
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        void defAlbedoRange(double begin, double end);


        /// <summary>
        /// Sortieren nach der Helligkeit
        /// </summary>
        /// <param name="descending"></param>
        void OrderByAlbedo(bool descending);

    }

}
