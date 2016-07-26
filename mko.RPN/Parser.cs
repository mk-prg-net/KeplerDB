//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 27.5.2016
//
//  Projekt.......: mko.RPN
//  Name..........: Parser.cs
//  Aufgabe/Fkt...: Ein String mit einem Ausdruck in der RPN- Notation 
//                  (Reverse Polish Notation => Eingabesyntax der programmierbaren 
//                   HP- Taschenrechner aus den 1970-er Jahren)
//                  wie 2 3 ADD 5 MUL <=> (2 + 3) * 5 
//                  wird eingelesen, analysiert und im Falle eines korrekten 
//                  Ausdruckes ausgewertet.
//                  Der Parser ist generisch Implementiert, und kann 
//                  zum Einlesen bliebiger Typ 2- Sprachenterme verwendet werden.
//                  Das Motiv zur Entwicklung war ein System von Filter und Sortierausdrücken
//                  in Uri's zu implementieren. Sollen z.B. in einem Webkatalog für 
//                  astronomische Daten nach allen Riesenplaneten gesucht werden,
//                  (schwerer als 2 Erdmassen), mit mehr als 10 Monden, sortiert nach dem 
//                  Sonnenabstand, könnte dies in einem URL wie folgt kodiert werden:
//                  http://<host:port>/Kepler/Planets/Index?filter=2 EM dblMax MassRng 10 intMax MoonCount asc OrderBySemiMajorAxisLength     
//                  2 EM dblMax MassRng             -> MassRange(mko.Newton.Mass.Earthmass(2), mko.Newton.Mass.Kilogramm(double.MaxValue)
//                  10 intMax MoonCount             -> MoonCount(10, int.MaxValue)
//                  asc OrderBySemiMajorAxisLength  -> OrderBySemiMajoRAxisLength(false)
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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.RPN
{
    public class Parser
    {
        // Stack der Tokens
        Stack<IToken> stack = new Stack<IToken>();

        // Stack der Parameterzahlen
        Stack<int> paramCountStack = new Stack<int>();

        /// <summary>
        /// Hier werden alle korrekt geparsten Tokens der Reihenfolge nach gespeichert. Für 
        /// Token, die Funktionen entsprechen, widerspiegelt der CountOfEvaluatedTokens die 
        /// Gesamte Anzahl von Token links vom Funktionstoken, welche die Parameter der Funktion bilden, 
        /// inklusive dem Funktionsnamen- Token selbst.
        /// </summary>
        public BufferedTokenizer TokenBuffer
        {
            get
            {
                return _TokenBuffer;
            }
        }
        BufferedTokenizer _TokenBuffer = new BufferedTokenizer();

        /// <summary>
        /// Staplspeicher, in den die Tokens eingelesen und über den Funktionen evaluiert werden.
        /// Das Resultat der Funktionen ist wieder auf dem Stapelspeicher abgelegt.
        /// </summary>
        public Stack<IToken> Stack
        {
            get
            {
                return stack;
            }
        }

        /// <summary>
        /// True, wenn das Parsen bis dato erfolgreich war.
        /// </summary>
        public bool Succsessful
        {
            get
            {
                return _Successful;
            }
        }
        bool _Successful = false;

        /// <summary>
        /// War das Parsen nicht erfolgreich (Successful == false), dann wird hier das Problem in Form einer 
        /// Exception beschrieben.
        /// </summary>
        public Exception LastException
        {
            get
            {
                return _ex;
            }
        }
        Exception _ex;

        /// <summary>
        /// Liest über den Tokenizer Typ 2- Sprachterme ein und evaluiert sie, die als Reverse Polish Notation (RPN) 
        /// formuliert wurden.
        /// </summary>
        /// <param name="RpnTokenizer"></param>
        /// <param name="FuncEvaluators"></param>
        public void Parse(ITokenizer RpnTokenizer, Dictionary<string, IEval> FuncEvaluators)
        {
            try
            {
                stack.Clear();
                _Successful = false;
                _ex = null;

                do
                {
                    RpnTokenizer.Read();
                    if (RpnTokenizer.Token != null)
                    {
                        IToken token = RpnTokenizer.Token;
                        if (token.IsFunctionName)
                        {

                            var funcname = token.Value;

                            if (FuncEvaluators.ContainsKey(funcname))
                            {
                                var fe = FuncEvaluators[funcname];

                                int paramCount = stack.Count;
                                fe.Eval(stack);
                                if (!fe.Succesful)
                                {
                                    throw new Exception("Evaluierung von " + funcname + " fehlgeschlagen", fe.EvalException);
                                }

                                // Anzahl verarbeiteter Parameter pro Prozedur bestimmen und protokollieren
                                paramCount -= stack.Count;
                                paramCount++; // Korrektur, da stack nun das Ergebnis enthält
                                int CountOfEvaluatedTokens = 0;
                                for (int i = 0; i < paramCount; i++)
                                {
                                    CountOfEvaluatedTokens += paramCountStack.Pop();
                                }
                                paramCountStack.Push(CountOfEvaluatedTokens + 1);
                                _TokenBuffer.Add(new FunctionNameToken(token.Value, CountOfEvaluatedTokens + 1));
                            }
                            else
                            {
                                throw new Exception("unbekannte Funktion " + funcname);
                            }
                        }
                        else
                        {
                            stack.Push(token);
                            _TokenBuffer.Add(token);
                            paramCountStack.Push(1);
                        }
                    }
                } while (!RpnTokenizer.EOF);
                _Successful = true;
            }
            catch (Exception ex)
            {
                _ex = ex;
                _Successful = false;
            }
        }

    }
}
