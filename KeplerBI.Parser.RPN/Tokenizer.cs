//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 2016
//
//  Projekt.......: Projektkontext
//  Name..........: Dateiname
//  Aufgabe/Fkt...: Kurzbeschreibung
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
    public class Tokenizer: mko.RPN.BasicTokenizer
    {
        // Alle Funktionsbezeichner als statische Konstanten definieren        

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
        /// Bahnradiusbereichsfilter
        /// </summary>
        public const string SemiMajorAxisLengthRng = "SemiMajorAxisLengthRng";

        /// <summary>
        /// Sortieren nach Masse
        /// </summary>
        public const string OrderByMass = "OrderByMass";

        /// <summary>
        /// Sortieren nach Bahnradius
        /// </summary>
        public const string OrderBySemiMajorAxisLength = "OrderBySemiMajorAxisLength";

        public static Dictionary<string, mko.RPN.IEval> EvalFunctions = new Dictionary<string, mko.RPN.IEval>{
            {KM, new KMEval()},
            {AU, new AUEval()},
            {EM, new EMEval()},
            {SM, new SMEval()},
            {DiameterRng, new DiameterRngEval()},
            {MassRng, new MassRngEval()},            
            {SemiMajorAxisLengthRng, new SemiMajorAxisLengthRngEval()},
            {OrderByMass, new OrderByMassEval()},
            {OrderBySemiMajorAxisLength, new OrderBySemiMajorAxisLengthEval()}            
        };

        public Tokenizer(System.IO.StreamReader reader) : base(reader) { }

        public Tokenizer(string term) : base(term) { }

        protected override bool TryParseUserdefinedType(string rawToken, out IToken token)
        {

            switch (rawToken)
            {
                case EM:
                case SM:
                case MassRng:
                case AU:
                case KM:
                case DiameterRng:
                case SemiMajorAxisLengthRng:
                case OrderByMass:
                case OrderBySemiMajorAxisLength:
                    token = new FunctionNameToken(rawToken);
                    return true;                    
                default:
                    token = null;
                    return false;
            }
        }
    }
}
