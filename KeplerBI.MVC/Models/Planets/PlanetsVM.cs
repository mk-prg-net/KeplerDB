using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using mko.BI.Repositories.Interfaces;

namespace KeplerBI.MVC.Models.Planets
{
    public class PlanetsVM
    {
        public IEnumerable<PlanetDeco> Planets { get; set; }

        public mko.RPN.IToken[] Tokens { get; set; }

        public int IndexOfFunctionNameToken(string FunctionName, out int CountOfParams)
        {
            if (Tokens.Any(t => t.IsFunctionName && t.Value == FunctionName))
            {
                var tok = Tokens.First(t => t.IsFunctionName && t.Value == FunctionName);
                CountOfParams = tok.CountOfEvaluatedTokens;
                return Array.IndexOf(Tokens, tok);
            }
            else
            {
                CountOfParams = -1;
                return -1;
            }
        }

        public string TokensToString(int begin, int end)
        {
            if (begin < Tokens.Length)
            {
                end = Math.Min(end, Tokens.Length - 1);
                var bld = new System.Text.StringBuilder();
                for (int i = begin; i <= end; i++)
                {
                    bld.Append(Tokens[i].Value);
                    bld.Append(" ");
                }
                return bld.ToString();
            }
            else
            {
                return "";
            }
        }

        public string OrderBySemiMajorAxisRPN(bool desc)
        {
            var sortOrder = (desc ? " desc " : " asc ") + KeplerBI.Parser.RPN.Tokenizer.OrderBySemiMajorAxisLength + " ";

            int CountOfParams;
            int ix = IndexOfFunctionNameToken(KeplerBI.Parser.RPN.Tokenizer.OrderBySemiMajorAxisLength, out CountOfParams);
            return CreateRPNString(sortOrder, ix, CountOfParams);
        }

        private string CreateRPNString(string sortOrder, int ix, int CountOfParams)
        {
            if (ix != -1)
            {
                return TokensToString(0, ix - CountOfParams) + sortOrder + TokensToString(ix + 1, Tokens.Length - 1);
            }
            else
            {
                return TokensToString(0, Tokens.Length) + sortOrder;
            }
        }

        public string OrderByMassRPN(bool desc)
        {
            var sortOrder = (desc ? " desc " : " asc ") + KeplerBI.Parser.RPN.Tokenizer.OrderByMass + " ";

            int CountOfParams;
            int ix = IndexOfFunctionNameToken(KeplerBI.Parser.RPN.Tokenizer.OrderByMass, out CountOfParams);
            return CreateRPNString(sortOrder, ix, CountOfParams);
        }




    }
}