using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.NaturalCelesticalBodies.Repositories
{
    public class PlanetCo : KeplerBI.NaturalCelesticalBodies.Repositories.PlanetsCo // mko.BI.Repositories.BoCoBase<Planet, string>
    {
        KeplerDBContext ORM;        


        public PlanetCo(KeplerDBContext ORM)
        {
            this.ORM = ORM; 
        }  

        public override void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public override void SubmitChanges()
        {
            ORM.SaveChanges();
        }

        public override IQueryable<KeplerBI.NaturalCelesticalBodies.IPlanet> BoCollection
        {
            get { return ORM.CelesticalBodies.OfType<Planet>(); }
        }

        public override KeplerBI.NaturalCelesticalBodies.IPlanet CreateBo()
        {
            return ORM.CelesticalBodies.Create<Planet>();
        }

        public override void AddToCollection(KeplerBI.NaturalCelesticalBodies.IPlanet entity)
        {
            ORM.CelesticalBodies.Add((Planet)entity);
        }

        public override void RemoveFromCollection(KeplerBI.NaturalCelesticalBodies.IPlanet entity)
        {
            var e = ORM.CelesticalBodies.Single(r => r.Name == entity.Name);
            ORM.CelesticalBodies.Remove(e);
        }

        public override Func<KeplerBI.NaturalCelesticalBodies.IPlanet, bool> GetBoIDTest(string id)
        {
            return r => r.Name == id;
        }

        public override KeplerBI.NaturalCelesticalBodies.IPlanet CreateBoAndAddToCollection()
        {
            var bo = CreateBo();
            AddToCollection(bo);
            return bo;
        }

    }
}
