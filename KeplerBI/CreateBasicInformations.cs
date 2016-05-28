//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 10.5.2016
//
//  Projekt.......: KeplerBI
//  Name..........: CreateBasicInformations.cs
//  Aufgabe/Fkt...: Astronomische Daten für Einsteiger
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

namespace KeplerBI
{
    public class CreateBasicInformations
    {
        public static void DoIt(IAstroCatalog UofW)
        {

            mko.Newton.Init.Do();

            UofW.CreateStar("Beteigeuze");
            UofW.SubmitChanges();

            var Beteigeuze = UofW.Stars.GetBo("Beteigeuze");
            Beteigeuze.SpectralClass = NaturalCelesticalBodies.SpectralClasses.M;
            Beteigeuze.Mass = 20.0 * mko.Newton.Mass.Kilogram(mko.Newton.Mass.MassOfSun);
            Beteigeuze.Gravity = mko.Newton.Acceleration.MeterPerSec2(0);
            Beteigeuze.EquatorialDiameter = 662 * mko.Newton.Length.Kilometer(mko.Newton.Length.DiameterSun);
            Beteigeuze.PolarDiameter = Beteigeuze.EquatorialDiameter;
            Beteigeuze.MeanSurfaceTemp = 3450;
            Beteigeuze.LuminosityInMulitiplesOfSun = 150000;
            UofW.SubmitChanges();

            UofW.CreateStar("Bellatrix");
            UofW.SubmitChanges();

            var Bellatrix = UofW.Stars.GetBo("Bellatrix");
            Bellatrix.SpectralClass = NaturalCelesticalBodies.SpectralClasses.B;
            Bellatrix.EquatorialDiameter = 6 * mko.Newton.Length.Kilometer(mko.Newton.Length.DiameterSun);
            Bellatrix.Mass = 8.0 * mko.Newton.Mass.Kilogram(mko.Newton.Mass.MassOfSun);
            Bellatrix.MeanSurfaceTemp = 22000;           
            Bellatrix.LuminosityInMulitiplesOfSun = 4000;
            UofW.SubmitChanges();


            // Rigel
            UofW.CreateStar("Rigel");
            UofW.SubmitChanges();

            var Rigel = UofW.Stars.GetBo("Rigel");            
            Rigel.EquatorialDiameter = 80 * mko.Newton.Length.Kilometer(mko.Newton.Length.DiameterSun);
            Rigel.Mass = 21.0 * mko.Newton.Mass.Kilogram(mko.Newton.Mass.MassOfSun);
            Rigel.MeanSurfaceTemp = 12100;
            Rigel.SpectralClass = NaturalCelesticalBodies.SpectralClasses.B;
            Rigel.LuminosityInMulitiplesOfSun = 120000;
            UofW.SubmitChanges();


            UofW.CreateStar("Proxima Centauri");
            UofW.SubmitChanges();

            var ProximaCentauri = UofW.Stars.GetBo("Proxima Centauri");
            ProximaCentauri.EquatorialDiameter = 0.141 * mko.Newton.Length.Kilometer(mko.Newton.Length.DiameterSun);
            ProximaCentauri.Mass = 0.123 * mko.Newton.Mass.Kilogram(mko.Newton.Mass.MassOfSun);
            ProximaCentauri.MeanSurfaceTemp = 3042;
            ProximaCentauri.SpectralClass = NaturalCelesticalBodies.SpectralClasses.M;
            ProximaCentauri.LuminosityInMulitiplesOfSun = 0.0017;
            UofW.SubmitChanges();

            UofW.CreateStar("Sonne");
            UofW.SubmitChanges();

            var Sonne = UofW.Stars.GetBo("Sonne");
            Sonne.SpectralClass = KeplerBI.NaturalCelesticalBodies.SpectralClasses.G;
            Sonne.Mass = mko.Newton.Mass.MassOfSun;
            Sonne.Gravity = mko.Newton.Acceleration.GravityOnSun;
            Sonne.MeanSurfaceTemp = 5778.0 - 273.0;
            Sonne.PolarDiameter = mko.Newton.Length.DiameterSun;
            Sonne.EquatorialDiameter = mko.Newton.Length.DiameterSun;
            Sonne.LuminosityInMulitiplesOfSun = 1;
            UofW.SubmitChanges();

            UofW.CreatePlanet("Merkur", Sonne, mko.Newton.Length.SemiMajorAxisMercury, mko.Newton.Velocity.VelocityOfMercury);
            UofW.SubmitChanges();

            var Merkur = UofW.Planets.GetBo("Merkur");
            Merkur.EquatorialDiameter = mko.Newton.Length.DiameterMercury;
            Merkur.PolarDiameter = mko.Newton.Length.DiameterMercury;
            Merkur.Gravity = mko.Newton.Acceleration.GravityOnMercury;
            Merkur.Mass = mko.Newton.Mass.MassOfMercury;
            Merkur.MeanSurfaceTemp = 167;
            UofW.SubmitChanges();


            UofW.CreatePlanet("Venus", Sonne, mko.Newton.Length.SemiMajorAxisVenus, mko.Newton.Velocity.VelocityOfVenus);
            UofW.SubmitChanges();

            var Venus = UofW.Planets.GetBo("Venus");

            Venus.EquatorialDiameter = mko.Newton.Length.DiameterVenus;
            Venus.PolarDiameter = mko.Newton.Length.DiameterVenus;
            Venus.Gravity = mko.Newton.Acceleration.GravityOnVenus;
            Venus.Mass = mko.Newton.Mass.MassOfVenus;
            Venus.MeanSurfaceTemp = 464.0;
            UofW.SubmitChanges();

            ////-------------------------------------------------------------------------------
            //// Erdsystem

            UofW.CreatePlanet("Erde", Sonne, mko.Newton.Length.SemiMajorAxisEarth, mko.Newton.Velocity.VelocityOfEarth);
            UofW.SubmitChanges();

            var Earth = UofW.Planets.GetBo("Erde");
            Earth.EquatorialDiameter = mko.Newton.Length.DiameterEarth;
            Earth.PolarDiameter = mko.Newton.Length.DiameterEarthPolar;
            Earth.Gravity = mko.Newton.Acceleration.GravityOnEarth;
            Earth.Mass = mko.Newton.Mass.MassOfEarth;
            Earth.MeanSurfaceTemp = 15.0;
            UofW.SubmitChanges();

            UofW.CreateMoon("Erdmond", Earth, mko.Newton.Length.SemiMajorAxisEarthMoon, mko.Newton.Velocity.VelocityOfEarthMoon);
            UofW.SubmitChanges();

            var Moon = UofW.Moons.GetBo("Erdmond");
            Moon.EquatorialDiameter = mko.Newton.Length.DiameterEarthMoon;
            Moon.PolarDiameter = mko.Newton.Length.DiameterEarthMoonPolar;
            Moon.Gravity = mko.Newton.Acceleration.GravityOnEarthMoon;
            Moon.Mass = mko.Newton.Mass.MassOfEarthMoon;
            Moon.MeanSurfaceTemp = -170;
            UofW.SubmitChanges();


            ////--------------------------------------------------------------------------------
            //// Marssystem

            UofW.CreatePlanet("Mars", Sonne, mko.Newton.Length.SemiMajorAxisMars, mko.Newton.Velocity.VelocityOfMars);
            UofW.SubmitChanges();

            var Mars = UofW.Planets.GetBo("Mars");
            Mars.EquatorialDiameter = mko.Newton.Length.DiameterMars;
            Mars.PolarDiameter = mko.Newton.Length.DiameterMarsPolar;
            Mars.Gravity = mko.Newton.Acceleration.GravityOnMars;
            Mars.Mass = mko.Newton.Mass.MassOfMars;
            Mars.MeanSurfaceTemp = -55.0;
            UofW.SubmitChanges();

            UofW.CreateMoon("Phobos", Mars, mko.Newton.Length.SemiMajorAxisMoonPhobos, mko.Newton.Velocity.VelocityOfMarsMoonPhobos);
            UofW.SubmitChanges();

            var Phobos = UofW.Moons.GetBo("Phobos");
            Phobos.EquatorialDiameter = mko.Newton.Length.DiameterMarsMoonPhobos;
            Phobos.Gravity = mko.Newton.Acceleration.GravityOnMarsMoonPhobos;
            Phobos.Mass = mko.Newton.Mass.MassOfMarsMoonPhobos;
            Phobos.MeanSurfaceTemp = 268.0 - 273.0;
            UofW.SubmitChanges();

            UofW.CreateMoon("Deimos", Mars, mko.Newton.Length.SemiMajorAxisMoonDeimos, mko.Newton.Velocity.VelocityOfMarsMoonDeimos);
            UofW.SubmitChanges();

            var Deimos = UofW.Moons.GetBo("Deimos");

            Deimos.EquatorialDiameter = mko.Newton.Length.DiameterMarsMoonDeimos;
            Deimos.Gravity = mko.Newton.Acceleration.GravityOnMarsMoonDeimos;
            Deimos.Mass = mko.Newton.Mass.MassOfMarsMoonDeimos;
            Deimos.MeanSurfaceTemp = 268.0 - 273.0;
            UofW.SubmitChanges();

            ////---------------------------------------------------------------------------------------
            //// Jupitersystem

            UofW.CreatePlanet("Jupiter", Sonne, mko.Newton.Length.SemiMajorAxisJupiter, mko.Newton.Velocity.VelocityOfJupiter);
            UofW.SubmitChanges();

            var Jupiter = UofW.Planets.GetBo("Jupiter");
            Jupiter.HasRings = true;
            Jupiter.EquatorialDiameter = mko.Newton.Length.DiameterJupiter;
            Jupiter.PolarDiameter = mko.Newton.Length.DiameterJupiterPolar;
            Jupiter.Gravity = mko.Newton.Acceleration.GravityOnJupiter;
            Jupiter.Mass = mko.Newton.Mass.MassOfJupiter;
            Jupiter.MeanSurfaceTemp = -108.0;
            UofW.SubmitChanges();

            UofW.CreateMoon("Callisto", Jupiter, mko.Newton.Length.SemiMajorAxisJupiterMoonCallisto, mko.Newton.Velocity.VelocityOfJupiterMoonCallisto);
            UofW.SubmitChanges();

            var Callisto = UofW.Moons.GetBo("Callisto");
            Callisto.EquatorialDiameter = mko.Newton.Length.DiameterJupiterMoonCallisto;
            Callisto.Gravity = mko.Newton.Acceleration.GravityOnJupiterMoonCallisto;
            Callisto.Mass = mko.Newton.Mass.MassOfJupiterMoonCallisto;
            Callisto.MeanSurfaceTemp = 134.0 - 273.0;
            UofW.SubmitChanges();


            UofW.CreateMoon("Ganymede", Jupiter, mko.Newton.Length.SemiMajorAxisJupiterMoonGanymede, mko.Newton.Velocity.VelocityOfJupiterMoonGanymede);
            UofW.SubmitChanges();

            var Ganymede = UofW.Moons.GetBo("Ganymede");
            Ganymede.EquatorialDiameter = mko.Newton.Length.DiameterJupiterMoonGanymede;
            Ganymede.Gravity = mko.Newton.Acceleration.GravityOnJupiterMoonGanymede;
            Ganymede.Mass = mko.Newton.Mass.MassOfJupiterMoonGanymede;
            Ganymede.MeanSurfaceTemp = 110.0 - 273.0;
            UofW.SubmitChanges();

            UofW.CreateMoon("Io", Jupiter, mko.Newton.Length.SemiMajorAxisJupiterMoonIo, mko.Newton.Velocity.VelocityOfJupiterMoonIo);
            UofW.SubmitChanges();

            var Io = UofW.Moons.GetBo("Io");
            Io.EquatorialDiameter = mko.Newton.Length.DiameterJupiterMoonIo;
            Io.Gravity = mko.Newton.Acceleration.GravityOnJupiterMoonIo;
            Io.Mass = mko.Newton.Mass.MassOfJupiterMoonIo;
            Io.MeanSurfaceTemp = 130.0 - 273.0;
            UofW.SubmitChanges();

            UofW.CreateMoon("Europa", Jupiter, mko.Newton.Length.SemiMajorAxisJupiterMoonEuropa, mko.Newton.Velocity.VelocityOfJupiterMoonEuropa);
            UofW.SubmitChanges();

            var Europa = UofW.Moons.GetBo("Europa");
            Europa.EquatorialDiameter = mko.Newton.Length.DiameterJupiterMoonEuropa;
            Europa.Gravity = mko.Newton.Acceleration.GravityOnJupiterMoonEuropa;
            Europa.Mass = mko.Newton.Mass.MassOfJupiterMoonEuropa;
            Europa.MeanSurfaceTemp = 102.0 - 273.0;
            UofW.SubmitChanges();

            ////----------------------------------------------------------------------------------------
            //// Saturnsystem

            UofW.CreatePlanet("Saturn", Sonne, mko.Newton.Length.SemiMajorAxisSaturn, mko.Newton.Velocity.VelocityOfSaturn);
            UofW.SubmitChanges();

            var Saturn = UofW.Planets.GetBo("Saturn");
            Saturn.HasRings = true;
            Saturn.EquatorialDiameter = mko.Newton.Length.DiameterSaturn;
            Saturn.PolarDiameter = mko.Newton.Length.DiameterSaturnPolar;
            Saturn.Gravity = mko.Newton.Acceleration.GravityOnSaturn;
            Saturn.Mass = mko.Newton.Mass.MassOfSaturn;
            Saturn.MeanSurfaceTemp = -139.0;
            UofW.SubmitChanges();


            UofW.CreateMoon("Titan", Saturn, mko.Newton.Length.SemiMajorAxisSaturnMoonTitan, mko.Newton.Velocity.VelocityOfSaturnMoonTitan);
            UofW.SubmitChanges();

            var Titan = UofW.Moons.GetBo("Titan");
            Titan.EquatorialDiameter = mko.Newton.Length.DiameterSaturnMoonTitan;
            Titan.Gravity = mko.Newton.Acceleration.GravityOnSaturnMoonTitan;
            Titan.Mass = mko.Newton.Mass.MassOfSaturnMoonTitan;
            Titan.MeanSurfaceTemp = 94.0 - 273.0;
            UofW.SubmitChanges();

            UofW.CreateMoon("Enceladus", Saturn, mko.Newton.Length.SemiMajorAxisSaturnMoonEnceladus, mko.Newton.Velocity.VelocityOfSaturnMoonEnceladus);
            UofW.SubmitChanges();

            var Enceladus = UofW.Moons.GetBo("Enceladus");
            Enceladus.EquatorialDiameter = mko.Newton.Length.DiameterSaturnMoonEnceladus;
            Enceladus.Gravity = mko.Newton.Acceleration.GravityOnSaturnMoonEnceladus;
            Enceladus.Mass = mko.Newton.Mass.MassOfSaturnMoonEnceladus;
            Enceladus.MeanSurfaceTemp = 75.0 - 273.0;
            UofW.SubmitChanges();

            // Dione	Mond	Saturn	377420	km	1127,6	1,096E+21
            UofW.CreateMoon("Dione", Saturn, mko.Newton.Length.Kilometer(377420), mko.Newton.Velocity.KilometerPerSec(10.03));
            UofW.SubmitChanges();            

            var Dione =  UofW.Moons.GetBo("Dione");
            Dione.Mass = mko.Newton.Mass.Kilogram(1.096E+21);
            Dione.EquatorialDiameter = mko.Newton.Length.Kilometer(1127.6);
            UofW.SubmitChanges();

            // Iapetus	Mond	Saturn	3561300	km	1436	1,600E+21
            UofW.CreateMoon("Iapetus", Saturn, mko.Newton.Length.Kilometer(3561300), mko.Newton.Velocity.KilometerPerSec(3.26));
            UofW.SubmitChanges();

            var Iapetus = UofW.Moons.GetBo("Iapetus");
            Iapetus.Mass = mko.Newton.Mass.Kilogram(1.600E+21);
            Iapetus.EquatorialDiameter =  mko.Newton.Length.Kilometer(1436);
            UofW.SubmitChanges();

            // Tethys	Mond	Saturn	294619	km	1062	6,174E+20
            UofW.CreateMoon("Tethys", Saturn, mko.Newton.Length.Kilometer(294619), mko.Newton.Velocity.KilometerPerSec(11.35));
            UofW.SubmitChanges();

            var Tethys = UofW.Moons.GetBo("Tethys");
            Tethys.Mass = mko.Newton.Mass.Kilogram(6.174E+20);
            Tethys.EquatorialDiameter = mko.Newton.Length.Kilometer(1062);
            UofW.SubmitChanges();


            ////-----------------------------------------------------------------------------------------------
            //// Uranussystem

            UofW.CreatePlanet("Uranus", Sonne, mko.Newton.Length.SemiMajorAxisUranus, mko.Newton.Velocity.VelocityOfUranus);
            UofW.SubmitChanges();

            var Uranus = UofW.Planets.GetBo("Uranus");
            Uranus.HasRings = true;
            Uranus.EquatorialDiameter = mko.Newton.Length.DiameterUranus;
            Uranus.PolarDiameter = mko.Newton.Length.DiameterUranusPolar;
            Uranus.Gravity = mko.Newton.Acceleration.GravityOnUranus;
            Uranus.Mass = mko.Newton.Mass.MassOfUranus;
            Uranus.MeanSurfaceTemp = 273 - 197.0;
            UofW.SubmitChanges();

            UofW.CreateMoon("Miranda", Uranus, mko.Newton.Length.Kilometer(130041), mko.Newton.Velocity.KilometerPerSec(6.68));
            UofW.SubmitChanges();

            var Miranda = UofW.Moons.GetBo("Miranda");
            Miranda.EquatorialDiameter = mko.Newton.Length.Kilometer(481);
            Miranda.PolarDiameter = mko.Newton.Length.Kilometer(468.4);
            Miranda.Gravity = mko.Newton.Acceleration.MeterPerSec2(0.079);
            Miranda.Mass = mko.Newton.Mass.Kilogram(6.59e19);
            Miranda.MeanSurfaceTemp = 273 - 189;
            UofW.SubmitChanges();

            UofW.CreateMoon("Ariel", Uranus, mko.Newton.Length.Kilometer(191130), mko.Newton.Velocity.KilometerPerSec(5, 51));
            UofW.SubmitChanges();

            var Ariel = UofW.Moons.GetBo("Ariel");
            Ariel.EquatorialDiameter = mko.Newton.Length.Kilometer(1162.2);
            Ariel.PolarDiameter = mko.Newton.Length.Kilometer(1155.8);
            Ariel.Gravity = mko.Newton.Acceleration.MeterPerSec2(0.27);
            Ariel.Mass = mko.Newton.Mass.Kilogram(1.353e21);
            Ariel.MeanSurfaceTemp = 273 - 189;
            UofW.SubmitChanges();

            UofW.CreateMoon("Titania", Uranus, mko.Newton.Length.Kilometer(436300), mko.Newton.Velocity.KilometerPerSec(3.87));
            UofW.SubmitChanges();

            var Titania = UofW.Moons.GetBo("Titania");
            Titania.EquatorialDiameter = mko.Newton.Length.Kilometer(1577.8);
            Titania.PolarDiameter = mko.Newton.Length.Kilometer(1577.8);
            Titania.Gravity = mko.Newton.Acceleration.MeterPerSec2(0.387);
            Titania.Mass = mko.Newton.Mass.Kilogram(3.527e21);
            Titania.MeanSurfaceTemp = 273 - 213;
            UofW.SubmitChanges();


            ////-----------------------------------------------------------------------------------------------
            //// Neptunsystem

            UofW.CreatePlanet("Neptun", Sonne, mko.Newton.Length.SemiMajorAxisNeptune, mko.Newton.Velocity.VelocityOfNeptune);
            UofW.SubmitChanges();

            var Neptun = UofW.Planets.GetBo("Neptun");

            Neptun.EquatorialDiameter = mko.Newton.Length.DiameterNeptune;
            Neptun.PolarDiameter = mko.Newton.Length.DiameterNeptunePolar;
            Neptun.Gravity = mko.Newton.Acceleration.GravityOnNeptune;
            Neptun.Mass = mko.Newton.Mass.MassOfNeptune;
            Neptun.MeanSurfaceTemp = -201.0;
            UofW.SubmitChanges();

            UofW.CreateMoon("Triton", Neptun, mko.Newton.Length.SemiMajorAxisNeptuneMoonTriton, mko.Newton.Velocity.VelocityOfNeptuneMoonTriton);
            UofW.SubmitChanges();

            var Triton = UofW.Moons.GetBo("Triton");
            Triton.EquatorialDiameter = mko.Newton.Length.DiameterNeptuneMoonTriton;
            Triton.Gravity = mko.Newton.Acceleration.GravityOnNeptuneMoonTriton;
            Triton.Mass = mko.Newton.Mass.MassOfNeptuneMoonTriton;
            Triton.MeanSurfaceTemp = -237.5;
            UofW.SubmitChanges();
        }

    }
}
