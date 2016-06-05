using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using System.Web.OData.Builder;
using System.Web.OData.Extensions;

using Microsoft.OData.Edm;
using System.Web.Http;
using System.Web.OData.Batch;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

using DB.Kepler.EF60;


namespace Kepler.WebApi
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            //config.MapODataServiceRoute("odata", null, GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            //config.EnsureInitialized();


            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Himmelskoerper>("Himmelskoerper");

            builder.EntitySet<Raumschiff>("RaumschiffeTab").EntityType.HasKey(r => r.HimmelskoerperID);
            builder.EntitySet<Sterne_Planeten_Monde>("Sterne_Planeten_Monde").EntityType.HasKey(r => r.HimmelskoerperID);
            //builder.ComplexType<Raumschiff>();
            //builder.ComplexType<Sterne_Planeten_Monde>();
            
            builder.EntitySet<HimmelskoerperTyp>("HimmelskoerperTypenTab");
            builder.EntitySet<UrlSammlung>("UrlSammlungenTab").EntityType.HasKey(r => r.ID);

            builder.EntitySet<Umlaufbahn>("UmlaufbahnenTab").EntityType.HasKey(r => r.TrabantID);
            builder.EntitySet<Bild>("BildTab").EntityType.HasKey(r => r.HimmelskoerperID);
            //builder.ComplexType<Umlaufbahn>();
            //builder.ComplexType<Bild>();


            builder.EntitySet<Spektralklasse>("SpektralklasseTab").EntityType.HasKey(r => r.ID);
            config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

           
        }
        //private static IEdmModel GetEdmModel()
        //{


        //    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
        //    builder.EntitySet<Planet>("PlanetsOdata")
        //        .EntityType.HasOptional<Orbit>(r => r.Orbit);

        //    builder.EntitySet<Planet>("PlanetsOdata")
        //        .EntityType.
                
        //    builder.EntitySet<Orbit>("Orbits");
        //    //builder.EntitySet<Moon>("Moons");

        //    builder.EntitySet<KeplerBI.DB.CelestialBodyBase>("CB");

        //    return builder.GetEdmModel();

        //}
        //public static void Register(HttpConfiguration config)
        //{
        //    // Web API configuration and services     

        //    // Hiermit wird erklärt, das sich hinter einem IEnumerable<IPlanet> eine Liste aus Himmelskörpern verbirgt.
        //    // http://stackoverflow.com/questions/14522144/how-to-register-known-types-for-serialization-when-using-asp-net-mvc-web-api
        //    // Funkt jedoch nicht, da dann alle Eigenschaften von Himmelskörper serialisiert werden, und nicht nur die von IPlanet :-(
        //    //GlobalConfiguration.Configuration
        //    //       .Formatters
        //    //       .XmlFormatter.SetSerializer<IEnumerable<IPlanet>>(
        //    //            new System.Runtime.Serialization.DataContractSerializer(typeof(IEnumerable<IPlanet>), new[] { typeof(DB.Kepler.EF60.Himmelskoerper) }));

        //    //GlobalConfiguration.Configuration
        //    //       .Formatters
        //    //       .XmlFormatter.SetSerializer<IEnumerable<IPlanet>>(
        //    //            new System.Runtime.Serialization.DataContractSerializer(typeof(IEnumerable<IPlanet>), new[] { typeof(Models.PlanetSys.PlanetFix) }));



        //    // Web API routes
        //    //config.MapHttpAttributeRoutes();

        //    //config.Routes.MapHttpRoute(
        //    //    name: "DefaultApi",
        //    //    routeTemplate: "api/{controller}/{id}",
        //    //    defaults: new { id = RouteParameter.Optional }
        //    //);


        //}
    }
}
