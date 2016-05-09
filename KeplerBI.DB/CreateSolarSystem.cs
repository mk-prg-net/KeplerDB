
//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 14.12.2014
//
//  Projekt.......: KeplerBI.DB
//  Name..........: CreateSolarSystem.cs
//  Aufgabe/Fkt...: Füllt die KelplerBI- Datenbank mit den wichtigsten Daten des Solarsystems.
//                  Daten aus de.wikipedia.org
//
//
//
//
//<unit_environment>
//------------------------------------------------------------------
//  Zielmaschine..: PC 
//  Betriebssystem: Windows XP mit .NET 2.0
//  Werkzeuge.....: Visual Studio 2005
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

using NCB = KeplerBI.DB.NaturalCelesticalBodies;

namespace KeplerBI.DB
{
    public class CreateSolarSystem
    {
        public static void DoIt()
        {
            using (var ORM = new KeplerBI.DB.KeplerDBContext())
            {

                mko.Newton.Init.Do();

                var Sonne = new NCB.Star()
                {
                    Name = "Sonne",
                    SpectralClass = KeplerBI.NaturalCelesticalBodies.SpectralClasses.G,
                    Mass = mko.Newton.Mass.MassOfSun,
                    Gravity = mko.Newton.Acceleration.GravityOnSun,
                    MeanSurfaceTemp = 5778.0 - 273.0,
                    PolarDiameter = mko.Newton.Length.DiameterSun,
                    EquatorialDiameter = mko.Newton.Length.DiameterSun,
                };
                ORM.CelesticalBodies.Add(Sonne);

                var Merkur = new NCB.Planet()
                {
                    Name = "Merkur",
                    EquatorialDiameter = mko.Newton.Length.DiameterMercury,
                    PolarDiameter = mko.Newton.Length.DiameterMercury,
                    Gravity = mko.Newton.Acceleration.GravityOnMercury,
                    Mass = mko.Newton.Mass.MassOfMercury,
                    MeanSurfaceTemp = 167
                };
                ORM.CelesticalBodies.Add(Merkur);

                var Venus = new NCB.Planet()
                {
                    Name = "Venus",
                    EquatorialDiameter = mko.Newton.Length.DiameterVenus,
                    PolarDiameter = mko.Newton.Length.DiameterVenus,
                    Gravity = mko.Newton.Acceleration.GravityOnVenus,
                    Mass = mko.Newton.Mass.MassOfVenus,
                    MeanSurfaceTemp = 464.0
                };
                ORM.CelesticalBodies.Add(Venus);

                //-------------------------------------------------------------------------------
                // Erdsystem

                var Earth = new KeplerBI.DB.NaturalCelesticalBodies.Planet()
                {
                    Name = "Erde",
                    EquatorialDiameter = mko.Newton.Length.DiameterEarth,
                    PolarDiameter = mko.Newton.Length.DiameterEarthPolar,
                    Gravity = mko.Newton.Acceleration.GravityOnEarth,
                    Mass = mko.Newton.Mass.MassOfEarth,
                    MeanSurfaceTemp = 15.0,
                };
                ORM.CelesticalBodies.Add(Earth);


                var Moon = new KeplerBI.DB.NaturalCelesticalBodies.Moon
                {
                    Name = "Erdmond",
                    EquatorialDiameter = mko.Newton.Length.DiameterEarthMoon,
                    PolarDiameter = mko.Newton.Length.DiameterEarthMoonPolar,
                    Gravity = mko.Newton.Acceleration.GravityOnEarthMoon,
                    Mass = mko.Newton.Mass.MassOfEarthMoon,
                    MeanSurfaceTemp = -170,
                };
                ORM.CelesticalBodies.Add(Moon);

                var ErdeMondSystem = new KeplerBI.DB.CelesticalBodySystem()
                {
                    CentralBody = Earth,
                    Orbits = new KeplerBI.DB.Orbit[] {
                        new KeplerBI.DB.Orbit(){
                            Satellite = Moon,
                            SemiMajorAxis = mko.Newton.Length.SemiMajorAxisEarthMoon,
                            MeanVelocityOfCirculation = mko.Newton.Velocity.VelocityOfEarthMoon
                        }
                    },
                };
                ORM.CelesticalBodySystems.Add(ErdeMondSystem);

                //--------------------------------------------------------------------------------
                // Marssystem

                var Mars = new NCB.Planet()
                {
                    Name = "Mars",
                    EquatorialDiameter = mko.Newton.Length.DiameterMars,
                    PolarDiameter = mko.Newton.Length.DiameterMarsPolar,
                    Gravity = mko.Newton.Acceleration.GravityOnMars,
                    Mass = mko.Newton.Mass.MassOfMars,
                    MeanSurfaceTemp = -55.0
                };
                ORM.CelesticalBodies.Add(Mars);

                var Phobos = new KeplerBI.DB.NaturalCelesticalBodies.Moon
                {
                    Name = "Phobos",
                    EquatorialDiameter = mko.Newton.Length.DiameterMarsMoonPhobos,
                    Gravity = mko.Newton.Acceleration.GravityOnMarsMoonPhobos,
                    Mass = mko.Newton.Mass.MassOfMarsMoonPhobos,
                    MeanSurfaceTemp = 268.0 - 273.0,
                };
                ORM.CelesticalBodies.Add(Phobos);

                var Deimos = new KeplerBI.DB.NaturalCelesticalBodies.Moon
                {
                    Name = "Deimos",
                    EquatorialDiameter = mko.Newton.Length.DiameterMarsMoonDeimos,
                    Gravity = mko.Newton.Acceleration.GravityOnMarsMoonDeimos,
                    Mass = mko.Newton.Mass.MassOfMarsMoonDeimos,
                    MeanSurfaceTemp = 268.0 - 273.0,
                };
                ORM.CelesticalBodies.Add(Deimos);

                var Marsmonde = new KeplerBI.DB.CelesticalBodySystem()
                {
                    CentralBody = Mars,
                    Orbits = new KeplerBI.DB.Orbit[] {
                        new KeplerBI.DB.Orbit(){
                            Satellite = Phobos,
                            SemiMajorAxis = mko.Newton.Length.SemiMajorAxisMoonPhobos,
                            MeanVelocityOfCirculation = mko.Newton.Velocity.VelocityOfMarsMoonPhobos,
                        },
                        new KeplerBI.DB.Orbit(){
                            Satellite = Deimos,
                            SemiMajorAxis = mko.Newton.Length.SemiMajorAxisMoonDeimos,
                            MeanVelocityOfCirculation = mko.Newton.Velocity.VelocityOfMarsMoonDeimos,
                        },

                    },
                };
                ORM.CelesticalBodySystems.Add(Marsmonde);

                //---------------------------------------------------------------------------------------
                // Jupitersystem

                var Jupiter = new NCB.Planet()
                {
                    Name = "Jupiter",
                    EquatorialDiameter = mko.Newton.Length.DiameterJupiter,
                    PolarDiameter = mko.Newton.Length.DiameterJupiterPolar,
                    Gravity = mko.Newton.Acceleration.GravityOnJupiter,
                    Mass = mko.Newton.Mass.MassOfJupiter,
                    MeanSurfaceTemp = -108.0
                };
                ORM.CelesticalBodies.Add(Jupiter);

                var Callisto = new KeplerBI.DB.NaturalCelesticalBodies.Moon
                {
                    Name = "Callisto",
                    EquatorialDiameter = mko.Newton.Length.DiameterJupiterMoonCallisto,
                    Gravity = mko.Newton.Acceleration.GravityOnJupiterMoonCallisto,
                    Mass = mko.Newton.Mass.MassOfJupiterMoonCallisto,
                    MeanSurfaceTemp = 134.0 - 273.0,
                };
                ORM.CelesticalBodies.Add(Callisto);

                var Ganymede = new KeplerBI.DB.NaturalCelesticalBodies.Moon
                {
                    Name = "Ganymed",
                    EquatorialDiameter = mko.Newton.Length.DiameterJupiterMoonGanymede,
                    Gravity = mko.Newton.Acceleration.GravityOnJupiterMoonGanymede,
                    Mass = mko.Newton.Mass.MassOfJupiterMoonGanymede,
                    MeanSurfaceTemp = 110.0 - 273.0,
                };
                ORM.CelesticalBodies.Add(Ganymede);

                var IO = new KeplerBI.DB.NaturalCelesticalBodies.Moon
                {
                    Name = "Io",
                    EquatorialDiameter = mko.Newton.Length.DiameterJupiterMoonIo,
                    Gravity = mko.Newton.Acceleration.GravityOnJupiterMoonIo,
                    Mass = mko.Newton.Mass.MassOfJupiterMoonIo,
                    MeanSurfaceTemp = 130.0 - 273.0,
                };
                ORM.CelesticalBodies.Add(IO);

                var Europa = new KeplerBI.DB.NaturalCelesticalBodies.Moon
                {
                    Name = "Europa",
                    EquatorialDiameter = mko.Newton.Length.DiameterJupiterMoonEuropa,
                    Gravity = mko.Newton.Acceleration.GravityOnJupiterMoonEuropa,
                    Mass = mko.Newton.Mass.MassOfJupiterMoonEuropa,
                    MeanSurfaceTemp = 102.0 - 273.0,
                };
                ORM.CelesticalBodies.Add(Europa);

                var Jupitermonde = new KeplerBI.DB.CelesticalBodySystem()
                {
                    CentralBody = Jupiter,
                    Orbits = new KeplerBI.DB.Orbit[] {
                        new KeplerBI.DB.Orbit(){
                            Satellite = Callisto,
                            SemiMajorAxis = mko.Newton.Length.SemiMajorAxisJupiterMoonCallisto,
                            MeanVelocityOfCirculation = mko.Newton.Velocity.VelocityOfJupiterMoonCallisto,
                        },
                        new KeplerBI.DB.Orbit(){
                            Satellite = Ganymede,
                            SemiMajorAxis = mko.Newton.Length.SemiMajorAxisJupiterMoonGanymede,
                            MeanVelocityOfCirculation = mko.Newton.Velocity.VelocityOfJupiterMoonGanymede,
                        },
                        new KeplerBI.DB.Orbit(){
                            Satellite = IO,
                            SemiMajorAxis = mko.Newton.Length.SemiMajorAxisJupiterMoonIo,
                            MeanVelocityOfCirculation = mko.Newton.Velocity.VelocityOfJupiterMoonIo,
                        },
                        new KeplerBI.DB.Orbit(){
                            Satellite = Europa,
                            SemiMajorAxis = mko.Newton.Length.SemiMajorAxisJupiterMoonEuropa,
                            MeanVelocityOfCirculation = mko.Newton.Velocity.VelocityOfJupiterMoonEuropa,
                        },


                    },
                };
                ORM.CelesticalBodySystems.Add(Jupitermonde);


                //----------------------------------------------------------------------------------------
                // Saturnsystem

                var Saturn = new NCB.Planet()
                {
                    Name = "Saturn",
                    EquatorialDiameter = mko.Newton.Length.DiameterSaturn,
                    PolarDiameter = mko.Newton.Length.DiameterSaturnPolar,
                    Gravity = mko.Newton.Acceleration.GravityOnSaturn,
                    Mass = mko.Newton.Mass.MassOfSaturn,
                    MeanSurfaceTemp = -139.0
                };
                ORM.CelesticalBodies.Add(Saturn);

                var Titan = new KeplerBI.DB.NaturalCelesticalBodies.Moon
                {
                    Name = "Titan",
                    EquatorialDiameter = mko.Newton.Length.DiameterSaturnMoonTitan,
                    Gravity = mko.Newton.Acceleration.GravityOnSaturnMoonTitan,
                    Mass = mko.Newton.Mass.MassOfSaturnMoonTitan,
                    MeanSurfaceTemp = 94.0 - 273.0,
                };
                ORM.CelesticalBodies.Add(Titan);

                var Enceladus = new KeplerBI.DB.NaturalCelesticalBodies.Moon
                {
                    Name = "Enceladus",
                    EquatorialDiameter = mko.Newton.Length.DiameterSaturnMoonEnceladus,
                    Gravity = mko.Newton.Acceleration.GravityOnSaturnMoonEnceladus,
                    Mass = mko.Newton.Mass.MassOfSaturnMoonEnceladus,
                    MeanSurfaceTemp = 75.0 - 273.0,
                };
                ORM.CelesticalBodies.Add(Enceladus);

                var Saturnmonde = new KeplerBI.DB.CelesticalBodySystem()
                {
                    CentralBody = Saturn,
                    Orbits = new KeplerBI.DB.Orbit[] {
                        new KeplerBI.DB.Orbit(){
                            Satellite = Titan,
                            SemiMajorAxis = mko.Newton.Length.SemiMajorAxisSaturnMoonTitan,
                            MeanVelocityOfCirculation = mko.Newton.Velocity.VelocityOfSaturnMoonTitan,
                        },
                        new KeplerBI.DB.Orbit(){
                            Satellite = Enceladus,
                            SemiMajorAxis = mko.Newton.Length.SemiMajorAxisSaturnMoonEnceladus,
                            MeanVelocityOfCirculation = mko.Newton.Velocity.VelocityOfSaturnMoonEnceladus,
                        },
                    },
                };
                ORM.CelesticalBodySystems.Add(Saturnmonde);


                //-----------------------------------------------------------------------------------------------
                // Uranussystem

                var Uranus = new NCB.Planet()
                {
                    Name = "Uranus",
                    EquatorialDiameter = mko.Newton.Length.DiameterUranus,
                    PolarDiameter = mko.Newton.Length.DiameterUranusPolar,
                    Gravity = mko.Newton.Acceleration.GravityOnUranus,
                    Mass = mko.Newton.Mass.MassOfUranus,
                    MeanSurfaceTemp = 273 - 197.0
                };
                ORM.CelesticalBodies.Add(Uranus);


                var Miranda = new NCB.Moon()
                {
                    Name = "Miranda",
                    EquatorialDiameter = mko.Newton.Length.Kilometer(481),
                    PolarDiameter = mko.Newton.Length.Kilometer(468.4),
                    Gravity = mko.Newton.Acceleration.MeterPerSec2(0.079),
                    Mass = mko.Newton.Mass.Kilogram(6.59e19),
                    MeanSurfaceTemp = 273 - 189
                };
                ORM.CelesticalBodies.Add(Miranda);


                var Ariel = new NCB.Moon()
                {
                    Name = "Ariel",
                    EquatorialDiameter = mko.Newton.Length.Kilometer(1162.2),
                    PolarDiameter = mko.Newton.Length.Kilometer(1155.8),
                    Gravity = mko.Newton.Acceleration.MeterPerSec2(0.27),
                    Mass = mko.Newton.Mass.Kilogram(1.353e21),
                    MeanSurfaceTemp = 273 - 189
                };
                ORM.CelesticalBodies.Add(Ariel);


                var Titania = new NCB.Moon()
                {
                    Name = "Titania",
                    EquatorialDiameter = mko.Newton.Length.Kilometer(1577.8),
                    PolarDiameter = mko.Newton.Length.Kilometer(1577.8),
                    Gravity = mko.Newton.Acceleration.MeterPerSec2(0.387),
                    Mass = mko.Newton.Mass.Kilogram(3.527e21),
                    MeanSurfaceTemp = 273 - 213
                };
                ORM.CelesticalBodies.Add(Titania);





                //-----------------------------------------------------------------------------------------------
                // Neptunsystem
                var Neptun = new NCB.Planet()
                {
                    Name = "Neptun",
                    EquatorialDiameter = mko.Newton.Length.DiameterNeptune,
                    PolarDiameter = mko.Newton.Length.DiameterNeptunePolar,
                    Gravity = mko.Newton.Acceleration.GravityOnNeptune,
                    Mass = mko.Newton.Mass.MassOfNeptune,
                    MeanSurfaceTemp = -201.0
                };
                ORM.CelesticalBodies.Add(Neptun);

                var Triton = new KeplerBI.DB.NaturalCelesticalBodies.Moon
                {
                    Name = "Triton",
                    EquatorialDiameter = mko.Newton.Length.DiameterNeptuneMoonTriton,
                    Gravity = mko.Newton.Acceleration.GravityOnNeptuneMoonTriton,
                    Mass = mko.Newton.Mass.MassOfNeptuneMoonTriton,
                    MeanSurfaceTemp = -237.5,
                };
                ORM.CelesticalBodies.Add(Triton);



                var Neptunmonde = new KeplerBI.DB.CelesticalBodySystem()
                {
                    CentralBody = Saturn,
                    Orbits = new KeplerBI.DB.Orbit[] {
                        new KeplerBI.DB.Orbit(){
                            Satellite = Triton,
                            SemiMajorAxis = mko.Newton.Length.SemiMajorAxisNeptuneMoonTriton,
                            MeanVelocityOfCirculation = mko.Newton.Velocity.VelocityOfNeptuneMoonTriton,
                        },                       
                    },
                };
                ORM.CelesticalBodySystems.Add(Neptunmonde);

                //-----------------------------------------------------------------------------------------------
                // Alles zum Solarsystem kombinieren

                var Solarsystem = new KeplerBI.DB.CelesticalBodySystem()
                {
                    CentralBody = Sonne,
                    Orbits = new KeplerBI.DB.Orbit[] {
                        new KeplerBI.DB.Orbit(){
                            Satellite = Merkur,
                            SemiMajorAxis = mko.Newton.Length.SemiMajorAxisMercury,
                            MeanVelocityOfCirculation = mko.Newton.Velocity.VelocityOfMercury,
                        },  
                        new KeplerBI.DB.Orbit(){
                            Satellite = Venus,
                            SemiMajorAxis = mko.Newton.Length.SemiMajorAxisVenus,
                            MeanVelocityOfCirculation = mko.Newton.Velocity.VelocityOfVenus,
                        },   
                        new KeplerBI.DB.Orbit(){
                            Satellite = Earth,
                            SemiMajorAxis = mko.Newton.Length.SemiMajorAxisEarth,
                            MeanVelocityOfCirculation = mko.Newton.Velocity.VelocityOfEarth,
                        }, 
                        new KeplerBI.DB.Orbit(){
                            Satellite = Mars,
                            SemiMajorAxis = mko.Newton.Length.SemiMajorAxisMars,
                            MeanVelocityOfCirculation = mko.Newton.Velocity.VelocityOfMars,
                        },
                        new KeplerBI.DB.Orbit(){
                            Satellite = Jupiter,
                            SemiMajorAxis = mko.Newton.Length.SemiMajorAxisJupiter,
                            MeanVelocityOfCirculation = mko.Newton.Velocity.VelocityOfJupiter,
                        },
                        new KeplerBI.DB.Orbit(){
                            Satellite = Saturn,
                            SemiMajorAxis = mko.Newton.Length.SemiMajorAxisSaturn,
                            MeanVelocityOfCirculation = mko.Newton.Velocity.VelocityOfSaturn,
                        },  
                        new KeplerBI.DB.Orbit(){
                            Satellite = Uranus,
                            SemiMajorAxis = mko.Newton.Length.SemiMajorAxisUranus,
                            MeanVelocityOfCirculation = mko.Newton.Velocity.VelocityOfUranus,
                        },  
                        new KeplerBI.DB.Orbit(){
                            Satellite = Neptun,
                            SemiMajorAxis = mko.Newton.Length.SemiMajorAxisNeptune,
                            MeanVelocityOfCirculation = mko.Newton.Velocity.VelocityOfNeptune,
                        },    
                    },
                };
                ORM.CelesticalBodySystems.Add(Solarsystem);


                ORM.SaveChanges();

            }
        }        
    }
}
