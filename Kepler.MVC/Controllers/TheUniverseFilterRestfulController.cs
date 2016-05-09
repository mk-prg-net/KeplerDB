using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kepler.MVC.Controllers
{
    public class TheUniverseFilterRestfulController : Controller
    {
        const int PageSize = 10;

        // GET: TheUniverse
        // Demo Paging
        // Index ruft 1. Seite auf
        public ActionResult Index()
        {

            var model = GetData(0, -1);
            return View("Index", model);

        }


        public ActionResult NextPage(int PageNumber, int TypFlt)
        {
            var model = GetData(PageNumber, TypFlt);
            return View("Index", model);
        }

        private static Models.TheUniverse.HimmelskoerperPage GetData(int PageNumber, int TypFlt)
        {
            var boCo = new DB.Kepler.EF60.Container.HimmelskoerperCo();

            if (TypFlt != -1)
            {
                boCo.TypFlt.On = false;
                boCo.TypFlt.FilterDef = (Bo.HimmelskoerperTypen)TypFlt;
                boCo.TypFlt.On = true;
            }
            else
            {
                boCo.TypFlt.On = false;
            }

            var model = new Models.TheUniverse.HimmelskoerperPage()
            {
                die_Himmelskoerper_auf_dieser_Seite = boCo.GetFilteredAndSortedListOfBo().OrderBy(r => r.HimmelskoerperTyp_ID).Skip(PageNumber * PageSize).Take(PageSize),
                Anz_Seiten_gesamt = (int)boCo.CountFilteredBo() / PageSize,
                Seitennummer = PageNumber,
                FltHimmelskoerpertyp  = boCo.TypFlt.On ? (int)boCo.TypFlt.FilterDef : -1

            };
            return model;
        }
    }
}
