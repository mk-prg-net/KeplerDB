using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using mko.BI.Repositories.Interfaces;

namespace KeplerBI.MVC.Models.Planets
{
    public class PlanetsVM
    {
        public IFilteredSortedSet<KeplerBI.NaturalCelesticalBodies.IPlanet> Planets { get; set; }

        public mko.RPN.IToken[] Tokens { get; set; }

        public string RPNOrderBySemiMajorAxisDesc
        {
            get
            {
                var TOrder = typeof(KeplerBI.Parser.RPN.Planets.OrderBySemiMajorAxisLengthConfigCmd);
                if (Tokens.Any(t => t.GetType() == TOrder))
                {
                    var token = Tokens.First(t => t.GetType() == TOrder);
                    int ix = Array.IndexOf(Tokens, token);

                    var bld = new System.Text.StringBuilder();
                    for (int i = 0; i < ix - token.CountOfEvaluatedTokens; i++)
                    {
                        bld.Append(Tokens[i].Value);
                        bld.Append(" ");
                    }

                    bld.Append("desc " + TOrder.Name);

                    for (int i = ix + 1; i < Tokens.Length; i++)
                    {
                        bld.Append(Tokens[i].Value);
                        bld.Append(" ");
                    }

                    return bld.ToString();
                }
                else
                {
                    var bld = new System.Text.StringBuilder();
                    for (int i = 0; i < Tokens.Length; i++)
                    {
                        bld.Append(Tokens[i].Value);
                        bld.Append(" ");
                    }
                    bld.Append("desc " + TOrder.Name);
                    return bld.ToString();
                }
            }
        }


        public string QueryOptions = "";

        public double MinBahnRadiusAU { get; set; }
        public double MaxBahnRadiusAU { get; set; }
    }
}