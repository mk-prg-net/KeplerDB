//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 23.11.2014
//
//  Projekt.......: Kepler
//  Name..........: UmlaufbahnenCo.cs
//  Aufgabe/Fkt...: Container, in dem alle Umlaufbahnen verwaltet werden.
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
    /// Container, in dem alle Umlaufbahnen verwaltet werden.
    /// </summary>
    /// <typeparam name="TSpektralklasse"></typeparam>
    public abstract class UmlaufbahnenCo<TPlanet, TKey> : mko.BI.Repositories.BoCoBase<TPlanet, TKey>
        where TPlanet : class, IUmlaufbahn
    {
        public class SortBahnradius : mko.BI.Repositories.DefSortOrderCol<TPlanet, double>
        {
            public SortBahnradius(bool Descending) : base(r => r.Laenge_grosse_Halbachse_in_km, Descending) { }
        }

        public UmlaufbahnenCo()
            : base(new SortBahnradius(false)) { }

    }
}
