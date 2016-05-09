using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

using NCB = KeplerBI.DB.NaturalCelesticalBodies;

using BI = KeplerBI;
using BIWf = KeplerBI.Workflows;
using BIWfCBS = KeplerBI.Workflows.CreateCBSys;

using DB = KeplerBI.DB;
using DBWf = KeplerBI.DB.Workflows;
using DBWfCBS = KeplerBI.DB.Workflows.CreateCBSys;


namespace KeplerBI.Test
{
    [TestClass]
    public class GenerateAndFill
    {
        [TestInitialize]
        public void Initilize()
        {
            mko.Newton.Init.Do();
        }

        [TestMethod]
        public void KeplerBI_CreateKeplerBI()
        {
            try
            {
                KeplerBI.DB.DBUtil.CreateDB();
            }
            catch (Exception ex)
            {
                Assert.Fail("Erstellen der Datenbank KeplerBI fehlgeschlagen");
            }

        }


        [TestMethod]
        public void KeplerBI_QueryCelesticalBodies()
        {
            using (var ORM = new KeplerBI.DB.KeplerDBContext())
            {
                // Liste der Planeten abrufen
                var ProtoPlanets = ORM.CelesticalBodies.OfType<NCB.Planet>().ToArray();
                var Planets = ORM.CelesticalBodies.OfType<KeplerBI.DB.NaturalCelesticalBodies.Planet>().Cast<NCB.Planet>().ToArray();

                // Alle Monde von Jupiter
                var JupiterMoons = ORM.CelesticalBodySystems.Where(r => r.CentralBody.Name == "Jupiter").Select(r => r.Orbits.Select(orb => orb.Satellite));

                var JupiterMoons2 = ORM.CelesticalBodySystems.Single(r => r.CentralBody.Name == "Jupiter").Orbits.Select(r => r.Satellite).Cast<NCB.Moon>().ToArray();

                Assert.IsTrue(true);
            }

        }

        [TestMethod]
        public void KeplerBI_Repositories()
        {
            // Vorbereitung: Aktuelles Uranussystem löschen
            using (var ORM = new KeplerBI.DB.KeplerDBContext())
            {

                var repo = new KeplerBI.DB.NaturalCelesticalBodies.Repositories.PlanetCo(ORM);


                var all = repo.GetAllBo();

                var flt1 = repo.GetFilteredListOfBo();

                //repo.MassInEarthmassFlt = new mko.Algo.Interval<double>(10, 100);
                //var flt2 = repo.GetBoFiltered();

                //repo.MassInEarthmassFilterOn = true;
                //var flt3 = repo.GetBoFiltered();

                //repo.MassInEarthmassFilterOn = false;
                //var flt4 = repo.GetBoFiltered();

                //Assert.AreEqual(flt4.Count(), flt2.Count());

                //repo.DiameterFlt = new mko.Algo.Interval<double>(50000, 150000);
                //repo.DiameterFilterOn = true;
                //repo.MassInEarthmassFilterOn = true;
                //var flt5 = repo.GetBoFiltered();


            }

        }


        [TestMethod]
        public void KeplerBI_CreateCelesticalBodySystem()
        {
            using (var ORM = new KeplerBI.DB.KeplerDBContext())
            {
                if (ORM.CelesticalBodySystems.Any(r => r.CentralBody.Name == "Uranus"))
                {

                    var cbs = ORM.CelesticalBodySystems.Single(r => r.CentralBody.Name == "Uranus");

                    // Loschen aller Orbits
                    foreach (var orbit in cbs.Orbits.ToArray())
                    {
                        ORM.Orbits.Remove(orbit);
                    }

                    ORM.CelesticalBodySystems.Remove(cbs);

                    ORM.SaveChanges();
                }
            }


            // Workflow zum erstellen eines Himmelskörpersystems beginnt

            //var FSM = new DBWfCBS.FinitStateMachine();

            //FSM.ActiveState = FSM.StateFactory.CreateStart();
            //Assert.IsInstanceOfType(FSM.ActiveState, typeof(BIWfCBS.Start.Start));

            //FSM.ActiveState = FSM.StateFactory.CreateStartSTF().Transition(FSM.ActiveStateAsStart, BIWfCBS.Start.StartSTF.Inputs.SelectPlanetAsCentralBody);
            //Assert.IsInstanceOfType(FSM.ActiveState, typeof(BIWfCBS.SelectCentralBody.PlanetAsCentralBodyContext));


            //var centralBody = FSM.ActiveStateAsPlanetAsCentralBody.Planets.GetBo("Uranus");

            //FSM.ActiveState = FSM.StateFactory.CreatePlanetAsCentralBodySTF().Transition(
            //    FSM.ActiveStateAsPlanetAsCentralBody,
            //    new BIWfCBS.SelectCentralBody.PlanetAsCentralBodySTF.InputPlanet(centralBody)); //new DB.NaturalCelesticalBodies.Planet() { Name = "Uranus" }));

            //Assert.IsInstanceOfType(FSM.ActiveState, typeof(BIWfCBS.SelectSatellite.SatellitesOfPlanetContext));

            //FSM.ActiveState = FSM.StateFactory.CreateSatellitesOfPlanetSTF().Transition(
            //    FSM.ActiveStateAsSatellitesOfPlanet,
            //    new BIWfCBS.SelectSatellite.InputSatelliteOrbit(new DB.Orbit()
            //        {
            //            Satellite = (DB.NaturalCelesticalBodies.Moon)FSM.ActiveStateAsSatellitesOfPlanet.Moons.GetBo("Miranda"), // new DB.NaturalCelesticalBodies.Moon() { Name = "Miranda" },
            //            MeanVelocityOfCirculation = mko.Newton.Velocity.KilometerPerSec(6.68),
            //            SemiMajorAxis = mko.Newton.Length.Kilometer(129872)
            //        }
            //    ));
            //Assert.IsInstanceOfType(FSM.ActiveState, typeof(BIWfCBS.SelectSatellite.SatellitesOfPlanetContext));

            //FSM.ActiveState = FSM.StateFactory.CreateSatellitesOfPlanetSTF().Transition(
            //    FSM.ActiveStateAsSatellitesOfPlanet,
            //    new BIWfCBS.SelectSatellite.InputSatelliteOrbit(new DB.Orbit()
            //    {
            //        Satellite = new DB.NaturalCelesticalBodies.Moon() { Name = "Titania" },
            //        MeanVelocityOfCirculation = mko.Newton.Velocity.KilometerPerSec(3.87),
            //        SemiMajorAxis = mko.Newton.Length.Kilometer(436000)
            //    }
            //));
            //Assert.IsInstanceOfType(FSM.ActiveState, typeof(BIWfCBS.SelectSatellite.SatellitesOfPlanetContext));

            //FSM.ActiveState = FSM.StateFactory.CreateSatellitesOfPlanetSTF().Transition(
            //    FSM.ActiveStateAsSatellitesOfPlanet,
            //    new BIWfCBS.SelectSatellite.InputFinishSelection());
            //Assert.IsInstanceOfType(FSM.ActiveState, typeof(BIWfCBS.Save.SaveNewCBSysContext));


            //FSM.ActiveState = FSM.StateFactory.CreateSaveCBSysSTF().Transition(
            //    FSM.ActiveStateAsSaveNewCBSys,
            //        new BIWfCBS.Save.InputSave()
            //        {
            //            Name = "Uranussystem"
            //        }
            //    );
            //Assert.IsInstanceOfType(FSM.ActiveState, typeof(BIWfCBS.FinContext));

        }



    }
}
