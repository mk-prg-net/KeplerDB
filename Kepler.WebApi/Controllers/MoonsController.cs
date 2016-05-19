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

namespace Kepler.WebApi.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using KeplerBI.DB.NaturalCelesticalBodies;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Moon>("Moons");
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class MoonsController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        KeplerBI.DB.KeplerDBContext Orm = new KeplerBI.DB.KeplerDBContext();

        protected override void Dispose(bool disposing)
        {
            Orm.Dispose();
            base.Dispose(disposing);
        }


        // GET: odata/Moons
        // http://localhost:55484/Moons?$filter=EquatorialDiameterInKilometer%20lt%203000&$orderby=EquatorialDiameterInKilometer
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.Filter| AllowedQueryOptions.OrderBy)]
        public IHttpActionResult GetMoons(ODataQueryOptions<Moon> queryOptions)
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

            // Alle Himmelskörper vom Typ Mond werden als IQueryable bereitgestellt
            return Ok<IEnumerable<Moon>>(Orm.CelesticalBodies.OfType<Moon>().AsQueryable());
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/Moons(5)
        public IHttpActionResult GetMoon([FromODataUri] int key, ODataQueryOptions<Moon> queryOptions)
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

            return Ok<Moon>(Orm.CelesticalBodies.OfType<Moon>().Single(r => r.ID == key));
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/Moons(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Moon> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(moon);

            // TODO: Save the patched entity.

            // return Updated(moon);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Moons
        public IHttpActionResult Post(Moon moon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(moon);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Moons(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Moon> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(moon);

            // TODO: Save the patched entity.

            // return Updated(moon);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Moons(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
