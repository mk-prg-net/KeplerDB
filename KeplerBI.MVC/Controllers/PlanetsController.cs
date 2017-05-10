//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 7.2016
//
//  Projekt.......: KeplerBI.MVC
//  Name..........: PlanetsController.cs
//  Aufgabe/Fkt...: Planetenliste wird mittels RPN- Ausdrücken gefiltert.
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
using System.Web;
using System.Web.Mvc;

using Trc = mko.TraceHlp;
using mko.RPN;

namespace KeplerBI.MVC.Controllers
{
    //[HandleError(View="~/Views/Shared/Error.cshtml")]
    public class PlanetsController : Controller
    {
        KeplerBI.IAstroCatalog catalog;

        Parser.RPN.IFunctionNames fn = new Parser.RPN.BasicFunctionNames();
        Parser.RPN.FnameEvalTab fnEvalTab;

        /// <summary>
        /// Definition und Konfiguration eines Parsers für RPN- Terme mit Filter- und Sortierausdrücken
        /// </summary>
        mko.RPN.Parser Parser;

        /// <summary>
        /// Zugriff auf astronomischen Katalog via Dependency- Injection
        /// </summary>
        /// <param name="catalog"></param>
        public PlanetsController(KeplerBI.IAstroCatalog catalog)
        {
            this.catalog = catalog;
            this.fnEvalTab = new KeplerBI.Parser.RPN.FnameEvalTab(fn);
            this.Parser = new mko.RPN.Parser(fnEvalTab.FuncEvaluators);
            mko.Newton.Init.Do();
        }

        // GET: Planets
        /// <summary>
        /// Demo: Filterung über RPN- Ausdrücke
        /// </summary>
        /// <param name="pn"></param>
        /// <returns></returns>
        public ActionResult Index(string pn = "")
        {
            var fltBld = catalog.Planets.createFiltertedSortedSetBuilder();
            var Tokens = new mko.RPN.IToken[] { };

            if (String.IsNullOrEmpty(pn))
            {
                //rpn = "asc " + KeplerBI.Parser.RPN.Tokenizer.OrderBySemiMajorAxisLength;
                fltBld.OrderBySemiMajorAxisLength(false);
            }
            else
            {
                var inputTokens =  Parser.TokenizePN(pn);
                Trc.ThrowArgExIfNot(Parser.Succsessful, Properties.Resources.PNParseFailed);

                Parser.Parse(inputTokens);
                Trc.ThrowArgExIfNot(Parser.Succsessful, Properties.Resources.PNParseFailed);

                Tokens = Parser.TokenBuffer.Tokens.Copy();

                var configurator = new KeplerBI.Parser.RPN.FltBldConfigurator(Parser.Stack);
                configurator.Apply(fltBld);
            }

            var PlanetsWithMoons = new List<Models.Planets.PlanetDeco>();
            var planetSet = fltBld.GetSet();
            var planets = planetSet.Get();
            foreach (var planet in planets)
            {
                var bld = catalog.Moons.createNewFilteredSortedSetBuilder();
                bld.defPlanet(planet.Name);
                var moonSet = bld.GetSet();

                if (moonSet.Any())
                {
                    var deco = new Models.Planets.PlanetDeco(planet, moonSet.Get());
                    PlanetsWithMoons.Add(deco);
                }
                else
                {
                    var deco = new Models.Planets.PlanetDeco(planet, new KeplerBI.NaturalCelesticalBodies.IMoon[] { });
                    PlanetsWithMoons.Add(deco);
                }
            }

            var model = new Models.Planets.PlanetsVM(fn, Tokens, PlanetsWithMoons);
            return View(model);
        }


        public JsonResult Voting(string Name, int option)
        {
            var planet = catalog.Planets.GetBo(Name);

            var vt = new Voting();
            vt.VoteFor(planet, (KeplerBI.Voting.Options)option);

            catalog.SubmitChanges();

            return Json(new { Planet = Name, Rank = planet.RankSum / planet.RankCount, Sum = planet.RankSum, Count = planet.RankCount }, JsonRequestBehavior.AllowGet);

        }
    }
}