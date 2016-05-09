using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kepler;

namespace Kepler.Defs
{
    /// <summary>
    /// Erweiterungsmethoden und Hilfsfunktionen für Spektralklassen
    /// </summary>
    public abstract class Spektralklasse
    {
        /// <summary>
        /// Hilfsklasse zur Definition einer Liste von Spektralklassen im Business- Layer
        /// </summary>
        public struct Entity : ISpektralklasse {
            public SpektralklasseID SpektralklasseId {get; set;}
            public Spektralklasse_Farbe Farbe {get;set;}
            public string FarbeHtml {get; set;}
            public double Tmin {get; set;}
            public double Tmax {get; set;}
            public double Masse_Hauptreihenstern_in_Sonnenmassen{get; set;}            
        }      
        
        /// <summary>
        /// Definition aller Spektralklassen
        /// </summary>
        public static Dictionary<SpektralklasseID, Spektralklasse.Entity> ListeSpektralklassen = new Dictionary<SpektralklasseID, Spektralklasse.Entity>()
        {              
            {SpektralklasseID.O, new Spektralklasse.Entity(){SpektralklasseId = SpektralklasseID.O, Tmin=30000.0, Tmax= 50000.0, Farbe= Spektralklasse_Farbe.blau, FarbeHtml = "#2196f3", Masse_Hauptreihenstern_in_Sonnenmassen=60}},
            {SpektralklasseID.B, new Spektralklasse.Entity(){SpektralklasseId = SpektralklasseID.B, Tmin=10000.0, Tmax= 28000.0, Farbe= Spektralklasse_Farbe.blau_weiss, FarbeHtml = "#00ffff", Masse_Hauptreihenstern_in_Sonnenmassen=18}},
            {SpektralklasseID.A, new Spektralklasse.Entity(){SpektralklasseId = SpektralklasseID.A, Tmin= 7500.0, Tmax = 9750.0, Farbe= Spektralklasse_Farbe.weiss, FarbeHtml="# ffffff", Masse_Hauptreihenstern_in_Sonnenmassen = 3.2}},
            {SpektralklasseID.F, new Spektralklasse.Entity(){SpektralklasseId = SpektralklasseID.F, Tmin= 6000.0, Tmax = 7350.0, Farbe = Spektralklasse_Farbe.weiss_gelb, FarbeHtml = "#ffffccff", Masse_Hauptreihenstern_in_Sonnenmassen=1.7}},
            {SpektralklasseID.G, new Spektralklasse.Entity(){SpektralklasseId = SpektralklasseID.G, Tmin= 5000.0, Tmax = 5900.0, Farbe = Spektralklasse_Farbe.gelb, FarbeHtml = "#ffff33ff", Masse_Hauptreihenstern_in_Sonnenmassen=1.1}},
            {SpektralklasseID.K, new Spektralklasse.Entity(){SpektralklasseId = SpektralklasseID.K, Tmin= 3500.0, Tmax = 4850.0, Farbe = Spektralklasse_Farbe.orange, FarbeHtml="#ffbb33", Masse_Hauptreihenstern_in_Sonnenmassen=0.8}},
            {SpektralklasseID.M, new Spektralklasse.Entity(){SpektralklasseId = SpektralklasseID.M, Tmin = 2000.0, Tmax = 3350.0, Farbe= Spektralklasse_Farbe.rot_orange, FarbeHtml= "#ff8800", Masse_Hauptreihenstern_in_Sonnenmassen=0.3}},
            {SpektralklasseID.L, new Spektralklasse.Entity(){SpektralklasseId = SpektralklasseID.L, Tmin = 1300.0, Tmax = 2000.0, Farbe= Spektralklasse_Farbe.rot, FarbeHtml="#ff4444", Masse_Hauptreihenstern_in_Sonnenmassen=-1}},
            {SpektralklasseID.T, new Spektralklasse.Entity(){SpektralklasseId = SpektralklasseID.T, Tmin = 600.0, Tmax = 1300.0, Farbe = Spektralklasse_Farbe.rot, FarbeHtml="#ff4444", Masse_Hauptreihenstern_in_Sonnenmassen=-1}},
            {SpektralklasseID.Y, new Spektralklasse.Entity(){SpektralklasseId = SpektralklasseID.Y, Tmin = 200.0, Tmax = 600.0, Farbe= Spektralklasse_Farbe.Infrarot, FarbeHtml="#990000ff", Masse_Hauptreihenstern_in_Sonnenmassen = -1}},
            {SpektralklasseID.R, new Spektralklasse.Entity(){SpektralklasseId = SpektralklasseID.R, Tmin = 3500.0, Tmax = 5400.0, Farbe= Spektralklasse_Farbe.rot_orange, FarbeHtml="#ff8800", Masse_Hauptreihenstern_in_Sonnenmassen= -1}},
            {SpektralklasseID.N, new Spektralklasse.Entity(){SpektralklasseId = SpektralklasseID.N, Tmin = 2000.0, Tmax = 3500.0, Farbe = Spektralklasse_Farbe.rot_orange, FarbeHtml = "#ff8800", Masse_Hauptreihenstern_in_Sonnenmassen = -1}},
            {SpektralklasseID.S, new Spektralklasse.Entity(){SpektralklasseId = SpektralklasseID.S, Tmin = 1900.0, Tmax = 3500.0, Farbe = Spektralklasse_Farbe.rot, FarbeHtml="#ff4444", Masse_Hauptreihenstern_in_Sonnenmassen= -1}}
        };

        // Spektralklasse als konstante Funktionen implementieren

        public static Func<ISpektralklasse> O = () => ListeSpektralklassen[SpektralklasseID.O];
        public static Func<ISpektralklasse> B = () => ListeSpektralklassen[SpektralklasseID.B];
        public static Func<ISpektralklasse> A = () => ListeSpektralklassen[SpektralklasseID.A];
        public static Func<ISpektralklasse> F = () => ListeSpektralklassen[SpektralklasseID.F];
        public static Func<ISpektralklasse> G = () => ListeSpektralklassen[SpektralklasseID.G];
        public static Func<ISpektralklasse> K = () => ListeSpektralklassen[SpektralklasseID.K];
        public static Func<ISpektralklasse> M = () => ListeSpektralklassen[SpektralklasseID.M];
        public static Func<ISpektralklasse> L = () => ListeSpektralklassen[SpektralklasseID.L];
        public static Func<ISpektralklasse> T = () => ListeSpektralklassen[SpektralklasseID.T];
        public static Func<ISpektralklasse> Y = () => ListeSpektralklassen[SpektralklasseID.Y];
        public static Func<ISpektralklasse> R = () => ListeSpektralklassen[SpektralklasseID.R];
        public static Func<ISpektralklasse> N = () => ListeSpektralklassen[SpektralklasseID.N];
        public static Func<ISpektralklasse> S = () => ListeSpektralklassen[SpektralklasseID.S];
    }
}
