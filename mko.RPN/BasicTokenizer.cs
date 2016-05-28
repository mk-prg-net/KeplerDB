
//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 27.5.2016
//
//  Projekt.......: mko.RPN
//  Name..........: BasicTokenizer.cs
//  Aufgabe/Fkt...: Basisimplementierung eines Tokenizers. List die Terme von 
//                  einem Datenstrom als Zeichenketten ein. Erzeugt aus ihnen 
//                  spezielle IToken- Objekte (IntToken, DoubleToken etc.).
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
using System.Text;
using System.Threading.Tasks;

namespace mko.RPN
{
    public class BasicTokenizer : ITokenizer
    {
        System.IO.StreamReader streamReader;

        /// <summary>
        /// Konstruktor der Basisimplementierung eines Tokenizers
        /// </summary>
        /// <param name="reader">Datenstrom, die Typ 2 Sprachterme in Reverse Polish Notation (RPN) enthält</param>
        public BasicTokenizer(System.IO.StreamReader reader)
        {
            streamReader = reader;
        }

        /// <summary>
        /// Konstruktor der Basisimplementierung eines Tokenizers
        /// </summary>
        /// <param name="term">Zeichenkette, die Typ 2 Sprachterme in Reverse Polish Notation (RPN) enthält</param>
        public BasicTokenizer(string term)
        {
            System.IO.MemoryStream memStream = new System.IO.MemoryStream();
            var TermWriter = new System.IO.StreamWriter(memStream);
            TermWriter.Write(term);
            TermWriter.Flush();
            memStream.Seek(0, System.IO.SeekOrigin.Begin);

            streamReader = new System.IO.StreamReader(memStream);

        }

        /// <summary>
        /// Erweiterrungspunkt zum Einlesen benutzerdefinierter/aufgabenspezifischer Token
        /// wie Funktionen, durch Sonderzeichen markierte Token.
        /// </summary>
        /// <param name="rawToken"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        protected virtual bool TryParseUserdefinedType(string rawToken, out IToken token)
        {
            token = null;
            return false;
        }

        System.Globalization.CultureInfo usCult = new System.Globalization.CultureInfo("en-US");

        public void Read()
        {
            eatWhitespace();

            // Lerraumzeichen begrenzen die Tokens
            var bld = new System.Text.StringBuilder();
            while (!streamReader.EndOfStream && !Char.IsWhiteSpace((Char)streamReader.Peek()))
            {
                bld.Append((char)streamReader.Read());
            }

            var rawToken = bld.ToString();

            int intValue = 0;
            double dblValue = 0.0;
            bool boolValue = false;
            IToken token = null;

            var cultBackup = System.Threading.Thread.CurrentThread.CurrentCulture;

            System.Threading.Thread.CurrentThread.CurrentCulture = usCult; 

            try
            {
                if (!string.IsNullOrEmpty(rawToken))
                {
                    if (rawToken == "'")
                    {
                        throw new NotImplementedException();
                    }
                    else if (TryParseUserdefinedType(rawToken, out token))
                    {
                        _currentToken = token;
                    }
                    else if (int.TryParse(rawToken, out intValue))
                    {
                        _currentToken = new IntToken(intValue);
                    }
                    else if (double.TryParse(rawToken, out dblValue))
                    {
                        _currentToken = new DoubleToken(dblValue);
                    }
                    else if (bool.TryParse(rawToken, out boolValue))
                    {
                        _currentToken = new BoolToken(boolValue);
                    }
                    else
                    {
                        _currentToken = new StringToken(rawToken);
                    }
                }
            }
            finally
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = cultBackup;
            }
        }

        private void eatWhitespace()
        {
            while (!streamReader.EndOfStream && char.IsWhiteSpace((char)streamReader.Peek()))
            {
                streamReader.Read();
            }
        }

        public bool EOF
        {
            get { return streamReader.EndOfStream; }
        }

        public IToken Token
        {
            get { return _currentToken; }
        }
        IToken _currentToken;
    }
}
