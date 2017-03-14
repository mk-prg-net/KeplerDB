//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 27.5.2016
//
//  Projekt.......: KeplerBI
//  Name..........: ICelesticalBodyBase.cs
//  Aufgabe/Fkt...: Allgemeine Schnittstelle zu den Himmelskörpern
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
//  Datum.........: 8.3.2017
//  Änderungen....: Erweitert uim Eigenschaften für Ranking
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
    public interface ICelestialBodyBase
    {       

        /// <summary>
        /// Name des Himmelskörpers
        /// </summary>
        string Name { get; set; }

        //public virtual  AdditionalInformation { get; set; }

        mko.Newton.Mass Mass { get; set; }
        
        /// <summary>
        /// Absolute Summe aller Bewertungen
        /// </summary>
        int RankSum { get; set; }

        /// <summary>
        /// Absolute Anzahl aller Bewertungen
        /// </summary>
        int RankCount { get; set; }

        /// <summary>
        ///  Umlaufbahn des Himmelskörpers
        /// </summary>
        IOrbit Orbit { get; }

        /// <summary>
        /// Falls vorhanden, ein Bild des Himmelskörpers
        /// </summary>
        IImage Image { get; }


    }
}
