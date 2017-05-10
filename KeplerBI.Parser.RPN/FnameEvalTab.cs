//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 7.4.2017
//
//  Projekt.......: KeplerBI.Parser.RPN
//  Name..........: FnameEvalTab.cs
//  Aufgabe/Fkt...: Zuordnung von Funktionsnamen an Evaluatoren
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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mko.RPN;

namespace KeplerBI.Parser.RPN
{
    public class FnameEvalTab : mko.RPN.IFunctionEvaluatorTable
    {

        public FnameEvalTab(IFunctionNames fn)
        {
            var dict = new Dictionary<string, IEval>();

            // Tabelle aufbauen
            dict[fn.AlbedoRng] = new AlbedoRngEval(fn);
            dict[fn.AU] = new AUEval();
            dict[fn.ConfigColumn] = new ConfigColumnEval(fn);
            dict[fn.DiameterRng] = new DiameterRngEval(fn);
            dict[fn.EM] = new EMEval();
            //dict[fnames.Kg] = new K
            dict[fn.KM] = new KMEval();
            dict[fn.MassRng] = new MassRngEval(fn);
            //dict[fnames.Meter] = new Meter
            dict[fn.NameLike] = new NameLikeEval(fn);
            dict[fn.OrderByAlbedo] = new OrderByAlbedoEval(fn);
            dict[fn.OrderByDiameter] = new OrderByDiameterEval(fn);
            dict[fn.OrderByMass] = new OrderByMassEval(fn);
            dict[fn.OrderBySemiMajorAxisLength] = new OrderBySemiMajorAxisLengthEval(fn);
            dict[fn.SemiMajorAxisLengthRng] = new SemiMajorAxisLengthRngEval(fn);
            dict[fn.Skip] = new SkipEval(fn);
            dict[fn.SM] = new SMEval();
            dict[fn.Take] = new TakeEval(fn);

            var semEval = new SemFuncEval();
            dict[fn.semCount] = semEval;
            dict[fn.semMax] = semEval;
            dict[fn.semMin] = semEval;
            dict[fn.semPattern] = semEval;
            dict[fn.semOrdeByDir] = semEval;


            _NameEvalTab = new ReadOnlyDictionary<string, IEval>(dict);
        }

        ReadOnlyDictionary<string, mko.RPN.IEval> _NameEvalTab;

        public IReadOnlyDictionary<string, IEval> FuncEvaluators
        {
            get
            {
                return _NameEvalTab;
            }
        }
    }
}
