//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 8.3.2017
//
//  Projekt.......: KeplerDB
//  Name..........: IFSSBldImages.cs
//  Aufgabe/Fkt...: Definieren einer gefilterten Menge von Bildern
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

namespace KeplerBI.Repositories
{
    public interface IFSSBldImages : mko.BI.Repositories.Interfaces.IFilteredSortedSetBuilder<IImage>
    {
        /// <summary>
        /// Sortieren nach dem Erstellungsdatum
        /// </summary>
        /// <param name="descending"></param>
        void OrderByCreated(bool descending);

        /// <summary>
        /// Einschränken auf alle, die exakt die angegebene Breite und Höhe haben
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        void defFormat(int width, int height);

        /// <summary>
        /// Einschränken auf alle, deren Länge und Breite im angegeben Bereich liegen
        /// </summary>
        /// <param name="widthRange"></param>
        /// <param name="heightRange"></param>
        void defFormatRange(mko.BI.Bo.Interval<int> widthRange, mko.BI.Bo.Interval<int> heightRange);

    }
}
