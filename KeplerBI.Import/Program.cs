//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 6.6.2016
//
//  Projekt.......: KeplerBI.Imports
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

namespace KeplerBI.Import
{
    public class Program
    {
        const string asteroidsCsv = "asteroidsCsv";
        const string createBsicInf = "createBesicInf";

        public static void Main(string[] args)
        {           

            using (var ctx = new KeplerBI.DB.AstroCatalog())
            {
                if(args.Contains(createBsicInf)){
                    KeplerBI.Dataimport.CreateBasicInformations.DoIt(ctx);
                }
                

                if (args.Contains(asteroidsCsv))
                {
                    var filenameEtc = args.SkipWhile(r => r != asteroidsCsv);
                    if (filenameEtc.Any())
                    {
                        string filename = filenameEtc.First();                       

                        var aimport = new Dataimport.AsteroidImport(ctx);
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
