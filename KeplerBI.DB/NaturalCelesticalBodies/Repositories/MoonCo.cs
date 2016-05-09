using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.NaturalCelesticalBodies.Repositories
{
    public class MoonCo : KeplerBI.NaturalCelesticalBodies.Repositories.MoonsCo // mko.BI.Repositories.BoCoBase<Moon, string>
    {

        KeplerDBContext ORM;
        public MoonCo(KeplerDBContext ORM)            
        {
            this.ORM = ORM;
        }

        public override IQueryable<KeplerBI.NaturalCelesticalBodies.IMoon> BoCollection
        {
            get { 
                return ORM.CelesticalBodies.OfType<Moon>(); 
            }
        }

        public override KeplerBI.NaturalCelesticalBodies.IMoon CreateBo()
        {
            return ORM.CelesticalBodies.Create<Moon>();
        }

        public override void AddToCollection(KeplerBI.NaturalCelesticalBodies.IMoon entity)
        {
            // Liskov verletzt !
            ORM.CelesticalBodies.Add((Moon)entity);
        }

        public override void RemoveFromCollection(KeplerBI.NaturalCelesticalBodies.IMoon entity)
        {
            var e = ORM.CelesticalBodies.Single(r => r.Name == entity.Name);
            ORM.CelesticalBodies.Remove(e);
        }

        public override void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public override void SubmitChanges()
        {
            ORM.SaveChanges();
        }

        public override Func<KeplerBI.NaturalCelesticalBodies.IMoon, bool> GetBoIDTest(string id)
        {
            return r => r.Name == id;
        }

        public override KeplerBI.NaturalCelesticalBodies.IMoon CreateBoAndAddToCollection()
        {
            var bo = CreateBo();
            AddToCollection(bo);
            return bo;
        }


        public override mko.Algo.Interval<double> DiameterFlt
        {
            get;            
            set;
            
        }

        public override bool DiameterFilterOn
        {
            get;            
            set;
            
        }
    }
}
