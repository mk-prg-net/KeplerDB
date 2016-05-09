using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.NaturalCelesticalBodies.Repositories
{
    public class AsteroidsCo : KeplerBI.NaturalCelesticalBodies.Repositories.AsteroidsCo
    {
        KeplerDBContext ORM;

        public AsteroidsCo(KeplerDBContext ORM)
        {
            this.ORM = ORM;
        }


        public override IQueryable<KeplerBI.NaturalCelesticalBodies.IAsteroid> BoCollection
        {
            get { return ORM.CelesticalBodies.OfType<Asteroid>(); }
        }

        public override KeplerBI.NaturalCelesticalBodies.IAsteroid CreateBo()
        {
            return ORM.CelesticalBodies.Create<Asteroid>();
        }

        public override void AddToCollection(KeplerBI.NaturalCelesticalBodies.IAsteroid entity)
        {
            ORM.CelesticalBodies.Add((Asteroid)entity);
        }

        public override void RemoveFromCollection(KeplerBI.NaturalCelesticalBodies.IAsteroid entity)
        {
            ORM.CelesticalBodies.Remove((Asteroid)entity);
        }

        public override void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public override void SubmitChanges()
        {
            ORM.SaveChanges();
        }


        public override KeplerBI.NaturalCelesticalBodies.IAsteroid CreateBoAndAddToCollection()
        {
            var bo = CreateBo();
            AddToCollection(bo);
            return bo;
        }

    }
}
