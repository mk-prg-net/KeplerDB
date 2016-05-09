//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 22.11.2014
//
//  Projekt.......: Kepler
//  Name..........: INatuerlicherHimmelskoerper.cs
//  Aufgabe/Fkt...: Grundstruktur aller natürlichen Himmelskörper wie Sterne, Planeten, Monde
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
    /// Grundstruktur aller natürlichen Himmelskörper wie Sterne, Planeten, Monde
    /// </summary>
    public interface INatuerlicherHimmelskoerper : IHimmelskoerper
    {
        double Aequatordurchmesser_in_km { get; set; }
        double Polardurchmesser_in_km { get; set; }
        double Oberflaechentemperatur_in_K { get; set; }
        double Rotationsperiode_in_Stunden { get; set; }
        double Fallbeschleunigung_in_meter_pro_sec { get; set; }
        double Rotationsachsenneigung_in_Grad { get; set; }
    }
}
