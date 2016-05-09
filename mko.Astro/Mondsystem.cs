//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 11.2.2016
//
//  Projekt.......: mko.Astro
//  Name..........: Mondsystem.cs
//  Aufgabe/Fkt...: Composit- Dekorator über Planet für Planete und seine Monde.
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

namespace mko.Astro
{
    public abstract class Mondsystem : Planet
    {
        /// <summary>
        /// Name des Planeten, den die Monde umkreisen
        /// </summary>
        public abstract Planet Zentralkoerper { get; }

        public override string Name
        {
            get { return Zentralkoerper.Name + "- System"; }
        }

        /// <summary>
        /// 1:n Beziehung zwischen Planet und seinen Monden:
        /// Liste der Monde, die diesen Planeten umkreisen
        /// </summary>
        public abstract IEnumerable<Mond> Monde { get; }

        /// <summary>
        /// Stern, um den der Planet kreist
        /// </summary>
        public override Stern Zentralstern
        {
            get { return Zentralkoerper.Zentralstern; }
        }

        /// <summary>
        /// Gesamtmasse aus den Mondmassen und der Planetenmasse berechnen
        /// </summary>
        /// <returns></returns>
        protected override double BerechneMasseInKg()
        {
            double masse = 0.0;
            foreach (var mond in Monde)
            {
                masse += mond.Masse_in_kg;
            }

            return masse + Zentralkoerper.Masse_in_kg;
        }
    }
}
