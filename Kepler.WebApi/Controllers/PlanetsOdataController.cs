using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using KeplerBI.DB.NaturalCelesticalBodies;
using Microsoft.OData.Core;

using NCB = KeplerBI.DB.NaturalCelesticalBodies;


namespace Kepler.WebApi.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller.
     Merge these statements into the Register method of the WebApiConfig class as applicable. 
     Note that OData URLs are case sensitive.

    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using KeplerBI.DB.NaturalCelesticalBodies;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Planet>("Planets");
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PlanetsOdataController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();


        KeplerBI.DB.KeplerDBContext Orm = new KeplerBI.DB.KeplerDBContext();

        protected override void Dispose(bool disposing)
        {
            Orm.Dispose();
            base.Dispose(disposing);
        }

        // GET: odata/Planets
        // Eine Funnktion 
        // Eine Query: GET: http://localhost:55484/Planets?$filter=EquatorialDiameterInKilometer+eq+6792
        // Damit Queries funktionieren, ist folgendes Attribut zu setzen. 
        // Siehe: https://damienbod.com/2014/06/13/web-api-and-odata-v4-queries-functions-and-attribute-routing-part-2/
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.Filter)]
        public IHttpActionResult GetPlanets(ODataQueryOptions<Planet> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok<IEnumerable<Planet>>(Orm.CelesticalBodies.OfType<NCB.Planet>());
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/Planets(6)
        public IHttpActionResult GetPlanet([FromODataUri] int key, ODataQueryOptions<Planet> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok<Planet>(Orm.CelesticalBodies.OfType<NCB.Planet>().Single(r=> r.ID == key));
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/Planets(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Planet> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(planet);

            // TODO: Save the patched entity.

            // return Updated(planet);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Planets
        public IHttpActionResult Post(Planet planet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(planet);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Planets(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Planet> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(planet);

            // TODO: Save the patched entity.

            // return Updated(planet);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Planets(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
