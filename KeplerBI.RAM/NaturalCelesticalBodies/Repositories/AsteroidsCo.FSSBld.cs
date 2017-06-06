//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 10.5.2017
//
//  Projekt.......: KeplerBI.RAM
//  Name..........: AsteroidsCo.FSSBld.cs
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
using mko.BI.Repositories.Interfaces;
using mko.Newton;

namespace KeplerBI.RAM.NaturalCelesticalBodies.Repositories
{
    public class AsteroidsCoFSSBld : KeplerBI.NaturalCelesticalBodies.Repositories.IAsteroidsCo_FilteredSortedSetBuilder
    {        

        public AsteroidsCoFSSBld(IEnumerable<Asteroid> Asteroids)
        {
            query = Asteroids.AsQueryable();
        }

        IQueryable<Asteroid> query;
        List<mko.BI.Repositories.DefSortOrder<Asteroid>> SortOrders = new List<mko.BI.Repositories.DefSortOrder<Asteroid>>();


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

            query = query.Where(r => minKm <= r.Orbit.SemiMajorAxis.Vector[0] && r.Orbit.SemiMajorAxis.Vector[0] <= maxKm);
        }

        public void defAequatorialDiameterRange(mko.Newton.Length minDiammeter, mko.Newton.Length maxDiammeter)
        {
            double min = mko.Newton.Length.Kilometer(minDiammeter).Vector[0];
            double max = mko.Newton.Length.Kilometer(maxDiammeter).Vector[0];
            query = query.Where(r => min <= r.EquatorialDiameter.Vector[0] && r.EquatorialDiameter.Vector[0] <= max);
        }

        public void defMassRange(mko.Newton.Mass minMass, mko.Newton.Mass maxMass)
        {
            double min = mko.Newton.Mass.EarthMasses(minMass).Value;
            double max = mko.Newton.Mass.EarthMasses(maxMass).Value;

            query = query.Where(r => min <= r.MassInEarthmasses && r.MassInEarthmasses <= max);
        }

        public void OrderByAequatorialDiameter(bool descending)
        {
            SortOrders.Add(new mko.BI.Repositories.DefSortOrderCol<Asteroid, double>(r => r.EquatorialDiameter.Vector[0], descending));
        }

        public void OrderByMass(bool descending)
        {
            SortOrders.Add(new mko.BI.Repositories.DefSortOrderCol<Asteroid, double>(r => r.MassInEarthmasses, descending));
        }

        public void OrderBySemiMajorAxisLength(bool descending)
        {
            SortOrders.Add(new mko.BI.Repositories.DefSortOrderCol<Asteroid, double>(r => r.Orbit.SemiMajorAxis.Vector[0], descending));
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
                }
                else
                {
                    Pattern = Pattern.Replace("*", "");
                    query = query.Where(r => r.Name.EndsWith(Pattern));
                }

            }
            else
            {
                Pattern = Pattern.Replace("*", "");
                query = query.Where(r => r.Name.StartsWith(Pattern));
            }

        }
    }
}
