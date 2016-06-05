using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kepler.WebApi.Controllers
{
    public class SPMMvcController : Controller
    {

        DB.Kepler.EF60.KeplerDBEntities ctx = new DB.Kepler.EF60.KeplerDBEntities();

        public SPMMvcController()
        {
            mko.Newton.Init.Do();

        }

        // GET: SPMMvc
        public ActionResult Index()
        {

            var Planeten = ctx.Sterne_Planeten_MondeTab
                            .Where(r => r.Himmelskoerper.HimmelskoerperTyp.Name == "Planet")
                            .OrderBy(r => r.Himmelskoerper.Umlaufbahn.Laenge_grosse_Halbachse_in_km);


            return View(Planeten);
        }

        public ActionResult AlleMondeVon(string NamePlanet)
        {
            var Monde = ctx.Sterne_Planeten_MondeTab.Where(r => r.Himmelskoerper.Umlaufbahn.Zentralobjekt.Name == NamePlanet);

            return View(new Models.SPMMvc.PlanetUndMonde(){ 
                Monde = Monde, 
                Planet = ctx.Sterne_Planeten_MondeTab.Single(r => r.Himmelskoerper.Name == NamePlanet)});

        }
    }
}