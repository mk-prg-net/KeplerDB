//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 10.5.2017
//
//  Projekt.......: KeplerBI.RAM
//  Name..........: Star.cs
//  Aufgabe/Fkt...: Kurzbeschreibung
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
using System.Text;
using System.Threading.Tasks;
using KeplerBI.NaturalCelesticalBodies;
using mko.Newton;

namespace KeplerBI.RAM.NaturalCelesticalBodies
{
    public partial class Star : KeplerBI.NaturalCelesticalBodies.IStar
    {
        public LengthInMeter<OrderOfMagnitude.Kilo> EquatorialDiameter
        {
            get;

            set;
        }

        public AccelerationInMeterPerSec<OrderOfMagnitude.One> Gravity
        {
            get; set;
        }

        public IImage Image
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double LuminosityInMulitiplesOfSun
        {
            get; set;
        }

        public Mass Mass
        {
            get; set;
        }

        public double MassInEarthmasses
        {
            get {
                return mko.Newton.Mass.EarthMasses(Mass).Value;
            }
            set { }
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
                throw new NotImplementedException();
            }
        }

        public LengthInMeter<OrderOfMagnitude.Kilo> PolarDiameter
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

        public SpectralClasses SpectralClass
        {
            get; set;
        }
    }
}
