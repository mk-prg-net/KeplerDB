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
        public ActionResult Index(string rpn = "")
        {
            var fltBld = catalog.Planets.createFiltertedSortedSetBuilder();   
         
            var viewModel = new Models.Planets.PlanetsVM();

            if (!String.IsNullOrEmpty(rpn))
            {
                rpn = rpn.Trim();
                var tokenizer = new KeplerBI.Parser.RPN.Tokenizer(rpn);                

                RPNParser.Parse(tokenizer, KeplerBI.Parser.RPN.Tokenizer.EvalFunctions);
                if (RPNParser.Succsessful)
                {
                    viewModel.Tokens = RPNParser.TokenBuffer.Tokens;

                    var configurator = new KeplerBI.Parser.RPN.Planets.FltBldConfigurator(RPNParser.Stack);

                    if (!configurator.ConfigCmds.Any(r => r.Value.StartsWith("OrderBy")))
                    {
                        fltBld.OrderBySemiMajorAxisLength(false); 
                    }
                    configurator.Apply(fltBld);

                    var strBld = new System.Text.StringBuilder();
                    foreach(var cfg in configurator.ConfigCmds){
                        strBld.Append(cfg.ToRPNString());
                        strBld.Append(" ");
                    }

                    viewModel.QueryOptions = strBld.ToString();

                    if (configurator.ConfigCmds.Any(r => r.Value == typeof(KeplerBI.Parser.RPN.Planets.SemiMajorAxisLengthRngConfigCmd).Name))
                    {
                        var cmd = configurator.ConfigCmds.First(r => r.Value == typeof(KeplerBI.Parser.RPN.Planets.SemiMajorAxisLengthRngConfigCmd).Name) as KeplerBI.Parser.RPN.Planets.SemiMajorAxisLengthRngConfigCmd;
                        viewModel.MinBahnRadiusAU = mko.Newton.Length.AU(mko.Newton.Length.Kilometer(cmd.Min)).Vector[0];
                        viewModel.MaxBahnRadiusAU = mko.Newton.Length.AU(mko.Newton.Length.Kilometer(cmd.Max)).Vector[0];
                    }
                }
                else
                {
                    throw new Exception("RPN- Term in URL konnte nicht korrekt geparst werden:" + mko.ExceptionHelper.FlattenExceptionMessages(RPNParser.LastException));
                }
            }
            else
            {
                // Standardsortierreihenfolge definieren
                fltBld.OrderBySemiMajorAxisLength(false);
            }            

            viewModel.Planets = fltBld.GetSet();
            return View(viewModel);
        }
    }
}