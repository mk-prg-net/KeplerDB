using System;
using System.Linq;
using System.Web.Mvc;

using mko.RPN;
using Trc = mko.TraceHlp;

namespace KeplerBI.MVC.Controllers
{
    public class AsteroidsController : Controller
    {

        KeplerBI.IAstroCatalog catalog;
        mko.RPN.Parser RPNParser;
        KeplerBI.Parser.RPN.Composer cpsr;
        KeplerBI.Parser.RPN.IFunctionNames fn = new KeplerBI.Parser.RPN.BasicFunctionNames();

        /// <summary>
        /// Zugriff auf astronomischen Katalog via Dependency- Injection
        /// </summary>
        /// <param name="catalog"></param>
        public AsteroidsController(KeplerBI.IAstroCatalog catalog)
        {
            //Properties.Resources.
            this.catalog = catalog;
            mko.Newton.Init.Do();

            cpsr = new Parser.RPN.Composer(fn);
            var fnEvalTab = new KeplerBI.Parser.RPN.FnameEvalTab(fn);
            RPNParser = new mko.RPN.Parser(fnEvalTab.FuncEvaluators);
        }


        // GET: Asteroids
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pn">Filter- und Sortierterme in polnischer Notation</param>
        /// <returns></returns>
        public ActionResult Index(string pn = "")
        {
            var fssbld = catalog.Asteroids.createFiltertedSortedSetBuilder();
            var countAll = fssbld.GetSet().Count();

            // neuen fssbld anlegen, da der alte bereits durch vorausgegangene Abfrage mit Sortierfunktion belastet ist
            fssbld = catalog.Asteroids.createFiltertedSortedSetBuilder();

            int skip = 0;
            int take = 25;

            string pnNext = cpsr.Skip(cpsr.Int(1000)) + cpsr.Take(cpsr.Int(1000));
            string pnPrev = cpsr.Skip(cpsr.Int(0)) + cpsr.Take(cpsr.Int(1000));

            IToken[] AllTokens = new IToken[] { };

            if (String.IsNullOrEmpty(pn))
            {
                // Keine Filter- und Sortiereinschränkungen definiert
                // Begrenzen, damit nicht zu große Ergebnismengen geliefert werden
                fssbld.defSkip(skip);
                fssbld.defTake(take);
            }
            else
            {
                var InputTokens = RPNParser.TokenizePN(pn);
                Trc.ThrowArgExIfNot(RPNParser.Succsessful, Properties.Resources.PNParseFailed);

                RPNParser.Parse(InputTokens);
                Trc.ThrowExIfNot(RPNParser.Succsessful, Properties.Resources.PNParseFailed);
                AllTokens = RPNParser.TokenBuffer.Tokens.Copy();

                var configurator = new Parser.RPN.FltBldConfigurator(RPNParser.Stack);
                configurator.ApplyAstro(fssbld);


                var TokensWithoutSkipTake = RPNParser.TokenBuffer.Tokens.Copy();


                
                var takeDat = RPNParser.Stack.FirstOrDefault(r => r is Parser.RPN.TakeData);
                var skipDat = RPNParser.Stack.FirstOrDefault(r => r is Parser.RPN.SkipData);                


                // Alte Skip und Take- Tokens entfernen
                if (takeDat != null)
                {
                    take = ((Parser.RPN.TakeData)takeDat).count;
                    TokensWithoutSkipTake = TokensWithoutSkipTake.RemoveFunction(fn.Take);
                }

                if (skipDat != null)
                {
                    skip = ((Parser.RPN.SkipData)skipDat).count;
                    TokensWithoutSkipTake = TokensWithoutSkipTake.RemoveFunction(fn.Skip);
                }

                string pnWithoutSkipTake = TokensWithoutSkipTake.ToPNString();

                // Neue Parameter für Skip und Take berechnen
                var skipPrev = Math.Max(0, skip - take);
                var skipNext = (int)Math.Min(countAll - take, skip + take);

                // rpn um Skip und Take erweitern
                pnPrev = pnWithoutSkipTake + cpsr.Skip(cpsr.Int(skipPrev)) + cpsr.Take(cpsr.Int(take));
                pnNext = pnWithoutSkipTake + cpsr.Skip(cpsr.Int(skipNext)) + cpsr.Take(cpsr.Int(take));

            }
            var s = fssbld.GetSet();
            return View(new Models.Asteroids.AsteroidVM(pn, s, skip, take, (int)countAll, AllTokens, pnNext, pnPrev));
        }


        public ActionResult RpnRngFltEdit(string pn, string pnFSubtree)
        {            

            var AllRawTokens = RPNParser.TokenizePN(pn);
            var fSubtreeRawTokens = RPNParser.TokenizePN(pnFSubtree);

            RPNParser.Parse(AllRawTokens);
            Trc.ThrowArgExIfNot(RPNParser.Succsessful, Properties.Resources.PNParseFailed);           

            var AllTokens = RPNParser.TokenBuffer.Tokens.Copy();

            RPNParser.Parse(fSubtreeRawTokens);
            Trc.ThrowArgExIfNot(RPNParser.Succsessful, Properties.Resources.PNParseFailed);

            var fSubtreeTokens = RPNParser.TokenBuffer.Tokens.Copy();
            Trc.ThrowArgExIfNot(fn.Factories.IsRngFilter(fSubtreeTokens.FunctionName()), Properties.Resources.SubtreeAsRangeFlt_expected);

            return View(new Models.Filters.RpnRngFlt("Asteroids", fn, AllTokens, fSubtreeTokens));           

        }

        public ActionResult RpnSortFltEdit(string pn, string pnFSubtree)
        {
            var AllRawTokens = RPNParser.TokenizePN(pn);
            var fSubtreeRawTokens = RPNParser.TokenizePN(pnFSubtree);

            RPNParser.Parse(AllRawTokens);
            Trc.ThrowArgExIfNot(RPNParser.Succsessful, Properties.Resources.PNParseFailed);

            var AllTokens = RPNParser.TokenBuffer.Tokens.Copy();

            RPNParser.Parse(fSubtreeRawTokens);
            Trc.ThrowArgExIfNot(RPNParser.Succsessful, Properties.Resources.PNParseFailed);

            var fSubtreeTokens = RPNParser.TokenBuffer.Tokens.Copy();
            Trc.ThrowArgExIfNot(fn.Factories.IsSortFilter(fSubtreeTokens.FunctionName()), Properties.Resources.SubtreeAsSortFlt_expected);

            return View(new Models.Filters.RpnSortFlt("Asteroids", fn, AllTokens, fSubtreeTokens));
        }


        public ActionResult RpnFunctionEdit(string pn, string pnFSubtree)
        {

            var AllRawTokens = RPNParser.TokenizePN(pn);
            var fSubtreeRawTokens = RPNParser.TokenizePN(pnFSubtree);

            RPNParser.Parse(AllRawTokens);
            Trc.ThrowArgExIfNot(RPNParser.Succsessful, Properties.Resources.PNParseFailed);

            var AllTokens = RPNParser.TokenBuffer.Tokens.Copy();

            RPNParser.Parse(fSubtreeRawTokens);
            Trc.ThrowArgExIfNot(RPNParser.Succsessful, Properties.Resources.PNParseFailed);

            var fSubtreeTokens = RPNParser.TokenBuffer.Tokens.Copy();

            return View(new Models.Filters.Rpn("Asteroids", fn, AllTokens, fSubtreeTokens));

        }


    }
}