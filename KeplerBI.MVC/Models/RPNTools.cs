//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 10.3.2017
//
//  Projekt.......: KeplerBI.MVC
//  Name..........: RPNTools.cs
//  Aufgabe/Fkt...: Tools zur bearbeitung von RPN's
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

namespace KeplerBI.MVC.Models
{
    public class RPNTools
    {
        /// <summary>
        /// Aus einer Tokenliste wird ein RPN- String erzeugt
        /// </summary>
        /// <param name="Tokens"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string TokensToString(mko.RPN.IToken[] Tokens, int begin, int end)
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

        public static string TokensToString(mko.RPN.IToken[] Tokens)
        {
            return TokensToString(Tokens, 0, Tokens.Length);
        }


        public static mko.RPN.IToken[] RemoveToken(mko.RPN.IToken[] Tokens, string FunctionName)
        {
            int pc;
            var ix = IndexOfFunctionNameToken(Tokens, FunctionName, out pc);

            if(ix != -1)
            {
                // Funktion wird entfernt
                var newTList = new List<mko.RPN.IToken>(Tokens.Length);
                for (int i = 0, count = ix-pc+1; i < count; i++)
                {
                    newTList.Add(Tokens[i]);
                }

                for (int i = ix + 1, count = Tokens.Length; i < count; i++)
                {
                    newTList.Add(Tokens[i]);
                }
                return newTList.ToArray();
            } else
            {
                // Enthält di Funktion nicht
                return Tokens;
            }
        }



        private static string InsertPNString(mko.RPN.IToken[] Tokens, string sortOrder, int ix, int CountOfParams)
        {
            if (ix != -1)
            {
                return TokensToString(Tokens, 0, ix - CountOfParams) + sortOrder + TokensToString(Tokens, ix + 1, Tokens.Length - 1);
            }
            else
            {
                return TokensToString(Tokens, 0, Tokens.Length) + sortOrder;
            }
        }

        public static int IndexOfFunctionNameToken(mko.RPN.IToken[] Tokens, string FunctionName, out int CountOfParams)
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


    }
}