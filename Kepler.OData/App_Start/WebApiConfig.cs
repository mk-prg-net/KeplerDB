using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.OData.Edm;
using System.Web.Http;
using System.Web.OData.Batch;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

using KeplerBI.DB.NaturalCelesticalBodies;


namespace Kepler.OData
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            config.EnableSystemDiagnosticsTracing();
            config.MapODataServiceRoute("odata", null, GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            config.EnsureInitialized();

        }
        private static IEdmModel GetEdmModel()
        {

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Planet>("Planets");
            //builder.EntitySet<Moon>("Moons");

            return builder.GetEdmModel();

        }
    }
}