using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Repositories
{
    public class CelesticalBodySystemsCo : KeplerBI.Repositories.ICelesticslBodySystemsCo
    {
        KeplerDBContext _ctx;
        public CelesticalBodySystemsCo(KeplerDBContext ctx)
        {
            _ctx = ctx;
        }

        public bool ExistsBo(KeplerBI.NaturalCelesticalBodies.INaturalCelesticalBody id)
        {
            return _ctx.CelesticalBodySystems.Any(r => r.CentralBody.Name == id.Name);
        }

        public ICelesticalBodySystem GetBo(KeplerBI.NaturalCelesticalBodies.INaturalCelesticalBody id)
        {
            return _ctx.CelesticalBodySystems.First(r => r.CentralBody.Name == id.Name);
        }
    }
}
