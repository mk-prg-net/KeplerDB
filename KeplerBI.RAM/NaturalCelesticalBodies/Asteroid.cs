//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 10.5.2017
//
//  Projekt.......: KeplerBI.RAM
//  Name..........: Asteroid.cs
//  Aufgabe/Fkt...: Implementierung eines Asteroiden. Daten werden innerhalb des 
//                  Objektes im RAM gespeichert
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
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.RAM.NaturalCelesticalBodies
{
    public class Asteroid : KeplerBI.NaturalCelesticalBodies.IAsteroid, IAsteroidFlat
    {
        public Asteroid()
        {
            this.Name = "Test";
            _Orbit = new AsteroidOrbit(this);
        }

        public Asteroid(string Name)
        {
            this.Name = Name;
            _Orbit = new AsteroidOrbit(this);
        }

        public double Albedo
        {
            get; set;
        }

        public mko.Newton.LengthInMeter<mko.Newton.OrderOfMagnitude.Kilo> EquatorialDiameter
        {
            get; set;
        }

        public mko.Newton.AccelerationInMeterPerSec<mko.Newton.OrderOfMagnitude.One> Gravity
        {
            get
            {
                return _Gravity;
            }
            set
            {
                _Gravity = value;
            }
        }

        mko.Newton.AccelerationInMeterPerSec<mko.Newton.OrderOfMagnitude.One> _Gravity;

        public IImage Image
        {
            get
            {
                return null;
            }
        }

        public mko.Newton.Mass Mass
        {
            get;
            set;
        }        

        public double MassInEarthmasses
        {
            get
            {
                return mko.Newton.Mass.EarthMasses(Mass).Value;
            }
            set {
                Mass = mko.Newton.Mass.EarthMasses(value);
            }
        }

        public double MeanSurfaceTemp
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public IOrbit Orbit
        {
            get
            {
                return _Orbit;
            }
        }

        AsteroidOrbit _Orbit;

        public mko.Newton.LengthInMeter<mko.Newton.OrderOfMagnitude.Kilo> PolarDiameter
        {
            get; set;
        }

        public int RankCount
        {
            get; set;
        }

        public int RankSum
        {
            get; set;
        }

        public double MassInEarthMoonMasses
        {
            get
            {
                return mko.Newton.Mass.Kilogram(Mass).Value/mko.Newton.Mass.MassOfEarthMoon.Value;
            }
        }

        public double SemiMajorAxisLengthInAU
        {
            get
            {
                return mko.Newton.Length.AU(Orbit.SemiMajorAxis).Vector[0];
            }
        }

        public double MeanOrbitVelocityInKmPerSec
        {
            get
            {
                return mko.Newton.Velocity.KilometerPerSec(Orbit.MeanVelocityOfCirculation).Vector[0];
            }
        }

        public double DiameterInKm
        {
            get
            {
                return EquatorialDiameter.Vector[0];
            }
        }
    }
}
