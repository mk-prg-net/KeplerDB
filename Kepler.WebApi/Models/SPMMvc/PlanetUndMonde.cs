using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kepler.WebApi.Models.SPMMvc
{
    public class PlanetUndMonde
    {
        public DB.Kepler.EF60.Sterne_Planeten_Monde Planet { get; set; }

        public IQueryable<DB.Kepler.EF60.Sterne_Planeten_Monde> Monde { get; set; }

    }
}