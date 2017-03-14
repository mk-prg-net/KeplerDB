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
    public interface IAsteroidsCo : IRepo.IGet<IAsteroid, string>
    {
        IAsteroidsCo_FilteredSortedSetBuilder createFiltertedSortedSetBuilder();

        void BulkInsertOn();

        void BulkInsertOff();
    }

    /// <summary>
    /// Builder für eine gefilterte und sortierte Menge über den Asteroiden
    /// </summary>
    public interface IAsteroidsCo_FilteredSortedSetBuilder : INCB_FilteredSortedSetBuilder<IAsteroid>
    {

        /// <summary>
        /// Anzahl der zu überspringenden Datensätze in der gefilterten und sortierten Datenmengen.
        /// Die vom Builder eingeschränkte Menge enthält nur die Datensätze, die nach dem 
        /// Überspringen der count Datensätze übrigbleiben
        /// </summary>
        /// <param name="count"></param>
        void defSkip(int count);

        /// <summary>
        /// Anzahl der maximal in der Menge aufzunehmenden Datensätze. Gezählt wird ab dem ersten Datensatz,
        /// der nach Anwenden von Skip übrig bleibt.
        /// </summary>
        /// <param name="count"></param>
        void defTake(int count);

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
