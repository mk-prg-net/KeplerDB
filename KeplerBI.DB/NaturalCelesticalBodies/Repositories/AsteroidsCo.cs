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

using System.Data.Entity;

namespace KeplerBI.DB.NaturalCelesticalBodies.Repositories
{
    public class AsteroidsCo : KeplerBI.NaturalCelesticalBodies.Repositories.IAsteroidsCo
    {
        KeplerDBContext _ctx;

        public AsteroidsCo(KeplerDBContext ctx)
        {
            _ctx = ctx;
        }

        public KeplerBI.NaturalCelesticalBodies.Repositories.IAsteroidsCo_FilteredSortedSetBuilder createFiltertedSortedSetBuilder()
        {
            throw new NotImplementedException();
        }

        public bool ExistsBo(string id)
        {
            return _ctx.CelesticalBodies.OfType<Asteroid>().Any(r => r.Name == id);
        }

        public KeplerBI.NaturalCelesticalBodies.IAsteroid GetBo(string id)
        {
            return _ctx.CelesticalBodies.OfType<Asteroid>().First(r => r.Name == id);
        }


        public class FileredSortedSetBuilder : KeplerBI.NaturalCelesticalBodies.Repositories.IAsteroidsCo_FilteredSortedSetBuilder
        {
            KeplerDBContext ctx;
            IQueryable<Asteroid> query;
            List<mko.BI.Repositories.DefSortOrder<Asteroid>> SortOrders = new List<mko.BI.Repositories.DefSortOrder<Asteroid>>();

            int? toSkip;
            int? Top;

            public FileredSortedSetBuilder(KeplerDBContext ctx)
            {
                this.ctx = ctx;
                query = ctx.CelesticalBodies.OfType<Asteroid>();
            }

            public void defSkip(int count)
            {
                toSkip = count;
            }

            public void defTop(int count)
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
                if (toSkip.HasValue)
                {
                    query = query.Skip(toSkip.Value);
                }

                if (Top.HasValue)
                {
                    query = query.Take(Top.Value);
                }

                return new mko.BI.Repositories.FilteredSortedSet<Asteroid>(query, SortOrders);
                
            }
        }
    }   

}
