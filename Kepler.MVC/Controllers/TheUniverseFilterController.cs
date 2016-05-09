//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 23.11.2015
//
//  Projekt.......: Kepler.MVC
//  Name..........: TheUniverseFilterController.cs
//  Aufgabe/Fkt...: Seitenweise Ausgabe inklusive Filterung
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
    public class TheUniverseFilterController : Controller
    {

        const int PageSize = 10;

        // GET: TheUniverse
        // Demo Paging
        // Index ruft 1. Seite auf
        public ActionResult Index()
        {
            // Speichern des Containers mit den Geschäftsobjekten im Sitzungszustand
            // Nachteil: Server wird belastet. 
            // Vorteil:  Aufwand für Konfiguration von Filtern wird Clientseitig minimiert
            var boCo = mkoIt.Asp.WorkflowState<DB.Kepler.EF60.Container.HimmelskoerperCo>.Get(Session);

            var model = new Models.TheUniverse.HimmelskoerperPage()
            {
                die_Himmelskoerper_auf_dieser_Seite = boCo.GetAllBo().OrderBy(r=> r.HimmelskoerperTyp_ID).Take(PageSize),
                Anz_Seiten_gesamt = (int)boCo.CountAllBo() / PageSize,
                Seitennummer = 0,
                TypFlt = (int)boCo.TypFlt.FilterDef
            };


            return View(model);
        }


        public ActionResult NextPage(int PageNumber)
        {
            var boCo = mkoIt.Asp.WorkflowState<DB.Kepler.EF60.Container.HimmelskoerperCo>.Get(Session);

            var model = new Models.TheUniverse.HimmelskoerperPage()
            {
                die_Himmelskoerper_auf_dieser_Seite = boCo.GetFilteredAndSortedListOfBo().OrderBy(r => r.HimmelskoerperTyp_ID).Skip(PageNumber * PageSize).Take(PageSize),
                Anz_Seiten_gesamt = (int)boCo.CountFilteredBo() / PageSize,
                Seitennummer = PageNumber,
                TypFlt = boCo.TypFlt.On ? (int)boCo.TypFlt.FilterDef : -1
            };

            return View("Index", model);
        }


        public ActionResult SetFilter(int PageNumber, int TypFlt)
        {
            var boCo = mkoIt.Asp.WorkflowState<DB.Kepler.EF60.Container.HimmelskoerperCo>.Get(Session);

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
                TypFlt = boCo.TypFlt.On ? (int)boCo.TypFlt.FilterDef : -1

            };

            return View("Index", model);
        }


        //public ActionResult SetFilterMass(int PageNumber, double MassMin, double MassMax)
        //{
        //    var boCo = new DB.Kepler.EF60.Container.HimmelskoerperCo();

        //    boCo.MasseFlt.On = false;
        //    boCo.MasseFlt.FilterDef = new mko.BI.Bo.Interval<double>(MassMin, MassMax);
        //    boCo.MasseFlt.On = true;

        //    var model = new Models.TheUniverse.HimmelskoerperPage()
        //    {
        //        die_Himmelskoerper_auf_dieser_Seite = boCo.GetFilteredAndSortedListOfBo().Skip(PageNumber * PageSize).Take(PageSize),
        //        Anz_Seiten_gesamt = (int)boCo.CountFilteredBo() / PageSize,
        //        Seitennummer = PageNumber
        //    };

        //    return View("Index", model);
        //}




    }
}