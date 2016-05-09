//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 10.2.2016
//
//  Projekt.......: Basics
//  Name..........: Spektralklasse.cs
//  Aufgabe/Fkt...: Standardimplementierung der Spektralklassen
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

namespace mko.Astro.Licht.Objects
{
    public class Spektralklassen : ISpektralklassen, ISpektralklassenFactory
    {

        /// <summary>
        /// Implementierung der Abstrakten Fabrik
        /// </summary>
        /// <returns></returns>
        public ISpektralklassen Create()
        {
            return Instance;
        }


        /// <summary>
        /// Singelton- Implementierung der Spektralklassen. Vorteil gegenüber eine statischen Klasse: 
        /// 1) 
        /// </summary>
        public static Spektralklassen Instance = new Spektralklassen();

        /// <summary>
        /// Hilfsklasse zur Definition einer Liste von Spektralklassen im Business- Layer
        /// </summary>
        public struct Entity : ISpektralklasse
        {
            internal Entity(SpektralklasseID SpektralklasseId,
                            Spektralklasse_Farbe Farbe,
                            string FarbeHtml,
                            double Tmin,
                            double Tmax,
                            double Masse_Hauptreihenstern_in_Sonnenmassen)
            {
                _SpektralklasseId = SpektralklasseId;
                _Farbe = Farbe;
                _FarbeHtml = FarbeHtml;
                _Masse_Hauptreihenstern_in_Sonnenmassen = Masse_Hauptreihenstern_in_Sonnenmassen;
                _Tmax = Tmax;
                _Tmin = Tmin;
            }


            public SpektralklasseID SpektralklasseId
            {
                get
                {
                    return _SpektralklasseId;
                }
            }
            SpektralklasseID _SpektralklasseId;
            public Spektralklasse_Farbe Farbe
            {
                get
                {
                    return _Farbe;
                }
            }
            Spektralklasse_Farbe _Farbe;
            public string FarbeHtml
            {
                get
                {
                    return _FarbeHtml;
                }
            }
            string _FarbeHtml;

            public double Tmin
            {
                get
                {
                    return _Tmin;
                }
            }
            double _Tmin;
            public double Tmax
            {
                get
                {
                    return _Tmax;
                }
            }
            double _Tmax;
            public double Masse_Hauptreihenstern_in_Sonnenmassen
            {
                get
                {
                    return _Masse_Hauptreihenstern_in_Sonnenmassen;
                }
            }
            double _Masse_Hauptreihenstern_in_Sonnenmassen;
        }

        /// <summary>
        /// Definition aller Spektralklassen
        /// </summary>
        public Dictionary<SpektralklasseID, Entity> ListeSpektralklassen = new Dictionary<SpektralklasseID, Entity>()
        {              
            {SpektralklasseID.O, new Entity(SpektralklasseId: SpektralklasseID.O, Tmin: 30000.0, Tmax: 50000.0, Farbe: Spektralklasse_Farbe.blau, FarbeHtml: "#2196f3", Masse_Hauptreihenstern_in_Sonnenmassen: 60)},
            {SpektralklasseID.B, new Entity(SpektralklasseId : SpektralklasseID.B, Tmin:10000.0, Tmax: 28000.0, Farbe: Spektralklasse_Farbe.blau_weiss, FarbeHtml : "#00ffff", Masse_Hauptreihenstern_in_Sonnenmassen:18)},
            {SpektralklasseID.A, new Entity(SpektralklasseId : SpektralklasseID.A, Tmin: 7500.0, Tmax : 9750.0, Farbe: Spektralklasse_Farbe.weiss, FarbeHtml:"# ffffff", Masse_Hauptreihenstern_in_Sonnenmassen : 3.2)},
            {SpektralklasseID.F, new Entity(SpektralklasseId : SpektralklasseID.F, Tmin: 6000.0, Tmax : 7350.0, Farbe : Spektralklasse_Farbe.weiss_gelb, FarbeHtml : "#ffffccff", Masse_Hauptreihenstern_in_Sonnenmassen:1.7)},
            {SpektralklasseID.G, new Entity(SpektralklasseId : SpektralklasseID.G, Tmin: 5000.0, Tmax : 5900.0, Farbe : Spektralklasse_Farbe.gelb, FarbeHtml : "#ffff33ff", Masse_Hauptreihenstern_in_Sonnenmassen:1.1)},
            {SpektralklasseID.K, new Entity(SpektralklasseId : SpektralklasseID.K, Tmin: 3500.0, Tmax : 4850.0, Farbe : Spektralklasse_Farbe.orange, FarbeHtml:"#ffbb33", Masse_Hauptreihenstern_in_Sonnenmassen:0.8)},
            {SpektralklasseID.M, new Entity(SpektralklasseId : SpektralklasseID.M, Tmin : 2000.0, Tmax : 3350.0, Farbe: Spektralklasse_Farbe.rot_orange, FarbeHtml: "#ff8800", Masse_Hauptreihenstern_in_Sonnenmassen:0.3)},
            {SpektralklasseID.L, new Entity(SpektralklasseId : SpektralklasseID.L, Tmin : 1300.0, Tmax : 2000.0, Farbe: Spektralklasse_Farbe.rot, FarbeHtml:"#ff4444", Masse_Hauptreihenstern_in_Sonnenmassen:-1)},
            {SpektralklasseID.T, new Entity(SpektralklasseId : SpektralklasseID.T, Tmin : 600.0, Tmax : 1300.0, Farbe : Spektralklasse_Farbe.rot, FarbeHtml:"#ff4444", Masse_Hauptreihenstern_in_Sonnenmassen:-1)},
            {SpektralklasseID.Y, new Entity(SpektralklasseId : SpektralklasseID.Y, Tmin : 200.0, Tmax : 600.0, Farbe: Spektralklasse_Farbe.Infrarot, FarbeHtml:"#990000ff", Masse_Hauptreihenstern_in_Sonnenmassen : -1)},
            {SpektralklasseID.R, new Entity(SpektralklasseId : SpektralklasseID.R, Tmin : 3500.0, Tmax : 5400.0, Farbe: Spektralklasse_Farbe.rot_orange, FarbeHtml:"#ff8800", Masse_Hauptreihenstern_in_Sonnenmassen: -1)},
            {SpektralklasseID.N, new Entity(SpektralklasseId : SpektralklasseID.N, Tmin : 2000.0, Tmax : 3500.0, Farbe : Spektralklasse_Farbe.rot_orange, FarbeHtml : "#ff8800", Masse_Hauptreihenstern_in_Sonnenmassen : -1)},
            {SpektralklasseID.S, new Entity(SpektralklasseId : SpektralklasseID.S, Tmin : 1900.0, Tmax : 3500.0, Farbe : Spektralklasse_Farbe.rot, FarbeHtml:"#ff4444", Masse_Hauptreihenstern_in_Sonnenmassen: -1)}
        };

        public ISpektralklasse O
        {
            get { return ListeSpektralklassen[SpektralklasseID.O]; }
        }

        public ISpektralklasse B
        {
            get { return ListeSpektralklassen[SpektralklasseID.B]; }
        }

        public ISpektralklasse A
        {
            get { return ListeSpektralklassen[SpektralklasseID.A]; }
        }

        public ISpektralklasse F
        {
            get { return ListeSpektralklassen[SpektralklasseID.F]; }
        }

        public ISpektralklasse G
        {
            get { return ListeSpektralklassen[SpektralklasseID.G]; }
        }

        public ISpektralklasse K
        {
            get { return ListeSpektralklassen[SpektralklasseID.K]; }
        }

        public ISpektralklasse M
        {
            get { return ListeSpektralklassen[SpektralklasseID.M]; }
        }

        public ISpektralklasse L
        {
            get { return ListeSpektralklassen[SpektralklasseID.L]; }
        }

        public ISpektralklasse T
        {
            get { return ListeSpektralklassen[SpektralklasseID.T]; }
        }

        public ISpektralklasse Y
        {
            get { return ListeSpektralklassen[SpektralklasseID.Y]; }
        }

        public ISpektralklasse R
        {
            get { return ListeSpektralklassen[SpektralklasseID.R]; }
        }

        public ISpektralklasse N
        {
            get { return ListeSpektralklassen[SpektralklasseID.N]; }
        }

        public ISpektralklasse S
        {
            get { return ListeSpektralklassen[SpektralklasseID.S]; }
        }

        public ISpektralklasse this[SpektralklasseID id]
        {
            get { return ListeSpektralklassen[id]; }
        }

    }

}
