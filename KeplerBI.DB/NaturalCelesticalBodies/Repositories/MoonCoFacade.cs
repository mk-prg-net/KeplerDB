using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.NaturalCelesticalBodies.Repositories
{
    public class MoonCoFacade : KeplerBI.NaturalCelesticalBodies.Repositories.MoonsCo 
    {
        KeplerDBContext ORM;
        MoonCo boCo;

        public MoonCoFacade(KeplerDBContext ORM)
        {
            boCo = new MoonCo(ORM);
        }

        public class DiameterFltImpl : mko.BI.Repositories.FilterFunctor<Moon, mko.Algo.Interval<double>>
        {
            public override IQueryable<Moon> filterImpl(IQueryable<Moon> srcTab)
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
                if (value) {
                    if(_DiamterFlt != null)
                      boCo.SetFilter(_DiamterFlt);
                }
                else
                {
                    if (_DiamterFlt != null)
                        boCo.RemoveFilter(_DiamterFlt);
                }
                
            }
        }

        public override IQueryable<KeplerBI.NaturalCelesticalBodies.IMoon> GetBoAll()
        {
            return boCo.GetAllBo();
        }

        public override KeplerBI.NaturalCelesticalBodies.IMoon GetBo(string id)
        {
            return boCo.GetBo(id);
        }

        public override IQueryable<KeplerBI.NaturalCelesticalBodies.IMoon> GetBoFiltered()
        {
            return boCo.GetFilteredListOfBo();
        }

        public override IQueryable<KeplerBI.NaturalCelesticalBodies.IMoon> GetBoFilteredAndSorted()
        {
            return boCo.GetFilteredAndSortedListOfBo();
        }

        public override void Delete(string id)
        {
            boCo.Delete(id);
        }

        public override void Insert(KeplerBI.NaturalCelesticalBodies.IMoon entity)
        {
            boCo.Insert((Moon)entity);
        }

        public override void SubmitChanges()
        {
            boCo.SubmitChanges();
        }
    }
}
