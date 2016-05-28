using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeplerBI.MVC.Controllers
{
    public class PlanetsController : Controller
    {
        KeplerBI.IAstroCatalog catalog;

        /// <summary>
        /// Zugriff auf astronomischen Katalog via Dependency- Injection
        /// </summary>
        /// <param name="catalog"></param>
        public PlanetsController(KeplerBI.IAstroCatalog catalog)
        {
            this.catalog = catalog;
        }

        // GET: Planets
        public ActionResult Index()
        {
            var fltBld = catalog.Planets.createFiltertedSortedSetBuilder();            

            var queryOptions = Request.QueryString;

            // Filter- und Sortierkriterien aus dem Querystring laden
            

            return View(fltBld.GetSet());
        }
    }
}