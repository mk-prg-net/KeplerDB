//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 7.4.2017
//
//  Projekt.......: KeplerBI.Parser.RPN
//  Name..........: BasicFunctionNames.cs
//  Aufgabe/Fkt...: Definition der Funktionsnamen vom 7.4.2017
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
//  Autor.........: Martin Korneffel (mko)
//  Datum.........: 11.4.2017
//  Änderungen....: Aufbau systematischer Namen mittels mko.RPN.Filter
//
//</unit_history>
//</unit_header>        

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    public class BasicFunctionNames : IFunctionNames
    {



        public mko.RPN.Filter.IFilterFunctionNamePrefixes Prefixes { get; }
        public mko.RPN.Filter.IFilterFunctionNameFactories Factories { get; }

        public BasicFunctionNames()
        {
            Prefixes = new mko.RPN.Filter.BasicFilterFunctionNamePrefixes();
            Factories = new mko.RPN.Filter.BasicFilterFunctionNameFactories(Prefixes);
        }



        public string AlbedoRng
        {
            get
            {
                return Factories.createRngFltName("albedo");
            }
        }

        public string AU
        {
            get
            {
                return ".au";
            }
        }

        public string ConfigColumn
        {
            get
            {
                return ".cfg.col";
            }
        }

        public string DiameterRng
        {
            get
            {
                return Factories.createRngFltName("diameter");
            }
        }

        public string EM
        {
            get
            {
                return ".em";
            }
        }

        public string Kg
        {
            get
            {
                return ".kg";
            }
        }

        public string KM
        {
            get
            {
                return ".km";
            }
        }

        public string MassRng
        {
            get
            {
                return Factories.createRngFltName("mass");
            }
        }

        public string Meter
        {
            get
            {
                return ".m";
            }
        }

        public string NameLike
        {
            get
            {
                return Factories.createLikeFltName("name");
            }
        }

        public string OrderByAlbedo
        {
            get
            {
                return Factories.createSortFltName("albedo");
            }
        }

        public string OrderByDiameter
        {
            get
            {
                return Factories.createSortFltName("diameter");
            }
        }

        public string OrderByMass
        {
            get
            {
                return Factories.createSortFltName("mass");
            }
        }


        public string OrderBySemiMajorAxisLength
        {
            get
            {
                return Factories.createSortFltName("smAxisLen");
            }
        }


        public string SemiMajorAxisLengthRng
        {
            get
            {
                return Factories.createRngFltName("smAxisLen");
            }
        }

        public string Skip
        {
            get
            {
                return ".skip";
            }
        }

        public string SM
        {
            get
            {
                return ".sm";
            }
        }

        public string Take
        {
            get
            {
                return ".take";
            }
        }

        public string constBool
        {
            get
            {
                return ".bool";
            }
        }

        public string constInt
        {
            get
            {
                return ".int";
            }
        }

        public string constDbl
        {
            get
            {
                return ".dbl";
            }
        }

        public string semMin
        {
            get
            {
                return "..min";
            }
        }

        public string semMax
        {
            get
            {
                return "..max";
            }
        }

        public string semCount
        {
            get
            {
                return "..count";
            }
        }

        public string semPattern
        {
            get
            {
                return "..Pattern";
            }
        }

        public string semOrdeByDir
        {
            get
            {
                return "..dir";
            }
        }

        public bool IsSemanticDescriptor(string FunctionName)
        {
            return FunctionName.StartsWith("..");
        }

        public string ReduceSematicFunctionName(string FunctionName)
        {
            mko.TraceHlp.ThrowArgExIfNot(IsSemanticDescriptor(FunctionName), Properties.Resources.SemanticFunctionNameExpected);
            return FunctionName.Substring(2);
        }
    }
}
