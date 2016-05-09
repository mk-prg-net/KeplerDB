//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 11.2.2016
//
//  Projekt.......: mko.Astro
//  Name..........: Doppelstern.cs
//  Aufgabe/Fkt...: Stern- Kompositdekorator. Implementiert ein Doppelsternsystem.
//                  Durch den Dekorator wird das Single Responsibillity Prinzip befolgt,
//                  indem statt einer alle Varianten von Sternen abdeckenden allgemeinen Sterne
//                  Klasse viele spezialisierte Klassen gebildet werden. Wg. der Vererbung 
//                  verhält sich die Klasse immer noch wie ein Stern
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

namespace mko.Astro
{
    /// <summary>
    /// Beispiel eines Composit- Dekorators
    /// </summary>
    public abstract class Doppelstern : Stern
    {
        /// <summary>
        /// Erste Komponente des Doppelsternsystems
        /// </summary>
        public abstract Stern A { get; }

        /// <summary>
        /// Zweite Komponente des Doppelsternsystems
        /// </summary>
        public abstract Stern B { get; }

        /// <summary>
        /// Spezielle Masseberechnung für Doppelsterne
        /// </summary>
        /// <returns></returns>
        protected override double BerechneMasseInKg()
        {
            return A.Masse_in_kg + B.Masse_in_kg;
        }

        /// <summary>
        /// Die Komponente mit der größten Masse definiert die Spektralklasse des Doppelsystems
        /// </summary>
        public override Licht.ISpektralklasse Spektralklasse
        {
            get
            {
                if (A.Masse_in_kg > B.Masse_in_kg)
                    return A.Spektralklasse;
                else
                    return B.Spektralklasse;
            }
        }

        public override string Name
        {
            get { return A.Name + "-" + B.Name + " System"; }
        }

        public override Galaxie Heimatgalaxie
        {
            get { return A.Heimatgalaxie; }
        }

        public override double Leuchtkraft_in_Lsonne
        {
            get { return A.Leuchtkraft_in_Lsonne + B.Leuchtkraft_in_Lsonne; }
        }
    }
}
