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

namespace KeplerBI.MVC.Controllers
{
    public class PlanetsController : Controller
    {
        KeplerBI.IAstroCatalog catalog;
        mko.RPN.Parser RPNParser = new mko.RPN.Parser();

        /// <summary>
        /// Zugriff auf astronomischen Katalog via Dependency- Injection
        /// </summary>
        /// <param name="catalog"></param>
        public PlanetsController(KeplerBI.IAstroCatalog catalog)
        {
            this.catalog = catalog;
            mko.Newton.Init.Do();
        }

        // GET: Planets
        /// <summary>
        /// Demo: Filterung über RPN- Ausdrücke
        /// </summary>
        /// <param name="rpn"></param>
        /// <returns></returns>
        public ActionResult Index(string rpn = "")
        {
            var fltBld = catalog.Planets.createFiltertedSortedSetBuilder();

            var viewModel = new Models.Planets.PlanetsVM();

            if (String.IsNullOrEmpty(rpn))
            {
                //rpn = "asc " + KeplerBI.Parser.RPN.Tokenizer.OrderBySemiMajorAxisLength;
                fltBld.OrderBySemiMajorAxisLength(false);
                viewModel.Tokens = new mko.RPN.IToken[]{};
            }
            else
            {

                rpn = rpn.Trim();
                var tokenizer = new KeplerBI.Parser.RPN.Tokenizer(rpn);

                RPNParser.Parse(tokenizer, KeplerBI.Parser.RPN.Tokenizer.EvalFunctions);
                if (RPNParser.Succsessful)
                {
                    viewModel.Tokens = RPNParser.TokenBuffer.Tokens;

                    var configurator = new KeplerBI.Parser.RPN.FltBldConfigurator(RPNParser.Stack);

                    if (!viewModel.Tokens.Any(r => r.Value.StartsWith("OrderBy")))
                    {
                        fltBld.OrderBySemiMajorAxisLength(false);
                    }
                    configurator.Apply(fltBld);

                }
                else
                {
                    throw new Exception("RPN- Term in URL konnte nicht korrekt geparst werden:" + mko.ExceptionHelper.FlattenExceptionMessages(RPNParser.LastException));
                }
            }

            List<Models.Planets.PlanetDeco> PlanetsWithMoons = new List<Models.Planets.PlanetDeco>();
            var planetSet = fltBld.GetSet();
            foreach (var planet in planetSet.Get())
            {
                var bld = catalog.Moons.createNewFilteredSortedSetBuilder();
                bld.defPlanet(planet.Name);
                var moonSet = bld.GetSet();

                if (moonSet.Any())
                {
                    var deco = new Models.Planets.PlanetDeco(planet, moonSet.Get());
                    PlanetsWithMoons.Add(deco);
                } else {
                    var deco = new Models.Planets.PlanetDeco(planet, new KeplerBI.NaturalCelesticalBodies.IMoon[]{});
                    PlanetsWithMoons.Add(deco);
                }
            }

            viewModel.Planets = PlanetsWithMoons;
            return View(viewModel);
        }
    }
}