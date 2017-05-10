//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 7.4.2017
//
//  Projekt.......: KeplerBI.Parser.RPN
//  Name..........: IFunctionNames.cs
//  Aufgabe/Fkt...: Liste der Functionsnamen
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
//  Autor.........: Martin Korneffel (mko)
//  Datum.........: 11.4.2017
//  Änderungen....: Aufbau systematischer Namen mittels mko.RPN.Filter
//
//</unit_history>
//</unit_header>        


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    public interface IFunctionNames : mko.RPN.IFunctionNames
    {

        /// <summary>
        /// Liste der systematischen Namenspräfixe für Filter
        /// </summary>
        mko.RPN.Filter.IFilterFunctionNamePrefixes Prefixes { get; }

        /// <summary>
        /// Liste der Klassenfabriken für systematische Filternamen
        /// </summary>
        mko.RPN.Filter.IFilterFunctionNameFactories Factories { get; }


        /// <summary>
        /// True, wenn die Funktion ihren Parameter, der ein Subtree ist, einer Bedeutung zuweist.
        /// Z.B. .rng.Mass EM 2 EM 10 filtert alle Himmelskörper mit mindestens zwei und maximal 
        /// 10 Erdmassen Masse heraus. Die Parameter könnten durch die semantischen 
        /// Descriptorfunktionen ..min und ..max wie folgt dokumentiert werden:
        /// .rng.Mass ..min EM 2 ..max EM 10
        /// Semantische Descriptoren erleichtern die Entwicklung von dynamischen Views für solche ausdrücke.
        /// Semantische Deskriptoren sind immer unär
        /// </summary>
        /// <param name="FunctionName"></param>
        /// <returns></returns>
        bool IsSemanticDescriptor(string FunctionName);

        string ReduceSematicFunctionName(string FunctionName);

        /// <summary>
        /// Semantischer Deskriptor für den Begin eines Bereiches
        /// </summary>
        string semMin { get; }

        /// <summary>
        /// Semantischer Deskriptor für das Ende eines Bereiches
        /// </summary>
        string semMax { get; }


        /// <summary>
        /// Semantischer Deskriptor für die Anzahl innerhalb eines Bereiches
        /// </summary>
        string semCount { get; }


        /// <summary>
        /// Semantischer Deskriptor für ein Wortmuster von Funktionen wie NameLike
        /// </summary>
        string semPattern { get; }


        string semOrdeByDir { get; }


        //------------------------------------------------------------------------------------------
        // Längeneinheiten

        string Meter { get; }

        /// <summary>
        /// Astronomische Einheiten
        /// </summary>
        string AU { get; }

        /// <summary>
        /// Kilometer
        /// </summary>
        string KM { get; }

        // Masseeinheiten
        string Kg { get; }

        /// <summary>
        /// Erdmassen
        /// </summary>
        string EM { get; }

        /// <summary>
        /// Sonnenmassen
        /// </summary>
        string SM { get; }


        // Wählt eine Spalte zur Konfiguration aus. Der Spaltennamen muss definiert werden
        string ConfigColumn { get; }

        /// <summary>
        /// Überspringen der ersten n Datensätze
        /// </summary>
        string Skip { get; }

        /// <summary>
        /// Übernehmen der folgenden n Datensätze
        /// </summary>
        string Take { get; }


        /// <summary>
        /// Massebereichsfilter
        /// </summary>
        string MassRng { get; }

        /// <summary>
        /// Durchmesserbereichsfilter
        /// </summary>
        string DiameterRng { get; }

        /// <summary>
        /// Albedobereichsfilter
        /// </summary>
        string AlbedoRng { get; }


        string NameLike { get; }

        /// <summary>
        /// Bahnradiusbereichsfilter
        /// </summary>
        string SemiMajorAxisLengthRng { get; }



        /// <summary>
        /// Sortieren nach Masse
        /// </summary>
        string OrderByMass { get; }

        /// <summary>
        /// Sortieren nach Durchmesser
        /// </summary>
        string OrderByDiameter { get; }

        /// <summary>
        /// Sortieren nach Albedo
        /// </summary>
        string OrderByAlbedo { get; }


        /// <summary>
        /// Sortieren nach Bahnradius
        /// </summary>
        string OrderBySemiMajorAxisLength { get; }

    }
}
