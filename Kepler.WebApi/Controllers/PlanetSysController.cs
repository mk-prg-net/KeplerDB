using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Data.Entity;

namespace Kepler.WebApi.Controllers
{
    public class PlanetSysController : ApiController
    {
        // GET: api/PlanetSys
        //      Liefert alle Planetensysteme aus        
        public IEnumerable<Models.PlanetSys.PlanetFix> Get()
        {
            using (var ctx = new DB.Kepler.EF60.KeplerDBEntities())            
            {
                ctx.Configuration.ProxyCreationEnabled = false;

                var Planeten = new DB.Kepler.EF60.Container.PlanetenCo(ctx);

                // Beim Zugriff alle abhängignen Objekte eines Planeten mitladen
                Planeten.LazyLoading = false;

                Planeten.DefSortOrders(new DB.Kepler.EF60.Container.PlanetenCo.SortDistanceToSun(false));

                return Planeten.GetAllBo().ToArray().Select(r => new Models.PlanetSys.PlanetFix(r));
            }            
        }

        // GET: api/PlanetSys/5
        //      Liefert Planetensystem zum Planeten mit gegebenen Namen aus 
        //public Kepler.IPlanet Get(string Name)
        //{
        //    using (var ctx = new DB.Kepler.EF60.KeplerDBEntities())
        //    {
        //        var Planeten = new DB.Kepler.EF60.Container.PlanetenCo(ctx);

        //        // Beim Zugriff alle abhängignen Objekte eines Planeten mitladen
        //        Planeten.LazyLoading = false;

        //        return  new Models.PlanetSys.PlanetFix(Planeten.BoCollection.Single(r => r.Name == Name));
        //    }
        //}

    }
}
