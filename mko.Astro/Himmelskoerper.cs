//<unit_header>
//----------------------------------------------------------------
// Copyright 2016 Martin Korneffel
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 10.2.2016
//
//  Projekt.......: Basics
//  Name..........: Himmelskörper.cs
//  Aufgabe/Fkt...: Demo einer abstrakten Basisklasse.
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

namespace mko.Astro
{
    // Da die Klasse eine abstrakte Methode enthält, muss sie als abstrakt 
    // gekennzeichnet werden.
    public abstract class Himmelskoerper
    {
        /// <summary>
        ///  Eine Default- Implementierung für den Namen auf Basis eines _Name
        ///  Feldes ist allgemein eine Ressourcenverschwendung, da jedes Objekt,
        ///  egal ob seine Klasse Name überschreibt oder nicht, das Feld _Name 
        ///  besitzen würde. Deshalb ist die Entscheidung für eine abstrakte Name
        ///  Eigenschaft hier die Richtige. 
        ///  Abstrakte Eigenschaften haben keine Implementierungen für die Getter 
        ///  und Setter. Diese müssen in abgeleiteten Klassen implementiert werden.
        /// </summary>
        public abstract string Name
        {
            get;
        }        

        // Eine allgemeine Berechnungsvorschrift für Massen existiert nicht.
        // Abstracte Methoden sind virtuelle Methoden, für die keine sinvolle 
        // implementierung in der Basisklasse existiert
        protected abstract double BerechneMasseInKg();

        /// <summary>
        /// Liefert die Masse in Kg. Triviale Implementierung
        /// </summary>
        public double Masse_in_kg {
            get
            {
                return BerechneMasseInKg();
            }
        }

        // Eine Basisklasse ist sinvoll, wenn Implementierungen von Eigenschaften und Methoden
        // existieren, die in abgeleiteten Klassen gültig bleiben. Folgende Implementierungen
        // für Getter erfüllen diese Anforderung.

        /// <summary>
        /// Masse in Vielfachen der Erdmasse
        /// </summary>
        public double Masse_in_Erdmassen
        {
            get
            {
                return Masse_in_kg / mko.Newton.Mass.Kilogram(mko.Newton.Mass.MassOfEarth).Value;
            }
        }

        /// <summary>
        /// Masse in Vielfachen der Sonnenmasse
        /// </summary>
        public double Masse_in_Sonnenmassen
        {
            get
            {
                return Masse_in_kg / mko.Newton.Mass.Kilogram(mko.Newton.Mass.MassOfSun).Value;
            }
        }



    }
}
