//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 10.5.2017
//
//  Projekt.......: KeplerBI.RAM
//  Name..........: Star.Sun.cs
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

namespace KeplerBI.RAM.NaturalCelesticalBodies
{
    partial class Star
    {
        public static Star Sun
        {
            get
            {
                if(_Sun == null)
                {
                    mko.Newton.Init.Do();

                    _Sun = new Star();
                    _Sun.Name = "Sonne";
                    _Sun.Mass = mko.Newton.Mass.MassOfSun;
                    _Sun.Gravity = mko.Newton.Acceleration.GravityOnSun;
                    _Sun.EquatorialDiameter = mko.Newton.Length.DiameterSun;
                    _Sun.LuminosityInMulitiplesOfSun = 1.0;
                    _Sun.SpectralClass = KeplerBI.NaturalCelesticalBodies.SpectralClasses.G;
                    _Sun.PolarDiameter = mko.Newton.Length.DiameterSun;
                }

                return _Sun;
            }
        }

        static Star _Sun;
    }
}
