//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 10.3.2017
//
//  Projekt.......: KeplerBI.MVC
//  Name..........: AsteroidVM
//  Aufgabe/Fkt...: Viewmodel für Asteroiden
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

namespace KeplerBI.MVC.Models.Asteroids
{
    public class AsteroidVM
    {
        public AsteroidVM(
            string rpn,
            mko.BI.Repositories.Interfaces.IFilteredSortedSet<KeplerBI.NaturalCelesticalBodies.IAsteroid> fssbld,
            int SkipValue,            
            int TakeValue,
            int countAll, 
            mko.RPN.IToken[] Tokens,
            string rpnNext,
            string rpnPrev)
        {
            this.rpn = rpn;
            this.fssbld = fssbld;
            this.SkipValue = SkipValue;
            this.TakeValue = TakeValue;
            this.countAll = countAll;
            this.Tokens = Tokens;
            this.rpnNext = rpnNext;
            this.rpnPrev = rpnPrev;
        }

        public mko.BI.Repositories.Interfaces.IFilteredSortedSet<KeplerBI.NaturalCelesticalBodies.IAsteroid> fssbld { get; }

        public int countAll { get; }
        public int SkipValue {get;}
        public int TakeValue { get; }
        public mko.RPN.IToken[] Tokens { get; }
        public string rpnNext { get; }
        public string rpnPrev { get; }

        // der aktuell gültige Filterausdruck
        public string rpn { get; set; }



    }
}