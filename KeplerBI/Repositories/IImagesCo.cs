//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 8.3.2017
//
//  Projekt.......: KeplerBI
//  Name..........: IImagesCo.cs
//  Aufgabe/Fkt...: Repository für die Bilder: Bildverzeiuchnis
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
    /// <summary>
    /// Bilderverzeichnis
    /// </summary>
    public interface IImagesCo : mko.BI.Repositories.Interfaces.IFilteredSortedSetBuilder<IImage>
    {
        // Keine Create- Methode: Alle Einträge im Bildverzeichnis entstehen durch spezifische 
        // Anwendungen wie z.B. der Astro- Kalalog. Ein neuer Eintrag im Astrokatalog kann mit 
        // einem Bild ausgestattet werden. Dieses kann dann hier als Element einer gefilterten
        // Teilmenge abgerufen werden

        /// <summary>
        /// Erzeugt einen FiteredSortedSet Builder
        /// </summary>
        /// <returns></returns>
        IFSSBldImages CreateFSSBld();

    }
}
