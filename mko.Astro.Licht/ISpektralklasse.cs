//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 10.2.2016
//
//  Projekt.......: Basics
//  Name..........: ISpektralklasse.cs
//  Aufgabe/Fkt...: Allgemeine Struktur einer Spektralklasse
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

namespace mko.Astro.Licht
{
    /// <summary>
    /// Spektralklassen der Sterne
    ///  Siehe https://de.wikipedia.org/wiki/Spektralklasse
    /// </summary>
    /// <remarks></remarks>
    public enum SpektralklasseID
    {
        O = 1,
        B = 2,
        A = 3,
        F = 4,
        G = 5,
        K = 6,
        M = 7,
        L = 8,
        T = 9,
        Y = 10,
        R = 11,
        N = 12,
        S = 13
    }

    /// <summary>
    /// Farben, die mit den Spektralklassen von Sternen korespondieren
    /// </summary>
    public enum Spektralklasse_Farbe
    {
        blau,
        blau_weiss,
        weiss,
        weiss_gelb,
        gelb,
        orange,
        rot_orange,
        rot,
        Infrarot,
    }

    public interface ISpektralklasse
    {
        SpektralklasseID SpektralklasseId { get; }
        Spektralklasse_Farbe Farbe { get;  }
        string FarbeHtml { get; }
        double Tmin { get;  }
        double Tmax { get;  }
        double Masse_Hauptreihenstern_in_Sonnenmassen { get; }

    }
}
