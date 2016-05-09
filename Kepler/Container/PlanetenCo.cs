//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 22.11.2014
//
//  Projekt.......: Kepler
//  Name..........: SpektralklassenCo.cs
//  Aufgabe/Fkt...:  Container, in dem alle Planeten verwaltet werden.
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
    /// Container, in dem alle Planeten verwaltet werden.
    /// </summary>
    /// <typeparam name="TSpektralklasse"></typeparam>
    public abstract class PlanetenCo<TPlanet, TKey> : mko.BI.Repositories.BoCoBase<TPlanet, TKey>
        where TPlanet : class, IPlanet
    {
        public class SortName : mko.BI.Repositories.DefSortOrderCol<TPlanet, string>
        {
            public SortName(bool Descending) : base(r => r.Name, Descending) { }
        }

        /// <summary>
        /// Sortierfunktor: Ordnen nach Abstand zur Sonne.
        /// </summary>
        public class SortDistanceToSun : mko.BI.Repositories.DefSortOrderCol<TPlanet, double>
        {
            public SortDistanceToSun(bool Descending) : base(r => r.Umlaufbahn.Laenge_grosse_Halbachse_in_km, Descending) { }

        }

        /// <summary>
        /// Sortierfunktor: Ordnen nach Anzahl der Monde
        /// </summary>
        public class SortMoonCount : mko.BI.Repositories.DefSortOrderCol<TPlanet, int>
        {
            public SortMoonCount(bool Descending) : base(r => r.Monde.Count(), Descending) { }
        }

        /// <summary>
        /// Sortierfunktor: Ordnen nach Masse
        /// </summary>
        public class SortMass : mko.BI.Repositories.DefSortOrderCol<TPlanet, double>
        {
            public SortMass(bool Descending) : base(r => r.Masse_in_kg, Descending) { }

        }



        public PlanetenCo()
            : base(new SortName(true)) { }

    }
}
