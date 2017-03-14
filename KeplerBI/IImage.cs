//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 8.3.2017
//
//  Projekt.......: KeplerDB
//  Name..........: IImage.cs
//  Aufgabe/Fkt...: Stellt ein Bild dar
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
    public interface IImage
    {
        /// <summary>
        /// Datum der Erstellung
        /// </summary>
        DateTime Created { get; set; }

        /// <summary>
        /// Beschreibung zum Bild
        /// </summary>
        string Caption { get; set; }

        /// <summary>
        /// Bildbreite in Pixeln
        /// </summary>
        int WidhtInPix { get; set; }

        /// <summary>
        /// Bildhöhe in Pixeln
        /// </summary>
        int HightInPix { get; set; }

        /// <summary>
        /// Binärdaten des Bildes
        /// </summary>
        byte[] Img { get; set; }
    }
}
