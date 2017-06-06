//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 10.5.2017
//
//  Projekt.......: KeplerBI.RAM
//  Name..........: AsteroidsCo.cs
//  Aufgabe/Fkt...: Kurzbeschreibung
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
using KeplerBI.NaturalCelesticalBodies;
using KeplerBI.NaturalCelesticalBodies.Repositories;
using mko.BI.Bo;

namespace KeplerBI.RAM.NaturalCelesticalBodies.Repositories
{
    public class AsteroidsCo : KeplerBI.NaturalCelesticalBodies.Repositories.IAsteroidsCo
    {

        bool BulkInsert = false;


        public void BulkInsertOff()
        {
            BulkInsert = false;
        }

        public void BulkInsertOn()
        {
            BulkInsert = true;
        }

        public IAsteroidsCo_FilteredSortedSetBuilder createFiltertedSortedSetBuilder()
        {
            return new AsteroidsCoFSSBld(Asteroids.Values);
        }

        public bool ExistsBo(string id)
        {
            return Asteroids.ContainsKey(id);
        }

        public IAsteroid GetBo(string id)
        {
            return Asteroids[id];
        }

        public Interval<double> GetMinMaxDiameter()
        {
            var min = Asteroids.Values.Min(r => r.EquatorialDiameter.Vector.Length);
            var max = Asteroids.Values.Max(r => r.EquatorialDiameter.Vector.Length);

            return mko.BI.Bo.Interval.Create(min, max);
        }

        public Tuple<Interval<double>, string> GetMinMaxRng(string ColName)
        {
            double min = 0;
            double max = 0;

            switch (ColName)
            {
                case "Albedo":
                    min = Asteroids.Values.Min(r => r.Albedo);
                    max = Asteroids.Values.Max(r => r.Albedo);
                    break;
                case "EquatorialDiameter":
                    min = Asteroids.Values.Min(r => r.EquatorialDiameter.Vector.coordinates[0]);
                    max = Asteroids.Values.Max(r => r.EquatorialDiameter.Vector.coordinates[0]);
                    break;
                case "Gravity":
                    min = Asteroids.Values.Min(r => r.Gravity.Vector.coordinates[0]);
                    max = Asteroids.Values.Max(r => r.Gravity.Vector.coordinates[0]);
                    break;
                case "Mass":
                    min = Asteroids.Values.Min(r => r.Mass.Value);
                    max = Asteroids.Values.Max(r => r.Mass.Value);
                    break;
                case "MeanSurfaceTemp":
                    min = Asteroids.Values.Min(r => r.MeanSurfaceTemp);
                    max = Asteroids.Values.Max(r => r.MeanSurfaceTemp);
                    break;
                case "Orbit_SemiMajorAxisLength":
                    min = Asteroids.Values.Min(r => r.Orbit.SemiMajorAxis.Vector.coordinates[0]);
                    max = Asteroids.Values.Max(r => r.Orbit.SemiMajorAxis.Vector.coordinates[0]);
                    break;
                case "Orbit_Velocity":
                    min = Asteroids.Values.Min(r => r.Orbit.MeanVelocityOfCirculation.Vector.coordinates[0]);
                    max = Asteroids.Values.Max(r => r.Orbit.MeanVelocityOfCirculation.Vector.coordinates[0]);
                    break;
                default:
                    mko.TraceHlp.ThrowArgEx("unbekannte Spalte " + ColName);
                    break;
            }
            return Tuple.Create(mko.BI.Bo.Interval.Create(min, max), ColName);
        }

        internal Dictionary<string, Asteroid> Asteroids = new Dictionary<string, Asteroid>(1000);
    }
}
