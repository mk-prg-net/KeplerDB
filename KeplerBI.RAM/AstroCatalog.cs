using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeplerBI.NaturalCelesticalBodies;
using KeplerBI.NaturalCelesticalBodies.Repositories;
using KeplerBI.Repositories;
using System.Diagnostics;

namespace KeplerBI.RAM
{
    public class AstroCatalog : KeplerBI.IAstroCatalog
    {
        public IAsteroidsCo Asteroids
        {
            get
            {
                return _AsteroidsCo;
            }
        }

        NaturalCelesticalBodies.Repositories.AsteroidsCo _AsteroidsCo = new NaturalCelesticalBodies.Repositories.AsteroidsCo();
        NaturalCelesticalBodies.Repositories.StarsCo _StarsCo = new NaturalCelesticalBodies.Repositories.StarsCo();

        public ICelesticslBodySystemsCo CelesticalBodySystems
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IMoonsCo Moons
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IPlanetsCo Planets
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IStarsCo Stars
        {
            get
            {
                return _StarsCo;
            }
        }

        public void CreateAsteroid(string Name, IStar CentralBody, mko.Newton.Length semiMajorAxisLength, mko.Newton.Velocity meanVelocityOfCirculation)
        {
            var Asteroid = new NaturalCelesticalBodies.Asteroid(Name);

            Asteroid.Orbit.SemiMajorAxis = semiMajorAxisLength;
            Asteroid.Orbit.MeanVelocityOfCirculation = meanVelocityOfCirculation;

            _AsteroidsCo.Asteroids[Name] = Asteroid;
        }

        public void CreateMoon(string Name, IPlanet Planet, mko.Newton.Length semiMajorAxisLength, mko.Newton.Velocity meanVelocityOfCirculation)
        {
            throw new NotImplementedException();
        }

        public void CreatePlanet(string Name, IStar Star, mko.Newton.Length semiMajorAxisLength, mko.Newton.Velocity meanVelocityOfCirculation)
        {
            throw new NotImplementedException();
        }

        public void CreateStar(string Name)
        {
            throw new NotImplementedException();
        }

        public void SubmitChanges()
        {
            Debug.WriteLine("KeplerBI.RAM AstroCatalog.SubmitChanges");
        }
    }
}
