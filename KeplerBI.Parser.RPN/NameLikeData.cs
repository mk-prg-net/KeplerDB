//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 14.3.2017
//
//  Projekt.......: KeplerBI.Parser.RPN
//  Name..........: NameLikeData.cs
//  Aufgabe/Fkt...: Speichert das Wormuster für eine NameLike- Filterung auf dem Stack
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
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    public class NameLikeData : ConfigDataToken
    {
        public NameLikeData(IFunctionNames fn, string pattern): base(fn.NameLike) {
            this.Pattern = pattern;
        }

        public string Pattern { get; }
    }
}
