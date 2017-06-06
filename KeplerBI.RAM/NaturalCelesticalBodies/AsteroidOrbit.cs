//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 10.5.2017
//
//  Projekt.......: KeplerBI.RAM
//  Name..........: AsteroidOrbit.cs
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
using mko.Newton;

namespace KeplerBI.RAM.NaturalCelesticalBodies
{
    public class AsteroidOrbit : KeplerBI.IOrbit
    {
        public AsteroidOrbit(Asteroid asteroid)
        {
            this.asteroid = asteroid;
        }

        Asteroid asteroid;

        public ICelestialBodyBase CentralBody
        {
            get
            {
                return Star.Sun;
            }
        }

        public Velocity MeanVelocityOfCirculation
        {
            get; set;
        }

        public ICelestialBodyBase Satellite
        {
            get
            {
                return asteroid;
            }
        }

        public Length SemiMajorAxis
        {
            get; set;
        }
    }
}
