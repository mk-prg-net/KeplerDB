//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 7.6.2016
//
//  Projekt.......: KeplerBI
//  Name..........: IAstroCatalogConfig.cs
//  Aufgabe/Fkt...: Struktur der Konfigurationsdatenverwaltung
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

namespace KeplerBI
{    
    public interface IAstroCatalogConfig
    {
        /// <summary>
        /// Definiert den Ordner, in dem zu jedem Himmelskörper eine Bilddatei abgelegt werden kann.
        /// Der Name der Bilddatei sollte dem Namen des Himmelskörpers in der CelesticalBodyBase 
        /// entsprechen.
        /// </summary>
        /// <param name="path"></param>
        void defLocationOfPics(string path);

        /// <summary>
        /// Liste aller Konfigurationsstrings
        /// </summary>
        Config.Repositories.IConfigStringsCo ConfigStrings { get; }
    }
}
