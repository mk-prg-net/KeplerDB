using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using DB.Kepler.EF60;

namespace Kepler.WebApi.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using DB.Kepler.EF60;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Himmelskoerper>("Himmelskoerpers");
    builder.EntitySet<Raumschiff>("RaumschiffeTab"); 
    builder.EntitySet<Sterne_Planeten_Monde>("Sterne_Planeten_MondeTab"); 
    builder.EntitySet<HimmelskoerperTyp>("HimmelskoerperTypenTab"); 
    builder.EntitySet<UrlSammlung>("UrlSammlungenTab"); 
    builder.EntitySet<Umlaufbahn>("UmlaufbahnenTab"); 
    builder.EntitySet<Bild>("BildTab"); 
    builder.EntitySet<Spektralklasse>("SpektralklasseTab"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class HimmelskoerperController : ODataController
    {
        private KeplerDBEntities db = new KeplerDBEntities();

        // GET: odata/Himmelskoerpers
        // Damit Queries funktionieren, ist folgendes Attribut zu setzen. 
        // Siehe: https://damienbod.com/2014/06/13/web-api-and-odata-v4-queries-functions-and-attribute-routing-part-2/
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.Filter)]
        public IQueryable<Himmelskoerper> GetHimmelskoerpers()
        {
            return db.HimmelskoerperTab;
        }

        // GET: odata/Himmelskoerpers(5)
        [EnableQuery]
        public SingleResult<Himmelskoerper> GetHimmelskoerper([FromODataUri] int key)
        {
            return SingleResult.Create(db.HimmelskoerperTab.Where(himmelskoerper => himmelskoerper.ID == key));
        }

        // PUT: odata/Himmelskoerpers(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Himmelskoerper> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Himmelskoerper himmelskoerper = db.HimmelskoerperTab.Find(key);
            if (himmelskoerper == null)
            {
                return NotFound();
            }

            patch.Put(himmelskoerper);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HimmelskoerperExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(himmelskoerper);
        }

        // POST: odata/Himmelskoerpers
        public IHttpActionResult Post(Himmelskoerper himmelskoerper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HimmelskoerperTab.Add(himmelskoerper);
            db.SaveChanges();

            return Created(himmelskoerper);
        }

        // PATCH: odata/Himmelskoerpers(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Himmelskoerper> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Himmelskoerper himmelskoerper = db.HimmelskoerperTab.Find(key);
            if (himmelskoerper == null)
            {
                return NotFound();
            }

            patch.Patch(himmelskoerper);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HimmelskoerperExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(himmelskoerper);
        }

        // DELETE: odata/Himmelskoerpers(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Himmelskoerper himmelskoerper = db.HimmelskoerperTab.Find(key);
            if (himmelskoerper == null)
            {
                return NotFound();
            }

            db.HimmelskoerperTab.Remove(himmelskoerper);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Himmelskoerpers(5)/RaumschiffeTab
        [EnableQuery]
        public SingleResult<Raumschiff> GetRaumschiffeTab([FromODataUri] int key)
        {
            return SingleResult.Create(db.HimmelskoerperTab.Where(m => m.ID == key).Select(m => m.RaumschiffeTab));
        }

        // GET: odata/Himmelskoerpers(5)/Sterne_Planeten_MondeTab
        [EnableQuery]
        public SingleResult<Sterne_Planeten_Monde> GetSterne_Planeten_MondeTab([FromODataUri] int key)
        {
            return SingleResult.Create(db.HimmelskoerperTab.Where(m => m.ID == key).Select(m => m.Sterne_Planeten_MondeTab));
        }

        // GET: odata/Himmelskoerpers(5)/HimmelskoerperTyp
        [EnableQuery]
        public SingleResult<HimmelskoerperTyp> GetHimmelskoerperTyp([FromODataUri] int key)
        {
            return SingleResult.Create(db.HimmelskoerperTab.Where(m => m.ID == key).Select(m => m.HimmelskoerperTyp));
        }

        // GET: odata/Himmelskoerpers(5)/UrlSammlungen
        [EnableQuery]
        public IQueryable<UrlSammlung> GetUrlSammlungen([FromODataUri] int key)
        {
            return db.HimmelskoerperTab.Where(m => m.ID == key).SelectMany(m => m.UrlSammlungen);
        }

        // GET: odata/Himmelskoerpers(5)/Umlaufbahn
        [EnableQuery]
        public SingleResult<Umlaufbahn> GetUmlaufbahn([FromODataUri] int key)
        {
            return SingleResult.Create(db.HimmelskoerperTab.Where(m => m.ID == key).Select(m => m.Umlaufbahn));
        }

        // GET: odata/Himmelskoerpers(5)/TrabantenUmlaufbahnen
        [EnableQuery]
        public IQueryable<Umlaufbahn> GetTrabantenUmlaufbahnen([FromODataUri] int key)
        {
            return db.HimmelskoerperTab.Where(m => m.ID == key).SelectMany(m => m.TrabantenUmlaufbahnen);
        }

        // GET: odata/Himmelskoerpers(5)/Bild
        [EnableQuery]
        public SingleResult<Bild> GetBild([FromODataUri] int key)
        {
            return SingleResult.Create(db.HimmelskoerperTab.Where(m => m.ID == key).Select(m => m.Bild));
        }

        // GET: odata/Himmelskoerpers(5)/Spektralklasse
        [EnableQuery]
        public SingleResult<Spektralklasse> GetSpektralklasse([FromODataUri] int key)
        {
            return SingleResult.Create(db.HimmelskoerperTab.Where(m => m.ID == key).Select(m => m.Spektralklasse));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HimmelskoerperExists(int key)
        {
            return db.HimmelskoerperTab.Count(e => e.ID == key) > 0;
        }
    }
}
