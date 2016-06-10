//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 6.6.2016
//
//  Projekt.......: KeplerBI.tools.cmd
//  Name..........: Programm.cs
//  Aufgabe/Fkt...: Kommandozeilentool: Daten werden durch Assemblies erzeugt oder aus 
//                  Dateien importiert und in die KeplerBI importiert.
//                  
//                  Parameter:
//                      createBsicInf 
//                          Wenn gesetzt, dann werden Grundinformationen erzeugt und in der
//                          DB angelegt
//
//                      asteroidsCsv <Name der csv- Datei mit den Asteroidendaten aus der Nasa- Datenbank>
//                          Wenn gesetzt, dann werden Asteroidendaten aus der CSV- Datei geladen und
//                          importiert.
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

namespace KeplerBI.tools.cmd
{
    public class Program
    {
        /// <summary>
        /// Speicherort der Asteroiden.csv- Datei
        /// </summary>
        const string asteroidsCsv = "asteroidsCsv";

        /// <summary>
        /// Befehl zum Erzeugen der Basis- Informationen
        /// </summary>
        const string createBsicInf = "createBesicInf";


        public static void Main(string[] args)
        {

            using (var ctx = new KeplerBI.DB.KeplerDBContext())
            {
                var astroCatalog = new KeplerBI.DB.AstroCatalog(ctx);
                var astroCatalogConfig = new KeplerBI.DB.AstroCatalogConfig(ctx);

                if (args.Contains(KeplerBI.Config.Parameters.defLocationOfPics))
                {
                    var filenameEtc = args.SkipWhile(r => r != KeplerBI.Config.Parameters.defLocationOfPics).Skip(1);
                    if (filenameEtc.Any())
                    {
                        var astroCfg = astroCatalogConfig;
                        var locPics = filenameEtc.First();
                        astroCfg.defLocationOfPics(locPics);
                    }

                }

                if (args.Contains(createBsicInf))
                {
                    KeplerBI.Dataimport.CreateBasicInformations.DoIt(astroCatalog);
                }


                if (args.Contains(asteroidsCsv))
                {
                    var filenameEtc = args.SkipWhile(r => r != asteroidsCsv).Skip(1);
                    if (filenameEtc.Any())
                    {
                        string filename = filenameEtc.First();

                        var aimport = new Dataimport.AsteroidImport(astroCatalog);
                        aimport.ProgressInfo += (lines, asteroids) =>
                        {
                            Console.WriteLine("#Zeilen: " + lines + ", #Importierte Asteroiden: " + asteroids);
                        };

                        Console.WriteLine("Asteroidenimpoert beginnt aus " + filename);
                        aimport.Import(filename);
                    }


                }

            }

        }
    }
}
