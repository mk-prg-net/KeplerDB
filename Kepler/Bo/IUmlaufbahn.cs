//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 22.11.2014
//
//  Projekt.......: Kepler
//  Name..........: IUmlaufbahn.cs
//  Aufgabe/Fkt...: Grundstruktur aller Umlaufbahnen von Himmelskörpern
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

namespace Kepler
{
    /// <summary>
    /// Grundstruktur aller Umlaufbahnen von Himmelskörpern
    /// </summary>
    public interface IUmlaufbahn
    {
        double Laenge_grosse_Halbachse_in_km { get; set; }
        double Exzentritzitaet { get; set; }
        double Umlaufdauer_in_Tagen { get; set; }
        double Mittlere_Umlaufgeschwindigkeit_in_km_pro_sec { get; set; }
        
        /// <summary>
        /// Himmelskörper, der umlaufen wird
        /// </summary>
        IHimmelskoerper Zentralobjekt { get; set; }

    }
}
