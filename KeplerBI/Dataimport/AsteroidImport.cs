﻿//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 5.6.2016
//
//  Projekt.......: KeplerBI
//  Name..........: AsteroidImport.cs
//  Aufgabe/Fkt...: Importiert die Asteroiden  aus der Asteroid.csv 
//                  in den AstroCatalog
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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Dataimport
{
    public class AsteroidImport
    {
        IAstroCatalog _catalog;


        /// <summary>
        /// Event für Fortschrittsanzeige
        /// </summary>
        public event Action<int, int> ProgressInfo;

        public AsteroidImport(IAstroCatalog catalog)
        {
            _catalog = catalog;
        }

        /// <summary>
        /// Importiert die Asteroiden aus einer csv- Datei
        /// </summary>
        /// <param name="filename_csv_file_with_asteroids"></param>
        public void Import(string filename_csv_file_with_asteroids)
        {
            try
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(filename_csv_file_with_asteroids);

                var Sonne = _catalog.Stars.GetBo("Sonne");
                Debug.Assert(Sonne != null);

                int i = 0, lines = 0;
                // Kopfzeilen (2x) überspringen
                reader.ReadLine();
                reader.ReadLine();
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                Console.WriteLine("# eingelesener Asteroiden:");
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    lines++;

                    if (lines % 100 == 0 && ProgressInfo != null)
                    {
                        ProgressInfo(lines, i);
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
                        _catalog.CreateAsteroid(AsteroidName, Sonne, mko.Newton.Length.AU(a), mko.Newton.Velocity.KilometerPerSec((Math.PI * 2) * mko.Newton.Length.AU(a), mko.Newton.Time.OrbitalPeriodEarth));
                        _catalog.SubmitChanges();

                        var newAsteroid = _catalog.Asteroids.GetBo(AsteroidName);
                        newAsteroid.Albedo = albedo;
                        newAsteroid.EquatorialDiameter = mko.Newton.Length.Kilometer(diameterInKm);
                        newAsteroid.MassInEarthmasses = mko.Newton.Mass.EarthMasses(mko.Newton.Mass.Kilogram(Mass_in_Kg)).Value;

                        if (i % 100 == 0)
                        {
                            try
                            {
                                if (ProgressInfo != null)
                                {
                                    ProgressInfo(lines, i);
                                }
                                _catalog.SubmitChanges();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("" + i + " Asteroiden eingelesen und eine Ausnahme aufgetreten", ex);

                            }
                        }
                        i++;
                    }
                }

                try
                {
                    _catalog.SubmitChanges();

                    if (ProgressInfo != null)
                    {
                        ProgressInfo(lines, i);
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("" + i + " Asteroiden insgesamt eingelesen und eine Ausnahme beim Sichern aufgetreten", ex);
                }
            }

            catch (Exception ex)
            {
                throw new Exception(mko.TraceHlp.FormatErrMsg(this, "Import"), ex);
            }

        }

    }
}