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
        /// Befehl zum neu Anlegen der KeplerBiDB
        /// </summary>
        const string createDb = "createDB";

        /// <summary>
        /// Speicherort der Asteroiden.csv- Datei
        /// </summary>
        const string asteroidsCsv = "asteroidsCsv";

        /// <summary>
        /// Befehl zum Erzeugen der Basis- Informationen
        /// </summary>
        const string initDB = "initDB";


        public static void Main(string[] args)
        {
            try
            {
                using (var ctx = new KeplerBI.DB.KeplerDBContext())
                {
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("KeplerBI, Tools");
                    Console.WriteLine("(c) Martin Korneffel, Stuttgart 2016");
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("Kommandozeile: ");
                    Console.WriteLine(@"\>DB.Kepler.EF60.tools [command [parameter]]");
                    Console.WriteLine("Kommandos: ");
                    Console.WriteLine("{0,-22:s} {1:s}", createDb, "Datenbank neu anlegen, falls noch nicht existiert");
                    Console.WriteLine("{0,-22:s} {1:s}", initDB, "Datenbank mit Basidaten initialisieren");
                    Console.WriteLine("{0,-22:s} {1:s}", KeplerBI.Config.Parameters.defLocationOfPics, "Dateiverzeichnis mit Bildern von Himmelskoerpern");
                    Console.WriteLine("{0,-22:s} {1:s}", asteroidsCsv, "Asteroiden aus einer CSV- Datei importieren");

                    var astroCatalog = new KeplerBI.DB.AstroCatalog(ctx);
                    var astroCatalogConfig = new KeplerBI.DB.AstroCatalogConfig(ctx);                    

                    if (args.Contains(createDb))
                    {
                        // Datenbank neu anlegen. 
                        Console.WriteLine("Neue KeplerBI anlegen unter " + ctx.Database.Connection.ConnectionString);

                        KeplerBI.DB.DBUtil.CreateDB(ctx);

                        Console.WriteLine("Datenbank erfolgreich angelegt");
                    }

                    if (args.Contains(KeplerBI.Config.Parameters.defLocationOfPics))
                    {
                        Console.WriteLine("Definieren des Dateiverzeichnisses mit den Bilddaten");

                        var filenameEtc = args.SkipWhile(r => r != KeplerBI.Config.Parameters.defLocationOfPics).Skip(1);
                        if (filenameEtc.Any())
                        {
                            var astroCfg = astroCatalogConfig;
                            var locPics = filenameEtc.First();
                            astroCfg.defLocationOfPics(locPics);
                        }

                        Console.WriteLine("Dateiverzeichnis mit Bilddaten definiert");
                    }

                    if (args.Contains(initDB))
                    {
                        Console.WriteLine("Neue KeplerBI initialisieren mit Basidaten : " + ctx.Database.Connection.ConnectionString);

                        KeplerBI.DB.DBUtil.InitCelesticalBodyTypes(ctx);
                        KeplerBI.Dataimport.CreateBasicInformations.DoIt(astroCatalog);

                        Console.WriteLine("Initialisierung erfolgreich");
                    }


                    if (args.Contains(asteroidsCsv))
                    {
                        mko.Newton.Init.Do();
                        var filenameEtc = args.SkipWhile(r => r != asteroidsCsv).Skip(1);
                        if (filenameEtc.Any())
                        {
                            string filename = filenameEtc.First();

                            Console.WriteLine("Importieren der Asteroiden aus der CSV- Datei (NASA- Tabelle): " + filename);
                            Console.WriteLine("Zieldatenbank: " + ctx.Database.Connection.ConnectionString);


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
            catch (Exception ex)
            {
                Console.WriteLine("Ein Fehler ist aufgetreten: " + mko.ExceptionHelper.FlattenExceptionMessages(ex));
            }
        }
    }
}
