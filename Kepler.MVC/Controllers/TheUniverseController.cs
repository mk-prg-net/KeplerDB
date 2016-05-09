//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 23.11.2015
//
//  Projekt.......: Kepler.MVC
//  Name..........: TheUniverseController.cs
//  Aufgabe/Fkt...: Seitenweise Ausgabe 
//                  
//
//
//
//
//<unit_environment>
//------------------------------------------------------------------
//  Zielmaschine..: PC 
//  Betriebssystem: Windows 7 mit .NET 4.5
//  Werkzeuge.....: Visual Studio 2013
//  Autor.........: Martin Korneffel (mko)
//  Version 1.0...: 
//
// </unit_environment>
//
//<unit_history>
//------------------------------------------------------------------
//
//  Version.......: 1.1
//  Autor.........: Martin Korneffel (mko)
//  Datum.........: 
//  Änderungen....: 
//
//</unit_history>
//</unit_header>        
        

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Linq;

namespace Kepler.MVC.Controllers
{
    public class TheUniverseController : Controller
    {

        const int PageSize = 10;

        // GET: TheUniverse
        // Demo Paging
        // Index ruft 1. Seite auf
        public ActionResult Index()
        {
            var ctx = new DB.Kepler.EF60.KeplerDBEntities();

            var model = new Models.TheUniverse.HimmelskoerperPage()
            {
                die_Himmelskoerper_auf_dieser_Seite = ctx.HimmelskoerperTab.Take(PageSize),
                Anz_Seiten_gesamt = ctx.HimmelskoerperTab.Count()/PageSize,
                Seitennummer = 0
            };

            
            return View(model);            
        }

        public ActionResult NextPage(int PageNumber)
        {
            var ctx = new DB.Kepler.EF60.KeplerDBEntities();

            var model = new Models.TheUniverse.HimmelskoerperPage()
            {
                die_Himmelskoerper_auf_dieser_Seite = ctx.HimmelskoerperTab.OrderBy(r=> r.HimmelskoerperTyp_ID).Skip(PageNumber*PageSize).Take(PageSize),
                Anz_Seiten_gesamt = ctx.HimmelskoerperTab.Count() / PageSize,
                Seitennummer = PageNumber
            };

            return View("Index", model);
        }

        
    }
}