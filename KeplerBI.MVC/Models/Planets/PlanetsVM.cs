using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using mko.BI.Repositories.Interfaces;

using mko.RPN;

namespace KeplerBI.MVC.Models.Planets
{
    public class PlanetsVM
    {

        public PlanetsVM(KeplerBI.Parser.RPN.IFunctionNames fn, mko.RPN.IToken[] Tokens, IEnumerable<PlanetDeco> Planets)
        {
            this.fn = fn;
            this.Planets = Planets;
            this.Tokens = Tokens;
            this.cpsr = new Parser.RPN.Composer(fn);

        }

        Parser.RPN.IFunctionNames fn;
        Parser.RPN.Composer cpsr;

        public IEnumerable<PlanetDeco> Planets { get; }

        public mko.RPN.IToken[] Tokens { get; set; }

        public string OrderBySemiMajorAxisPN(Cfg.SortDirection dir)
        {
            switch (dir)
            {
                case Cfg.SortDirection.down:
                    return Tokens.RemoveFunction(fn.OrderBySemiMajorAxisLength).ToPNString() + cpsr.OrderBySemiMajorAxisLength("desc");
                case Cfg.SortDirection.none:
                    return Tokens.RemoveFunction(fn.OrderBySemiMajorAxisLength).ToPNString();
                case Cfg.SortDirection.up:
                    return Tokens.RemoveFunction(fn.OrderBySemiMajorAxisLength).ToPNString() + cpsr.OrderBySemiMajorAxisLength("asc");
                default:
                    throw new Exception("unbakannter Wert für Sort- Direction: " + dir);
            }
        }

        public string OrderByMassPN(Cfg.SortDirection dir)
        {
            switch (dir)
            {
                case Cfg.SortDirection.down:
                    return Tokens.RemoveFunction(fn.OrderByMass).ToPNString() + cpsr.OrderByMass("desc");
                case Cfg.SortDirection.none:
                    return Tokens.RemoveFunction(fn.OrderByMass).ToPNString();
                case Cfg.SortDirection.up:
                    return Tokens.RemoveFunction(fn.OrderByMass).ToPNString() + cpsr.OrderByMass("asc");
                default:
                    throw new Exception("unbakannter Wert für Sort- Direction: " + dir);
            }
        }




    }
}