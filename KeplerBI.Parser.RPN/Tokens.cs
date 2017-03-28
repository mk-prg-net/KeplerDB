//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 2016
//
//  Projekt.......: Projektkontext
//  Name..........: Dateiname
//  Aufgabe/Fkt...: Definiert die Zuordnung von Funktion- Tokens zu Evaluatoren
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

using mko.RPN;

namespace KeplerBI.Parser.RPN
{
    public class Tokens
    {
        // Alle Funktionsbezeichner als statische Konstanten definieren        

        /// <summary>
        /// Überspringen der ersten n Datensätze
        /// </summary>
        public const string Skip = "Skip";

        /// <summary>
        /// Übernehmen der folgenden n Datensätze
        /// </summary>
        public const string Take = "Take";
        
        /// <summary>
        /// Erdmassen
        /// </summary>
        public const string EM = "EM";  

        /// <summary>
        /// Sonnenmassen
        /// </summary>
        public const string SM = "SM";        

        /// <summary>
        /// Massebereichsfilter
        /// </summary>
        public const string MassRng = "MassRng";

        /// <summary>
        /// Kilometer
        /// </summary>
        public const string KM = "KM";  

        /// <summary>
        /// Astronomische Einheiten
        /// </summary>
        public const string AU = "AU";

        /// <summary>
        /// Durchmesserbereichsfilter
        /// </summary>
        public const string DiameterRng = "DiameterRng";

        /// <summary>
        /// Albedobereichsfilter
        /// </summary>
        public const string AlbedoRng = "AlbedoRng";


        public const string NameLike = "NameLike";

        /// <summary>
        /// Bahnradiusbereichsfilter
        /// </summary>
        public const string SemiMajorAxisLengthRng = "SemiMajorAxisLengthRng";

        /// <summary>
        /// Sortieren nach Masse
        /// </summary>
        public const string OrderByMass = "OrderByMass";

        /// <summary>
        /// Sortieren nach Durchmesser
        /// </summary>
        public const string OrderByDiameter = "OrderByDiameter";

        /// <summary>
        /// Sortieren nach Albedo
        /// </summary>
        public const string OrderByAlbedo = "OrderByAlbedo";


        /// <summary>
        /// Sortieren nach Bahnradius
        /// </summary>
        public const string OrderBySemiMajorAxisLength = "OrderBySemiMajorAxisLength";

        public static Dictionary<string, mko.RPN.IEval> EvalFunctions = new Dictionary<string, mko.RPN.IEval>{
            {Skip,  new SkipEval()},
            {Take,  new TakeEval()},
            {KM, new KMEval()},
            {AU, new AUEval()},
            {EM, new EMEval()},
            {SM, new SMEval()},
            {AlbedoRng, new AlbedoRngEval() },
            {DiameterRng, new DiameterRngEval()},
            {MassRng, new MassRngEval()},
            {NameLike, new NameLikeEval() },
            {SemiMajorAxisLengthRng, new SemiMajorAxisLengthRngEval()},
            {OrderByAlbedo, new OrderByAlbedoEval() },
            {OrderByDiameter, new OrderByDiameterEval() },
            {OrderByMass, new OrderByMassEval()},
            {OrderBySemiMajorAxisLength, new OrderBySemiMajorAxisLengthEval()}            
        };

    }
}
