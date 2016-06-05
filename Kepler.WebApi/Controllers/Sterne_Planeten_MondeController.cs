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
using DB.Kepler.EF60;
using Microsoft.OData.Core;

namespace Kepler.WebApi.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using DB.Kepler.EF60;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Sterne_Planeten_Monde>("Sterne_Planeten_Monde");
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class Sterne_Planeten_MondeController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        private KeplerDBEntities db = new KeplerDBEntities();


        // GET: odata/Sterne_Planeten_Monde?$filter=Leuchtkraft_in_Lsonne+gt+1
        // Damit Queries funktionieren, ist folgendes Attribut zu setzen. 
        // Siehe: https://damienbod.com/2014/06/13/web-api-and-odata-v4-queries-functions-and-attribute-routing-part-2/
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.Filter | AllowedQueryOptions.OrderBy)]
        public IHttpActionResult GetSterne_Planeten_Monde(ODataQueryOptions<Sterne_Planeten_Monde> queryOptions)
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

            return Ok<IEnumerable<Sterne_Planeten_Monde>>(db.Sterne_Planeten_MondeTab);
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/Sterne_Planeten_Monde(5)
        public IHttpActionResult GetSterne_Planeten_Monde([FromODataUri] int key, ODataQueryOptions<Sterne_Planeten_Monde> queryOptions)
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

            return Ok<Sterne_Planeten_Monde>(db.Sterne_Planeten_MondeTab.Find(key));
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/Sterne_Planeten_Monde(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Sterne_Planeten_Monde> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.
            var e = db.Sterne_Planeten_MondeTab.Find(key);
            delta.Put(e);

            // TODO: Save the patched entity.

             return Updated(e);
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Sterne_Planeten_Monde
        public IHttpActionResult Post(Sterne_Planeten_Monde sterne_Planeten_Monde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(sterne_Planeten_Monde);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Sterne_Planeten_Monde(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Sterne_Planeten_Monde> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(sterne_Planeten_Monde);

            // TODO: Save the patched entity.

            // return Updated(sterne_Planeten_Monde);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Sterne_Planeten_Monde(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
