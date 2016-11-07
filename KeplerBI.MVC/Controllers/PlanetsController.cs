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

                    var configurator = new KeplerBI.Parser.RPN.Planets.FltBldConfigurator(RPNParser.Stack);

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

            viewModel.Planets = fltBld.GetSet();
            return View(viewModel);
        }
    }
}