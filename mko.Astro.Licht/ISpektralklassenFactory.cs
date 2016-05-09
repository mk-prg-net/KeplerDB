//<unit_header>
//----------------------------------------------------------------
// Copyright 2016 Martin Korneffel
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 11.2.2016
//
//  Projekt.......: mko.Astro.Licht
//  Name..........: ISpektralklassenFactory.cs
//  Aufgabe/Fkt...: Schnittstelle von Klassenfabriken für Spektralklassen- Listen.
//                  Definitionen von Spektralklassen können z.B. aus Daten aus einer 
//                  Datenbank, oder fest kodiert werden.
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

namespace mko.Astro.Licht
{
    /// <summary>
    /// Abstrakte Fabrik für Spektralklassenlisten
    /// </summary>
    public interface ISpektralklassenFactory
    {
        ISpektralklassen Create();
    }
}
