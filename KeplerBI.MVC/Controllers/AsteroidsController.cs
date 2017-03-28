using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeplerBI.MVC.Controllers
{
    public class AsteroidsController : Controller
    {

        KeplerBI.IAstroCatalog catalog;
        mko.RPN.Parser RPNParser = new mko.RPN.Parser(KeplerBI.Parser.RPN.Tokens.EvalFunctions);

        /// <summary>
        /// Zugriff auf astronomischen Katalog via Dependency- Injection
        /// </summary>
        /// <param name="catalog"></param>
        public AsteroidsController(KeplerBI.IAstroCatalog catalog)
        {
            //Properties.Resources.
            this.catalog = catalog;
            mko.Newton.Init.Do();
        }


        // GET: Asteroids
        public ActionResult Index(string rpn = "")
        {
            var fssbld = catalog.Asteroids.createFiltertedSortedSetBuilder();
            var countAll = fssbld.GetSet().Count();

            // neuen fssbld anlegen, da der alte bereits durch vorausgegangene Abfrage mit Sortierfunktion belastet ist
            fssbld = catalog.Asteroids.createFiltertedSortedSetBuilder();

            int skip = 0;
            int take = 25;

            string rpnNext = "1000 Skip 1000 Take";
            string rpnPrev = "0 Skip 1000 Take";

            mko.RPN.IToken[] Tokens = new mko.RPN.IToken[] { };

            if (String.IsNullOrEmpty(rpn))
            {
                // Keine Filter- und Sortiereinschränkungen definiert
                // Begrenzen, damit nicht zu große Ergebnismengen geliefert werden
                fssbld.defSkip(skip);
                fssbld.defTake(take);
            }
            else
            {
                RPNParser.Parse(rpn);
                if (RPNParser.Succsessful)
                {                    

                    var configurator = new KeplerBI.Parser.RPN.FltBldConfigurator(RPNParser.Stack);
                    configurator.ApplyAstro(fssbld);

                    var takeDat = RPNParser.Stack.FirstOrDefault(r => r is KeplerBI.Parser.RPN.TakeData);
                    var skipDat = RPNParser.Stack.FirstOrDefault(r => r is KeplerBI.Parser.RPN.SkipData);


                    Tokens = RPNParser.TokenBuffer.Tokens;

                    if (takeDat != null)
                    {
                        take = ((KeplerBI.Parser.RPN.TakeData)takeDat).count;                        
                        Tokens =  Models.RPNTools.RemoveToken(Tokens, "Take");                        
                    }

                    if (skipDat != null)
                    {
                        skip = ((KeplerBI.Parser.RPN.SkipData)skipDat).count;
                        Tokens = Models.RPNTools.RemoveToken(Tokens, "Skip");                        
                    }

                    var skipPrev = Math.Max(0, skip - take);
                    var skipNext = Math.Min(countAll - take, skip + take);

                    rpnPrev = Models.RPNTools.TokensToString(Tokens) + skipPrev + " Skip " + take + " Take";
                    rpnNext = Models.RPNTools.TokensToString(Tokens) + skipNext + " Skip " + take + " Take";

                }
                else
                {
                    throw new Exception("RPN- Term in URL konnte nicht korrekt geparst werden:" + mko.ExceptionHelper.FlattenExceptionMessages(RPNParser.LastException));
                }
            }
            var s = fssbld.GetSet();
            return View(new Models.Asteroids.AsteroidVM(rpn, s, skip, take, (int)countAll, Tokens, rpnNext, rpnPrev));
        }
    }
}