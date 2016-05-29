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

            if (!String.IsNullOrEmpty(rpn))
            {               

                var tokenizer = new KeplerBI.Parser.RPN.Tokenizer(rpn);                

                RPNParser.Parse(tokenizer, KeplerBI.Parser.RPN.Tokenizer.EvalFunctions);
                if (RPNParser.Succsessful)
                {
                    var configurator = new KeplerBI.Parser.RPN.Planets.FltBldConfigurator(RPNParser.Stack);
                    configurator.Apply(fltBld);
                }
            }
            else
            {
                // Standardsortierreihenfolge definieren
                fltBld.OrderBySemiMajorAxisLength(false);
            }            

            return View(fltBld.GetSet());
        }
    }
}