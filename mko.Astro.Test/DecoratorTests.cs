using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mko.Astro.Test
{
    [TestClass]
    public class DecoratorTests
    {
        [TestMethod]
        public void SternenDekoratorTest()
        {            
            var Bellatrix = new inMem.Stern("Bellatrix",
                1e31, mko.Astro.Licht.Objects.Spektralklassen.Instance.O, 10);

            var Aldebran = new inMem.Stern("Aldebran", 
                1e33, mko.Astro.Licht.Objects.Spektralklassen.Instance.K, 30);

            var Sirius = new inMem.Stern("Sirius", 
                1e30, mko.Astro.Licht.Objects.Spektralklassen.Instance.N, 15);


            var Doppel = new inMem.Doppelstern(Bellatrix, Aldebran);


            Astro.inMem.Galaxie Milchstrasse = new inMem.Galaxie();

            // Dekorator spiel hier seine Stärke aus- Milchstrasse nimmt alle auf
            Milchstrasse.Add(Doppel);
            Milchstrasse.Add(Sirius);

            Assert.AreEqual(1e30 + 1e31 + 1e33, Milchstrasse.Masse_in_kg, "Summe der Sternmassen");




            


        }
    }
}
