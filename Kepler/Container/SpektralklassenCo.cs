//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 22.11.2014
//
//  Projekt.......: Kepler
//  Name..........: SpektralklassenCo.cs
//  Aufgabe/Fkt...:  Container, in dem alles Spektralklassen verwaltet werden.
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
    /// Container, in dem alles Spektralklassen verwaltet werden.
    /// </summary>
    /// <typeparam name="TSpektralklasse"></typeparam>
    public abstract class SpektralklassenCo<TSpektralklasse> : mko.BI.Repositories.BoCoBase<TSpektralklasse, int>
        where TSpektralklasse : class, ISpektralklasse
    {
        public class SortTmax : mko.BI.Repositories.DefSortOrderCol<TSpektralklasse, double>
        {
            public SortTmax(bool Descending) : base(r => r.Tmax, Descending) { }
        }


        public SpektralklassenCo()
            : base(new SortTmax(true)) { }


        public abstract TSpektralklasse GetSpektralklasse(SpektralklasseID SKlasseID);
    }
}
