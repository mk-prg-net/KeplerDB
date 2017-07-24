using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeplerBI.MVC.Controllers
{
    public class help_rpnController : Controller
    {
        // GET: help_rpn
        public ActionResult Index(string SupportedController = "Asteroids", string SupportedAction = "Index", string pn = "")
        {
            return View(new Models.rpn_help.AstroComposers(SupportedController, SupportedAction, pn));
        }
    }
}