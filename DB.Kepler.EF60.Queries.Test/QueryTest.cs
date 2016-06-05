using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Muss für die Nutzung von Linq eingebunden werden
using System.Linq;

namespace DB.Kepler.EF60.Queries.Test
{
    [TestClass]
    public class QueryTest
    {
        [TestMethod]
        public async System.Threading.Tasks.Task KeplerDB_Queries()
        {

            using (var ctx = new Kepler.EF60.KeplerDBEntities())
            {

                var Planetendaten = ctx.HimmelskoerperTab.Where(r => r.HimmelskoerperTyp.Name == "Planet")
                                     .Select(r => new
                                     {
                                         Name = r.Name,
                                         TOberfl = r.Sterne_Planeten_MondeTab.Oberflaechentemperatur_in_K,
                                         Bahnradius = r.Umlaufbahn.Laenge_grosse_Halbachse_in_km
                                     });
                var PlanetendatenSql = Planetendaten.ToString();

                var res =  ctx.Database.SqlQuery<Himmelskoerper>("select * from dbo.HimmelskoerperTab");

                var resAsync = await ctx.Database.SqlQuery<Himmelskoerper>("select * from dbo.HimmelskoerperTab").ToArrayAsync();


                Assert.AreEqual(8, Planetendaten.Count());

            }

        }
    }
}
