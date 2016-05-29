using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB
{
    public class AstroCatalog : KeplerBI.IAstroCatalog, IDisposable
    {
        KeplerDBContext _ctx;
        bool _ctxExtern = false;
        NaturalCelesticalBodies.Repositories.MoonCo _Moons;
        NaturalCelesticalBodies.Repositories.PlanetCo _Planets;
        NaturalCelesticalBodies.Repositories.StarsCo _Stars;
        Repositories.CelesticalBodySystemsCo _CelesticalBodySystems;



        public void Dispose()
        {
            if (!_ctxExtern && _ctx != null)
            {
                _ctx.Dispose();
            }
        }

        public AstroCatalog()
        {
            Init(new KeplerDBContext());
        }

        public AstroCatalog(KeplerDBContext ctx)
        {
            _ctxExtern = true;
            Init(ctx);
        }

        private void Init(KeplerDBContext ctx)
        {
            _ctx = ctx;
            _Moons = new NaturalCelesticalBodies.Repositories.MoonCo(_ctx);
            _Planets = new NaturalCelesticalBodies.Repositories.PlanetCo(_ctx);
            _Stars = new NaturalCelesticalBodies.Repositories.StarsCo(_ctx);
            _CelesticalBodySystems = new Repositories.CelesticalBodySystemsCo(_ctx);
        }

        

        public KeplerBI.NaturalCelesticalBodies.Repositories.IStarsCo Stars
        {
            get { return _Stars; }
        }

        public void CreateStar(string Name)
        {
            // Planet anlegen und in die Himmelskörperliste eintragen
            var newStar = new NaturalCelesticalBodies.Star();
            newStar.Name = Name;
            _ctx.CelesticalBodies.Add(newStar);

            // Neues Planetensystem um den Stern anlegen
            var planetSys = new CelesticalBodySystem();
            planetSys.CentralBody = newStar;
            planetSys.Orbits = new List<Orbit>();
            _ctx.CelesticalBodySystems.Add(planetSys);
        }


        public KeplerBI.NaturalCelesticalBodies.Repositories.IPlanetsCo Planets
        {
            get { return _Planets; }
        }

        public void CreatePlanet(string Name, KeplerBI.NaturalCelesticalBodies.IStar Star, mko.Newton.Length semiMajorAxisLength, mko.Newton.Velocity meanVelocityOfCirculation)
        {
            if (_ctx.CelesticalBodySystems.Any(r => r.CentralBody.Name == Star.Name))
            {
                // Planet anlegen und in die Himmelskörperliste eintragen
                var newPlanet = new NaturalCelesticalBodies.Planet();
                newPlanet.Name = Name;
                _ctx.CelesticalBodies.Add(newPlanet);

                // Planet in einem Planetensystem aufnehmen
                var newOrbit = new Orbit();
                newPlanet.Orbit = newOrbit;
                newOrbit.Satellite = newPlanet;
                newOrbit.CentralBody = _ctx.CelesticalBodies.First(r => r.Name == Star.Name);
                newOrbit.SemiMajorAxisInKilometer = mko.Newton.Length.Kilometer(semiMajorAxisLength).Vector.Length;
                newOrbit.MeanVelocitiOfCirculationInKmPerSec = mko.Newton.Velocity.KilometerPerSec(meanVelocityOfCirculation).Vector.Length;

                var cbSys = _ctx.CelesticalBodySystems.First(r => r.CentralBody.Name == Star.Name);
                cbSys.Orbits.Add(newOrbit);

                // Neues Mondsystem um den Planeten anlegen
                var moonSys = new CelesticalBodySystem();
                moonSys.CentralBody = newPlanet;
                moonSys.Orbits = new List<Orbit>();
                _ctx.CelesticalBodySystems.Add(moonSys);
            }
            else
            {
                throw new Exception(mko.TraceHlp.FormatErrMsg(this, "CreatePlanet"));
            }
         
        }

        public KeplerBI.NaturalCelesticalBodies.Repositories.IMoonsCo Moons
        {
            get { return _Moons; }
        }

        public void CreateMoon(string Name, KeplerBI.NaturalCelesticalBodies.IPlanet Planet, mko.Newton.Length semiMajorAxisLength, mko.Newton.Velocity meanVelocityOfCirculation)
        {
            if (_ctx.CelesticalBodySystems.Any(r => r.CentralBody.Name == Planet.Name))
            {
                // Mond anlegen und in die Himmelskörperliste eintragen
                var newMoon = new NaturalCelesticalBodies.Moon();
                newMoon.Name = Name;
                _ctx.CelesticalBodies.Add(newMoon);

                // Planet in einem Mondsystem aufnehmen
                var newOrbit = new Orbit();
                newMoon.Orbit = newOrbit;
                newOrbit.Satellite = newMoon;
                newOrbit.CentralBody = _ctx.CelesticalBodies.OfType<NaturalCelesticalBodies.Planet>().First(r => r.Name == Planet.Name);
                newOrbit.SemiMajorAxisInKilometer = mko.Newton.Length.Kilometer(semiMajorAxisLength).Vector.Length;
                newOrbit.MeanVelocitiOfCirculationInKmPerSec = mko.Newton.Velocity.KilometerPerSec(meanVelocityOfCirculation).Vector.Length;

                var cbSys = _ctx.CelesticalBodySystems.First(r => r.CentralBody.Name == Planet.Name);
                cbSys.Orbits.Add(newOrbit);
            }
            else
            {
                throw new Exception(mko.TraceHlp.FormatErrMsg(this, "CreateMoon"));
            }
        }

        public KeplerBI.Repositories.ICelesticslBodySystemsCo CelesticalBodySystems
        {
            get { return _CelesticalBodySystems; }
        }

        /// <summary>
        /// Charakteristische Funktion von UnitOfWork: Abgleich der Änderungen an allen
        /// Repositories in einem gemeinschaftlichen Akt- dabei werden Beziehungen berücksichtigt.
        /// </summary>
        public void SubmitChanges()
        {
            _ctx.SaveChanges();
        }



    }
}
