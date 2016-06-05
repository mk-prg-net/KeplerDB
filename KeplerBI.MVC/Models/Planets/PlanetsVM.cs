using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using mko.BI.Repositories.Interfaces;

namespace KeplerBI.MVC.Models.Planets
{
    public class PlanetsVM
    {
        public IFilteredSortedSet<KeplerBI.NaturalCelesticalBodies.IPlanet> Planets { get; set; }

        public string QueryOptions = "";

        public double MinBahnRadiusAU { get; set; }
        public double MaxBahnRadiusAU { get; set; }
    }
}