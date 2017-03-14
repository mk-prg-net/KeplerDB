//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 8.3.2017
//
//  Projekt.......: KeplerBI.DB
//  Name..........: Image.cs
//  Aufgabe/Fkt...: Eintrag eines Bildverzeichnisses
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

using S = System.ComponentModel.DataAnnotations;


namespace KeplerBI.DB
{
    public class Image : IImage
    {

        /// <summary>
        /// Datenbankschlüssel
        /// </summary>
        public int ImageId { get; set; }

        [S.StringLength(1000)]
        public string Caption
        {
            get;
            set;
        }

        public DateTime Created
        {
            get;
            set;
        }

        public int HightInPix
        {
            get;
            set;
        }

        public byte[] Img
        {
            get;
            set;
        }

        public int WidhtInPix
        {
            get;
            set;
        }
    }
}
