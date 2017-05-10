//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 13.4.2017
//
//  Projekt.......: KeplerBI.Parser.RPN
//  Name..........: OrderByConfigDataToken.cs
//  Aufgabe/Fkt...: Basisklasse für Konfigurationsdaten von Sortierfunktionen
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

namespace KeplerBI.Parser.RPN
{
    public class OrderByConfigDataToken : ConfigDataToken
    {

        public OrderByConfigDataToken(string cfgCmdName, bool descending)
            : base(cfgCmdName)
        {
            this.descending = descending;
        }

        public bool descending { get; }
    }
}
