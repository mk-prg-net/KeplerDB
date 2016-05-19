using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using KeplerBI.NaturalCelesticalBodies;

namespace Kepler.WebApi.Controllers
{
    public class PlanetsController : ApiController
    {
        // GET: api/Planets
        public IEnumerable<IMoon> Get()
        {

            throw new NotImplementedException();
        }

        // GET: api/Planets/5
        public IMoon Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/Planets
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Planets/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Planets/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
