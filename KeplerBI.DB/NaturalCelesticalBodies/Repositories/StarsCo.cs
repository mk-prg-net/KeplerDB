using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.NaturalCelesticalBodies.Repositories
{
    public class StarsCo : KeplerBI.NaturalCelesticalBodies.Repositories.StarsCo
    {
        KeplerDBContext ORM;

        public StarsCo(KeplerDBContext ORM)
        {
            this.ORM = ORM;
        }

        public override IQueryable<KeplerBI.NaturalCelesticalBodies.IStar> BoCollection
        {
            get { return ORM.CelesticalBodies.OfType<Star>(); }
        }

        public override KeplerBI.NaturalCelesticalBodies.IStar CreateBo()
        {
            return ORM.CelesticalBodies.Create<Star>();
        }

        public override void AddToCollection(KeplerBI.NaturalCelesticalBodies.IStar entity)
        {
            ORM.CelesticalBodies.Add((Star)entity);
        }

        public override void RemoveFromCollection(KeplerBI.NaturalCelesticalBodies.IStar entity)
        {
            ORM.CelesticalBodies.Remove((Star)entity);
        }

        public override void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public override void SubmitChanges()
        {
            ORM.SaveChanges();
        }

        public override KeplerBI.NaturalCelesticalBodies.IStar CreateBoAndAddToCollection()
        {
            var bo = CreateBo();
            AddToCollection(bo);
            return bo;
        }

    }
}
