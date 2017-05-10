//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 5.6.2016
//
//  Projekt.......: KeplerBI.DB
//  Name..........: AsteroidsCo.cs
//  Aufgabe/Fkt...: Implementierung des Asteroiden- Repositories
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
//  Autor.........: Martin Korneffel (mko)
//  Datum.........: 4.4.2017
//  Änderungen....: GetMinMaxDiameter implementiert
//
//</unit_history>
//</unit_header>        

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using mko.BI.Bo;

namespace KeplerBI.DB.NaturalCelesticalBodies.Repositories
{
    public class AsteroidsCo : KeplerBI.NaturalCelesticalBodies.Repositories.IAsteroidsCo
    {
        KeplerDBContext _ctx;

        public AsteroidsCo(KeplerDBContext ctx)
        {
            _ctx = ctx;
        }

        public void BulkInsertOff()
        {
            _ctx.Configuration.AutoDetectChangesEnabled = true;
        }

        public void BulkInsertOn()
        {
            _ctx.Configuration.AutoDetectChangesEnabled = false;
        }

        public KeplerBI.NaturalCelesticalBodies.Repositories.IAsteroidsCo_FilteredSortedSetBuilder createFiltertedSortedSetBuilder()
        {
            return new FileredSortedSetBuilder(_ctx);
        }       

        public bool ExistsBo(string id)
        {
            return _ctx.CelesticalBodies.OfType<Asteroid>().Any(r => r.Name == id);
        }

        public KeplerBI.NaturalCelesticalBodies.IAsteroid GetBo(string id)
        {
            return _ctx.CelesticalBodies.OfType<Asteroid>().First(r => r.Name == id);
        }

        public Interval<double> GetMinMaxDiameter()
        {
            var min = _ctx.CelesticalBodies.OfType<Asteroid>().Min(r => r.EquatorialDiameterInKilometer);
            var max = _ctx.CelesticalBodies.OfType<Asteroid>().Max(r => r.EquatorialDiameterInKilometer);

            return new Interval<double>(min, max);
        }

        public Tuple<Interval<double>, string> GetMinMaxRng(string ColName)
        {
            switch (ColName)
            {
                case "Diameter":
                    {
                        var min = _ctx.CelesticalBodies.OfType<Asteroid>().Min(r => r.EquatorialDiameterInKilometer);
                        var max = _ctx.CelesticalBodies.OfType<Asteroid>().Max(r => r.EquatorialDiameterInKilometer);

                        return Tuple.Create(Interval.Create(min, max), "km");
                    }
                case "Albedo":
                    {
                        var min = _ctx.CelesticalBodies.OfType<Asteroid>().Min(r => r.Albedo);
                        var max = _ctx.CelesticalBodies.OfType<Asteroid>().Max(r => r.Albedo);

                        return Tuple.Create(Interval.Create(min, max), "");
                    }
                case "SemiMajorAxisLength":
                    {
                        var min = _ctx.CelesticalBodies.OfType<Asteroid>().Min(r => r.Orbit.SemiMajorAxisInKilometer);
                        var max = _ctx.CelesticalBodies.OfType<Asteroid>().Max(r => r.Orbit.SemiMajorAxisInKilometer);

                        return Tuple.Create(Interval.Create(min, max), "km");
                    }
                case "Velocity":
                    {
                        var min = _ctx.CelesticalBodies.OfType<Asteroid>().Min(r => r.Orbit.MeanVelocitiOfCirculationInKmPerSec);
                        var max = _ctx.CelesticalBodies.OfType<Asteroid>().Max(r => r.Orbit.MeanVelocitiOfCirculationInKmPerSec);

                        return  Tuple.Create(Interval.Create(min, max), "KmPerSec");
                    }
                default:
                    throw new ArgumentException(Properties.Resources.AsteroidsCo_GetMinMaxRng + ColName);
            }
        }

        

        public class FileredSortedSetBuilder : KeplerBI.NaturalCelesticalBodies.Repositories.IAsteroidsCo_FilteredSortedSetBuilder
        {
            KeplerDBContext ctx;
            IQueryable<Asteroid> query;
            List<mko.BI.Repositories.DefSortOrder<Asteroid>> SortOrders = new List<mko.BI.Repositories.DefSortOrder<Asteroid>>();

            public FileredSortedSetBuilder(KeplerDBContext ctx)
            {
                this.ctx = ctx;

                // Mittels AsNoTracking() wird das ChangeTracking ausgeschaltet. Sinnvoll für ein 
                // readonly Dataset.
                query = ctx.CelesticalBodies.OfType<Asteroid>().AsNoTracking();
            }

            int? toSkip;
            int? Top;

            public void defSkip(int count)
            {
                toSkip = count;
            }

            public void defTake(int count)
            {
                Top = count;
            }

            public void defSemiMajorAxisLengthRange(mko.Newton.Length min, mko.Newton.Length max)
            {
                var minKm = mko.Newton.Length.Kilometer(min).Vector[0];
                var maxKm = mko.Newton.Length.Kilometer(max).Vector[0];

                query = query.Where(r => minKm <= r.Orbit.SemiMajorAxisInKilometer && r.Orbit.SemiMajorAxisInKilometer <= maxKm);
            }

            public void defAequatorialDiameterRange(mko.Newton.Length minDiammeter, mko.Newton.Length maxDiammeter)
            {
                double min = mko.Newton.Length.Kilometer(minDiammeter).Vector[0];
                double max = mko.Newton.Length.Kilometer(maxDiammeter).Vector[0];
                query = query.Where(r => min <= r.EquatorialDiameterInKilometer && r.EquatorialDiameterInKilometer <= max);
            }

            public void defMassRange(mko.Newton.Mass minMass, mko.Newton.Mass maxMass)
            {
                double min = mko.Newton.Mass.EarthMasses(minMass).Value;
                double max = mko.Newton.Mass.EarthMasses(maxMass).Value;

                query = query.Where(r => min <= r.MassInEarthmasses && r.MassInEarthmasses <= max);
            }

            public void OrderByAequatorialDiameter(bool descending)
            {
                SortOrders.Add(new mko.BI.Repositories.DefSortOrderCol<Asteroid, double>(r => r.EquatorialDiameterInKilometer, descending));
            }

            public void OrderByMass(bool descending)
            {
                SortOrders.Add(new mko.BI.Repositories.DefSortOrderCol<Asteroid, double>(r => r.MassInEarthmasses, descending));
            }

            public void OrderBySemiMajorAxisLength(bool descending)
            {
                SortOrders.Add(new mko.BI.Repositories.DefSortOrderCol<Asteroid, double>(r => r.Orbit.SemiMajorAxisInKilometer, descending));
            }

            public mko.BI.Repositories.Interfaces.IFilteredSortedSet<KeplerBI.NaturalCelesticalBodies.IAsteroid> GetSet()
            {
                if (!SortOrders.Any())
                {
                    OrderBySemiMajorAxisLength(false);
                }               

                return new mko.BI.Repositories.FilteredSortedSet<Asteroid>(query, SortOrders, toSkip ?? -1, Top ?? -1);
                
            }

            public void defAlbedoRange(double begin, double end)
            {
                query = query.Where(r => r.Albedo >= begin && r.Albedo <= end);
            }

            public void OrderByAlbedo(bool descending)
            {
                SortOrders.Add(new mko.BI.Repositories.DefSortOrderCol<Asteroid, double>(r => r.Albedo, descending));
            }

            public void defNameLike(string Pattern)
            {
                if (Pattern.StartsWith("*"))
                {
                    if (Pattern.EndsWith("*"))
                    {
                        Pattern = Pattern.Replace("*", "");
                        query = query.Where(r => r.Name.Contains(Pattern));
                    } else
                    {
                        Pattern = Pattern.Replace("*", "");
                        query = query.Where(r => r.Name.EndsWith(Pattern));
                    }
                    
                } else
                {
                    Pattern = Pattern.Replace("*", "");
                    query = query.Where(r => r.Name.StartsWith(Pattern));
                }
                
            }
        }
    }   

}
