//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 23.11.2015
//
//  Projekt.......: Kepler.MVC
//  Name..........: Paging.cs
//  Aufgabe/Fkt...: Modell für PagingCtrl- partial View
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
using System.Web;

namespace Kepler.MVC.Models
{
    public class Paging
    {
        public int Seitennummer { get; set; }

        public int Anz_Seiten_gesamt { get; set; }

        public int Erste_Seite
        {
            get
            {
                return 0;
            }
        }

        public int Vorausgegangene_Seite
        {
            get
            {
                int neue_Seitennummer = Seitennummer - 1;
                return neue_Seitennummer > 0 ? neue_Seitennummer : 0;
            }
        }


        public int Naechste_Seite
        {
            get
            {
                int neue_Seitennummer = Seitennummer + 1;
                return neue_Seitennummer < Anz_Seiten_gesamt ? neue_Seitennummer : Seitennummer;
            }
        }


        public int Letzte_Seite
        {
            get
            {
                return Anz_Seiten_gesamt;
            }
        }

    }
}