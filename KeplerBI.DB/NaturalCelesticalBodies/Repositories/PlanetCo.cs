using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NCB = KeplerBI.DB.NaturalCelesticalBodies;

namespace KeplerBI.DB.NaturalCelesticalBodies.Repositories
{
    public class PlanetCo : KeplerBI.NaturalCelesticalBodies.Repositories.IPlanetsCo
    {
        KeplerDBContext _ctx;

        public PlanetCo(KeplerDBContext ctx)
        {
            _ctx = ctx;
        }

        public bool ExistsBo(string id)
        {
            return _ctx.CelesticalBodies.OfType<NCB.Planet>().Any(r => r.Name == id);

        }

        public KeplerBI.NaturalCelesticalBodies.IPlanet GetBo(string id)
        {
            return _ctx.CelesticalBodies.OfType<NCB.Planet>().First(r => r.Name == id);
        }

        public KeplerBI.NaturalCelesticalBodies.Repositories.IPlanetsCo_FilteredSortedSetBuilder createFiltertedSortedSetBuilder()
        {
            return new FilteredSortedSetBuilder(_ctx);
        }

        public class FilteredSortedSetBuilder : KeplerBI.NaturalCelesticalBodies.Repositories.IPlanetsCo_FilteredSortedSetBuilder
        {

            IQueryable<Planet> query;
            List<mko.BI.Repositories.DefSortOrder<Planet>> SortOrders = new List<mko.BI.Repositories.DefSortOrder<Planet>>();

            internal FilteredSortedSetBuilder(KeplerDBContext ctx)
            {
                query = ctx.CelesticalBodies.OfType<Planet>();
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
                SortOrders.Add(new mko.BI.Repositories.DefSortOrderCol<Planet, double>(r => r.EquatorialDiameterInKilometer, descending));
            }

            public void OrderByMass(bool descending)
            {
                SortOrders.Add(new mko.BI.Repositories.DefSortOrderCol<Planet, double>(r => r.MassInEarthmasses, descending));
            }

            public void OrderBySemiMajorAxisLength(bool descending)
            {
                throw new NotImplementedException();
            }

            public mko.BI.Repositories.Interfaces.IFilteredSortedSet<KeplerBI.NaturalCelesticalBodies.IPlanet> GetSet()
            {
                return new mko.BI.Repositories.FilteredSortedSet<Planet>(query, SortOrders);
            }
        }


    }
}
