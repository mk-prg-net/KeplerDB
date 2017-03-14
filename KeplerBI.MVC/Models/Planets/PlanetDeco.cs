//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 8.11.2016
//
//  Projekt.......: KeplerBI.MVC
//  Name..........: PlanetDeco.cs
//  Aufgabe/Fkt...: Dekorator für Planeten. Erweitert einen Planeten um die Liste seiner Monde
//                  
//
//
//
//
//<unit_environment>
//------------------------------------------------------------------
//  Zielmaschine..: PC 
//  Betriebssystem: Windows 7 mit .NET 4.5
//  Werkzeuge.....: Visual Studio 2013
//  Autor.........: Martin Korneffel (mko)
//  Version 1.0...: 
//
// </unit_environment>
//
//<unit_history>
//------------------------------------------------------------------
//
//  Version.......: 1.1
//  Autor.........: Martin Korneffel (mko)
//  Datum.........: 
//  Änderungen....: 
//
//</unit_history>
//</unit_header>        
        
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeplerBI.MVC.Models.Planets
{
    public class PlanetDeco : KeplerBI.NaturalCelesticalBodies.IPlanet
    {

        KeplerBI.NaturalCelesticalBodies.IPlanet _Planet;
        IEnumerable<KeplerBI.NaturalCelesticalBodies.IMoon> _Moons;


        public PlanetDeco(KeplerBI.NaturalCelesticalBodies.IPlanet Planet, IEnumerable<KeplerBI.NaturalCelesticalBodies.IMoon> Moons)
        {
            _Planet = Planet;
            _Moons = Moons;
        }

        public bool HasRings
        {
            get
            {
                return _Planet.HasRings;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double MassInEarthmasses
        {
            get
            {
                return _Planet.MassInEarthmasses;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double MeanSurfaceTemp
        {
            get
            {
                return _Planet.MeanSurfaceTemp;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public mko.Newton.AccelerationInMeterPerSec<mko.Newton.OrderOfMagnitude.One> Gravity
        {
            get
            {
                return _Planet.Gravity;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public mko.Newton.LengthInMeter<mko.Newton.OrderOfMagnitude.Kilo> PolarDiameter
        {
            get
            {
                return _Planet.PolarDiameter;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public mko.Newton.LengthInMeter<mko.Newton.OrderOfMagnitude.Kilo> EquatorialDiameter
        {
            get
            {
                return _Planet.EquatorialDiameter;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                return _Planet.Name;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public mko.Newton.Mass Mass
        {
            get
            {
                return _Planet.Mass;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IOrbit Orbit
        {
            get
            {
                return _Planet.Orbit;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<KeplerBI.NaturalCelesticalBodies.IMoon> Moons
        {
            get
            {
                return _Moons;
            }
        }

        public int RankSum
        {
            get
            {
                return _Planet.RankSum;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int RankCount
        {
            get
            {
                return _Planet.RankCount;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IImage Image
        {
            get
            {
                return _Planet.Image;
            }
        }
    }
}