using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.NaturalCelesticalBodies.Repositories
{
    public class CometsCo : KeplerBI.NaturalCelesticalBodies.Repositories.CometsCo
    {
        KeplerDBContext ORM;

        public CometsCo(KeplerDBContext ORM)
        {
            this.ORM = ORM;
        }

        public override IQueryable<KeplerBI.NaturalCelesticalBodies.IComet> BoCollection
        {
            get { return ORM.CelesticalBodies.OfType<Comet>(); }
        }

        public override KeplerBI.NaturalCelesticalBodies.IComet CreateBo()
        {
            return ORM.CelesticalBodies.Create<Comet>();
        }

        public override void AddToCollection(KeplerBI.NaturalCelesticalBodies.IComet entity)
        {
            ORM.CelesticalBodies.Add((Comet)entity);
        }

        public override void RemoveFromCollection(KeplerBI.NaturalCelesticalBodies.IComet entity)
        {
            ORM.CelesticalBodies.Remove((Comet)entity);
        }

        public override void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public override void SubmitChanges()
        {
            ORM.SaveChanges();
        }

        public override KeplerBI.NaturalCelesticalBodies.IComet CreateBoAndAddToCollection()
        {
            var bo = CreateBo();
            AddToCollection(bo);
            return bo;
        }

    }
}
