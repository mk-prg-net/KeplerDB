using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;

using System.Collections.Generic;

namespace Kepler.WebApi.Test
{
    [TestClass]
    public class WebApi
    {

        async Task ConsumeGetPlanetSys()
        {
            using (var client = new HttpClient())
            {
                // New code:
                client.BaseAddress = new Uri("http://localhost:55484");

                // vom WebAPi- Dienst die Daten json- serialisiert abrufen
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes("admin:jirapass1"));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);

                // asynchroner Aubruf des Rückgabewertes vom Rest- Dienst
                var response = await client.GetAsync("/api/PlanetSys");

                string jsonStr = await response.Content.ReadAsStringAsync();

                // Der JSon- String wird in eine Liste aus Planaten deserialisiert mittels des 
                // JSon- Parsers von Newtonsoft
                var planets = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Kepler.WebApi.Models.PlanetSys.PlanetClient>>(jsonStr);               

                
            }
        }

        [TestMethod]
        public void WebApi_PlanetSysController()
        {
            var Controller = new Kepler.WebApi.Controllers.PlanetSysController();

            var liste = Controller.Get();
        }
        
        [TestMethod]
        public void WebApi_ValueCtrlTest()
        {
            var Controller = new Kepler.WebApi.Controllers.ValuesController();

            var liste = Controller.Get();

        }
    }
}
