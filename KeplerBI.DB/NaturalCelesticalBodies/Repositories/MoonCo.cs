using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NCB = KeplerBI.DB.NaturalCelesticalBodies;


namespace KeplerBI.DB.NaturalCelesticalBodies.Repositories
{
    public class MoonCo : KeplerBI.NaturalCelesticalBodies.Repositories.IMoonsCo
    {
        KeplerDBContext _ctx;

        internal MoonCo(KeplerDBContext ctx)
        {
            _ctx = ctx;
        }

     
        public bool ExistsBo(string id)
        {
            return _ctx.CelesticalBodies.OfType<NCB.Moon>().Any(r => r.Name == id);
            
        }

        public KeplerBI.NaturalCelesticalBodies.IMoon GetBo(string id)
        {
            return _ctx.CelesticalBodies.OfType<NCB.Moon>().First(r => r.Name == id);            
        }

        public KeplerBI.NaturalCelesticalBodies.Repositories.IMoonsCo_FilteredAndSortedSetBuilder createNewFilteredSortedSetBuilder()
        {
            return new FilteredAndSortedSetBuilder(_ctx);
        }

        public class FilteredAndSortedSetBuilder : KeplerBI.NaturalCelesticalBodies.Repositories.IMoonsCo_FilteredAndSortedSetBuilder
        {
            IQueryable<Moon> query;
            List<mko.BI.Repositories.DefSortOrder<Moon>> SortOrders = new List<mko.BI.Repositories.DefSortOrder<Moon>>();
            KeplerDBContext _ctx;

            internal FilteredAndSortedSetBuilder(KeplerDBContext ctx)
            {
                _ctx = ctx;
                query = ctx.CelesticalBodies.OfType<Moon>();
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
                SortOrders.Add(new mko.BI.Repositories.DefSortOrderCol<Moon, double>(r => r.EquatorialDiameterInKilometer, descending));
            }

            public void OrderByMass(bool descending)
            {
                SortOrders.Add(new mko.BI.Repositories.DefSortOrderCol<Moon, double>(r => r.MassInEarthmasses, descending));
            }

            public void OrderBySemiMajorAxisLength(bool descending)
            {
                SortOrders.Add(new mko.BI.Repositories.DefSortOrderCol<Moon, double>(r => r.Orbit.SemiMajorAxisInKilometer, descending));
            }

            public mko.BI.Repositories.Interfaces.IFilteredSortedSet<KeplerBI.NaturalCelesticalBodies.IMoon> GetSet()
            {
                if (!SortOrders.Any())
                {
                    OrderBySemiMajorAxisLength(false);
                }
                return new mko.BI.Repositories.FilteredSortedSet<Moon>(query, SortOrders, toSkip ?? -1, Top ?? -1);
            }

            public void defPlanet(string PlanetName)
            {
                var planet = _ctx.CelesticalBodies.FirstOrDefault(r => r.Name == PlanetName);
                if (planet != null)
                {
                    query = query.Where(r => r.Orbit.CentralBody.ID == planet.ID);
                }
                else
                {
                    throw new ArgumentException(mko.TraceHlp.FormatErrMsg(this, "defPlanet", "Der Planet " + PlanetName + " existiert nicht"));
                }                
            }

            public void defSemiMajorAxisLengthRange(mko.Newton.Length min, mko.Newton.Length max)
            {
                var minKm = mko.Newton.Length.Kilometer(min).Vector[0];
                var maxKm = mko.Newton.Length.Kilometer(max).Vector[0];

                query = query.Where(r => minKm <= r.Orbit.SemiMajorAxisInKilometer && r.Orbit.SemiMajorAxisInKilometer <= maxKm);

            }

            public void defNameLike(string Pattern)
            {
                query = query.Where(r => r.Name.Contains(Pattern));
            }
        }

    }   

}
