using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.NaturalCelesticalBodies.Repositories
{
    public class PlanetsCoFacade : KeplerBI.NaturalCelesticalBodies.Repositories.PlanetsCo
    {
        PlanetCo boCo;

        public PlanetsCoFacade(KeplerDBContext ORM)
        {
            boCo = new PlanetCo(ORM);
        }

        public class DiameterFltImpl : mko.BI.Repositories.FilterFunctor<Planet, mko.Algo.Interval<double>>
        {
            public override IQueryable<Planet> filterImpl(IQueryable<Planet> srcTab)
            {
                return srcTab.Where(r => r.EquatorialDiameterInKilometer > RValue.Begin && r.EquatorialDiameterInKilometer < RValue.End);

            }
        }

        DiameterFltImpl _DiamterFlt;
        public override mko.Algo.Interval<double> DiameterFlt
        {
            get
            {
                return _DiamterFlt.RValue;
            }
            set
            {
                if (DiameterFilterOn)
                    DiameterFilterOn = false;

                _DiamterFlt = new DiameterFltImpl() { RValue = new mko.Algo.Interval<double>(value.Begin, value.End) };
            }
        }

        public override bool DiameterFilterOn
        {
            get
            {
                return _DiamterFlt != null && !boCo.AllFilter.ContainsKey(_DiamterFlt);
            }
            set
            {
                if (value)
                {
                    if (_DiamterFlt != null)
                        boCo.SetFilter(_DiamterFlt);
                }
                else
                {
                    if (_DiamterFlt != null)
                        boCo.RemoveFilter(_DiamterFlt);
                }

            }
        }


        public class EarthmassFlt : mko.BI.Repositories.FilterFunctor<Planet, mko.Algo.Interval<double>>
        {
            public override IQueryable<Planet> filterImpl(IQueryable<Planet> srcTab)
            {
                return srcTab.Where(r => r.MassInEarthmasses >= RValue.Begin && r.MassInEarthmasses <= RValue.End);
            }
        }

        EarthmassFlt _EarthmassFlt;
        public override mko.Algo.Interval<double> MassInEarthmassFlt
        {
            get
            {
                return _EarthmassFlt.RValue;
            }
            set
            {
                if (MassInEarthmassFilterOn)
                    MassInEarthmassFilterOn = false;

                _EarthmassFlt = new EarthmassFlt() { RValue = new mko.Algo.Interval<double>(value.Begin, value.End) };
            }
        }

        public override bool MassInEarthmassFilterOn
        {
            get
            {
                return _EarthmassFlt != null && !boCo.AllFilter.ContainsKey(_EarthmassFlt);
            }
            set
            {
                if (value)
                {
                    if (_EarthmassFlt != null)
                        boCo.SetFilter(_EarthmassFlt);
                }
                else
                {
                    if (_EarthmassFlt != null)
                        boCo.RemoveFilter(_EarthmassFlt);
                }

            }
        }

        public override IQueryable<KeplerBI.NaturalCelesticalBodies.IPlanet> GetBoAll()
        {
            return boCo.GetAllBo();
        }

        public override KeplerBI.NaturalCelesticalBodies.IPlanet GetBo(string id)
        {
            return boCo.GetBo(id);
        }

        public override IQueryable<KeplerBI.NaturalCelesticalBodies.IPlanet> GetBoFiltered()
        {
            return boCo.GetFilteredListOfBo();
        }

        public override IQueryable<KeplerBI.NaturalCelesticalBodies.IPlanet> GetBoFilteredAndSorted()
        {
            return boCo.GetFilteredAndSortedListOfBo();
        }

        public override void Delete(string id)
        {
            boCo.Delete(id);
        }

        public override void Insert(KeplerBI.NaturalCelesticalBodies.IPlanet entity)
        {
            boCo.Insert((Planet)entity);
        }

        public override void SubmitChanges()
        {
            boCo.SubmitChanges();
        }
    }
}
