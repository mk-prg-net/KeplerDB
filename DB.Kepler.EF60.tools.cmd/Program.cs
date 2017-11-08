//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 15.11.2016
//
//  Projekt.......: DB.Kepler.EF60.tools.cmd
//  Name..........: Program.cs
//  Aufgabe/Fkt...: Installationsroutine und Füllroutine für die 
//                  Datenbank.
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
//  Autor.........: Martin Korneffel (mko)
//  Datum.........: 9.8.2017
//  Änderungen....: Argument Datenbankname hinzugefügt
//
//</unit_history>
//</unit_header>        

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Kepler.EF60.tools.cmd
{
    class Program
    {
        const string serverNameArg = "serverName";

        const string databaseNameArg = "databaseName";

        /// Befehl zum neu Anlegen der KeplerBiDB
        /// </summary>
        const string createDbArg = "createDB";

        /// <summary>
        /// Speicherort der Asteroiden.csv- Datei
        /// </summary>
        const string asteroidsCsvArg = "asteroidsCsv";

        /// <summary>
        /// Befehl zum Erzeugen der Basis- Informationen
        /// </summary>
        const string initDBArg = "initDB";


        const string createSolarSysPlanetsArg = "createSolarSysPlanets";


        static bool checkParameter(string[] args)
        {
            for (int i = 0, argc = args.Count(); i < argc; i++)
            {
                switch (args[i])
                {
                    case createDbArg:
                        break;
                    case initDBArg:
                        break;
                    case createSolarSysPlanetsArg:
                        break;
                    case serverNameArg:
                        {
                            i++;
                            if (i >= argc)
                            {
                                Console.WriteLine("Fehler: Parameter " + serverNameArg + " erfordert einen UNC- Namen für einen Datenbankserver");
                                return false;
                            }

                        }break;
                    case databaseNameArg:
                        {
                            i++;
                            if (i >= argc)
                            {
                                Console.WriteLine("Fehler: Parameter " + databaseNameArg + " erfordert einen Datenbank- Namen");
                                return false;
                            }

                        }
                        break;

                    case asteroidsCsvArg:
                        {
                            i++;
                            if (i >= argc)
                            {
                                Console.WriteLine("Fehler: Parameter " + asteroidsCsvArg + " erfordert einen Pfad auf die Asteroiden- csv- Datei");
                                return false;
                            }
                        } break;
                    default:
                        {
                            Console.WriteLine("Fehler: unbekannter Parameter " + args[i]);
                            return false;
                        }

                }
            }
            return true;
        }


        static bool Canceled = false;

        /// <summary>
        /// Eventhandler, der gefeuert wird, wenn der Benutzer Ctrl+c drückt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            string msg = mko.TraceHlp.FormatInfoMsg("Programm", "Console_CancelKeyPress", "Execution will be canceled");

            Debug.WriteLine(msg);
            Console.WriteLine(msg);

            // Process Fortsetzen = e.Cancel == true
            // siehe https://msdn.microsoft.com/en-us/library/system.console.cancelkeypress.aspx
            e.Cancel = true;

            Canceled = true;
        }



        static void Main(string[] args)
        {
            Console.CancelKeyPress += Console_CancelKeyPress;

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("KeplerDB, Tools");
            Console.WriteLine("(c) Martin Korneffel, Stuttgart 2016");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Kommandozeile: ");
            Console.WriteLine(@"\>DB.Kepler.EF60.tools [command [parameter]]");
            Console.WriteLine("Kommandos: ");
            Console.WriteLine("{0,-22:s} {1:s}", serverNameArg, "UNC- Name für die SQL- Serverinstanz");
            Console.WriteLine("{0,-22:s} {1:s}", databaseNameArg, "Name der Kepler- Datenbank auf dem Server");
            Console.WriteLine("{0,-22:s} {1:s}", createDbArg, "Datenbank neu anlegen, falls noch nicht existiert");
            Console.WriteLine("{0,-22:s} {1:s}", initDBArg, "Datenbank mit Basidaten initialisieren");
            Console.WriteLine("{0,-22:s} {1:s}", createSolarSysPlanetsArg, "Sonne, Planeten und Monde anlegen");
            Console.WriteLine("{0,-22:s} {1:s}", asteroidsCsvArg, "Asteroiden aus einer CSV- Datei importieren");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Zum Beenden bitte Ctrl+C druecken");


            if (checkParameter(args))
            {
                using (var ctx = new KeplerDBEntities())
                {
                    if (args.Contains(serverNameArg) || args.Contains(databaseNameArg))
                    {

                        string connString = ctx.Database.Connection.ConnectionString;
                        var bld = new System.Data.SqlClient.SqlConnectionStringBuilder(connString);

                        if (args.Contains(serverNameArg))
                        {
                            var param = args.SkipWhile(r => r != serverNameArg);
                            string dbServer = param.Skip(1).First();
                            bld.DataSource = dbServer;
                        }

                        if (args.Contains(databaseNameArg))
                        {
                            var param = args.SkipWhile(r => r != databaseNameArg);
                            string arg = param.Skip(1).First();
                            bld.InitialCatalog = arg;
                        }

                        ctx.Database.Connection.ConnectionString = bld.ToString();
                    }



                    if (args.Contains(createDbArg) && !Canceled)
                    {
                        Console.WriteLine("Neue KeplerDB anlegen unter " + ctx.Database.Connection.ConnectionString);

                        // Datenbank neu anlegen. 
                        KeplerDBInstaller.CreateDB(ctx);

                        Console.WriteLine("Datenbank erfolgreich angelegt");
                    }

                    if (args.Contains(initDBArg) && !Canceled)
                    {
                        Console.WriteLine("Neue KeplerDB initialisieren mit Basidaten : " + ctx.Database.Connection.ConnectionString);

                        KeplerDBInstaller.InitBaseTables(ctx);

                        Console.WriteLine("Initialisierung erfolgreich");
                    }

                    if (args.Contains(createSolarSysPlanetsArg) && !Canceled)
                    {
                        Console.WriteLine("In KeplerDB Sonne, Planeten und Monde anlegen: " + ctx.Database.Connection.ConnectionString);

                        KeplerDBInstaller.FillDBWithStarsPlanetsAndMoons(ctx);

                        Console.WriteLine("Sonne, Planeten und Monde erfolgreich angelegt");
                    }

                    if (args.Contains(asteroidsCsvArg) && !Canceled)
                    {
                        var filenameEtc = args.SkipWhile(r => r != asteroidsCsvArg).Skip(1);

                        if (filenameEtc.Any())
                        {
                            string filename = filenameEtc.First();
                            Console.WriteLine("Importieren der Asteroiden aus der CSV- Datei (NASA- Tabelle): " + filename);
                            Console.WriteLine("Zieldatenbank: " + ctx.Database.Connection.ConnectionString);
                            try
                            {
                                mko.Newton.Init.Do();


                                // Datei öffnen
                                System.IO.StreamReader reader = new System.IO.StreamReader(filename);

                                var AsteroidTyp = ctx.HimmelskoerperTypenTab.Single(e => e.Name == "Asteroid");
                                Debug.Assert(AsteroidTyp != null);

                                var Sonne = ctx.HimmelskoerperTab.Single(e => e.Name == "Sonne");
                                Debug.Assert(Sonne != null);

                                int i = 0, lines = 0;
                                // Kopfzeilen (2x) überspringen
                                reader.ReadLine();
                                reader.ReadLine();
                                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                                Console.WriteLine("# eingelesener Asteroiden:");
                                while (!reader.EndOfStream && !Canceled)
                                {
                                    string line = reader.ReadLine();
                                    lines++;

                                    if (lines % 100 == 0)
                                    {
                                        Console.Write("" + lines + " Zeilen eingelesen\r");
                                    }

                                    string[] cols = line.Split(',');

                                    if (cols.Length != 8)
                                        throw new Exception("In Zeile " + i + " ist die Anzahl der Spalten # 8");

                                    //AsteroidName,DiameterInKm,e,a,rot_per_year,albedo,rot_per_day,GM
                                    string AsteroidName = cols[0].Replace('"', ' ').Trim();

                                    AsteroidName = AsteroidName.Substring(AsteroidName.LastIndexOf(' ')).Trim();
                                    double diameterInKm;
                                    if (!double.TryParse(cols[1], out diameterInKm))
                                        diameterInKm = 0;
                                    double e;
                                    if (!double.TryParse(cols[2], out e))
                                        e = 0;
                                    double a;
                                    if (!double.TryParse(cols[3], out a))
                                        a = 0;
                                    double rot_per_year;
                                    if (!double.TryParse(cols[4], out rot_per_year))
                                        rot_per_year = 0;
                                    double albedo;
                                    if (!double.TryParse(cols[5], out albedo))
                                        albedo = 0;
                                    double rot_per_day;
                                    if (!double.TryParse(cols[6], out rot_per_day))
                                        rot_per_day = 0;
                                    double GM;
                                    if (!double.TryParse(cols[7], out GM))
                                        GM = 0;
                                    double Mass_in_Kg = GM / 6.67259e-20;

                                    // Nur Asteroiden mit vollständigen Bahn und Massedaten importieren
                                    if (a > 0 && e > 0 && rot_per_year > 0)
                                    {


                                        var Asteroid = ctx.HimmelskoerperTab.Create();

                                        //Asteroid.HimmelskoerperTyp = AsteroidTyp;
                                        Asteroid.HimmelskoerperTyp_ID = AsteroidTyp.ID;
                                        Asteroid.Name = AsteroidName;

                                        Asteroid.Masse_in_kg = Mass_in_Kg;

                                        Asteroid.Umlaufbahn = ctx.UmlaufbahnenTab.Create();
                                        Asteroid.Umlaufbahn.Laenge_grosse_Halbachse_in_km = mko.Newton.Length.Kilometer(mko.Newton.Length.AU(a) * 2.0).Vector[0];
                                        Asteroid.Umlaufbahn.Mittlere_Umlaufgeschwindigkeit_in_km_pro_sec = mko.Newton.Velocity.KilometerPerSec(mko.Newton.Length.AU(a) * Math.PI * 2, mko.Newton.Time.Days(365.0 * rot_per_year)).Vector[0];
                                        Asteroid.Umlaufbahn.Exzentritzitaet = e;
                                        Asteroid.Umlaufbahn.Umlaufdauer_in_Tagen = rot_per_year == 0.0 ? 0.0 : rot_per_year * 365.0;

                                        // Asteroid.Umlaufbahn.Zentralobjekt = Sonne;
                                        Asteroid.Umlaufbahn.Zentralobjekt_ID = Sonne.ID;

                                        Asteroid.Sterne_Planeten_MondeTab = ctx.Sterne_Planeten_MondeTab.Create();
                                        Asteroid.Sterne_Planeten_MondeTab.Aequatordurchmesser_in_km = diameterInKm;
                                        Asteroid.Sterne_Planeten_MondeTab.Rotationsperiode_in_Stunden = rot_per_day == 0.0 ? 0.0 : rot_per_day;

                                        ctx.HimmelskoerperTab.Add(Asteroid);

                                        if (i % 100 == 0)
                                            try
                                            {
                                                Console.Write("" + i + " Asteroiden eingelesen\r");
                                                ctx.SaveChanges();
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine("" + i + " Asteroiden eingelesen und eine Ausnahme aufgetreten: " + mko.ExceptionHelper.FlattenExceptionMessages(ex));
                                            }
                                        i++;
                                    }
                                }

                                try
                                {
                                    ctx.SaveChanges();
                                    Console.WriteLine("" + i + " Asteroiden insgesamt eingelesen");

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("" + i + " Asteroiden insgesamt eingelesen und eine Ausnahme beim Sichern aufgetreten: " + mko.ExceptionHelper.FlattenExceptionMessages(ex));
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Eine allgemeine Ausnahme ist aufgetreten: " + mko.ExceptionHelper.FlattenExceptionMessages(ex));
                            }
                        }
                    }
                }
            }
        }
    }
}
