using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

namespace KeplerBI.Test
{
    [TestClass]
    public class RepositoriesTests
    {
        [TestMethod]
        public void Sterne_filtern_und_sortieren()
        {
            using (var orm = new KeplerBI.DB.KeplerDBContext())
            {
                var UofW = new KeplerBI.DB.UnitOfWork(orm);


                var fltBld = UofW.Stars.createNewFilteredSortedSetBuilder();

                fltBld.defLuminosityInMulitiplesOfSunBetween(1, 100000);
                fltBld.OrderByMass(true);

                var L1_100K = fltBld.GetSet();

                Assert.IsTrue(L1_100K.Any());
                Assert.AreEqual(2, L1_100K.Count());
                Assert.AreEqual("Bellatrix", L1_100K.Get().First().Name);
                Assert.AreEqual("Sonne", L1_100K.Get().Skip(1).First().Name);
                
            }

        }

       [TestMethod]
        public void Planeten_filtern_und_sortieren()
        {
            using (var orm = new KeplerBI.DB.KeplerDBContext())
            {
                var UofW = new KeplerBI.DB.UnitOfWork(orm);

                var fltBld = UofW.Planets.createFiltertedSortedSetBuilder();

                fltBld.defMoonCountBetween(3, 10);
                fltBld.OrderByMass(false);

                var P3_10 = fltBld.GetSet();

                Assert.IsTrue(P3_10.Any());

                var result = P3_10.Get().ToArray();


            }
        }
    }
}
