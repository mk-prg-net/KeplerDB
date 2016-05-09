using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.SpaceShips.Repositories
{
    public class SpaceShipsCo : KeplerBI.SpaceShips.Repositories.SpaceShipsCo
    {
        KeplerDBContext ORM;

        public SpaceShipsCo(KeplerDBContext ORM)
        {
            this.ORM = ORM;
        }


        public override IQueryable<KeplerBI.SpaceShips.ISpaceShip> BoCollection
        {
            get { return ORM.CelesticalBodies.OfType<SpaceShip>(); }
        }

        public override KeplerBI.SpaceShips.ISpaceShip CreateBo()
        {
            return ORM.CelesticalBodies.Create<SpaceShip>();
        }

        public override void AddToCollection(KeplerBI.SpaceShips.ISpaceShip entity)
        {
            ORM.CelesticalBodies.Add((SpaceShip)entity);
        }

        public override void RemoveFromCollection(KeplerBI.SpaceShips.ISpaceShip entity)
        {
            ORM.CelesticalBodies.Remove((SpaceShip)entity);
        }

        public override void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public override void SubmitChanges()
        {
            ORM.SaveChanges();
        }



        public override KeplerBI.SpaceShips.ISpaceShip CreateBoAndAddToCollection()
        {
            var bo = CreateBo();
            AddToCollection(bo);
            return bo;
        }
    }
}
