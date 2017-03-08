using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeplerBI.MVC.Controllers
{
    public class AsteroidsController : Controller
    {

        KeplerBI.IAstroCatalog catalog;
        mko.RPN.Parser RPNParser = new mko.RPN.Parser();

        /// <summary>
        /// Zugriff auf astronomischen Katalog via Dependency- Injection
        /// </summary>
        /// <param name="catalog"></param>
        public AsteroidsController(KeplerBI.IAstroCatalog catalog)
        {
            this.catalog = catalog;
            mko.Newton.Init.Do();
        }


        // GET: Asteroids
        public ActionResult Index()
        {

            var fssbld = catalog.Asteroids.createFiltertedSortedSetBuilder();
            fssbld.OrderBySemiMajorAxisLength(false);

            var s = fssbld.GetSet();
            return View(s);
        }
    }
}