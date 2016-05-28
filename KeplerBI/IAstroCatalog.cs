//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 27.05.2016
//
//  Projekt.......: KeplerBI
//  Name..........: IAstroCatalog.cs
//  Aufgabe/Fkt...: Schnittstelle eines astronomischen Katalogs.
//                  Implementiert das UnitOfWork Pattern 
//                  (http://martinfowler.com/eaaCatalog/unitOfWork.html)
//                  (http://www.asp.net/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)
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
    public interface IAstroCatalog : mko.BI.Repositories.Interfaces.ISubmitChanges
    {

        NaturalCelesticalBodies.Repositories.IStarsCo Stars { get; }

        /// <summary>
        /// Erzeugt einen neuen Stern, fügt ihn der Liste aller Himmelskörper zu und
        /// legt ein neues Himmelskörpersystem für Planeten, die ihn umrkeisen können.
        /// </summary>
        /// <param name="Name"></param>
        void CreateStar(string Name);


        /// <summary>
        /// Liste aller Planeten
        /// </summary>
        NaturalCelesticalBodies.Repositories.IPlanetsCo Planets { get; }

        /// <summary>
        /// Erzeugt einen Planeten, fügt ihn der Liste aller Himmelskörper zu.
        /// Der Planet wird in einem Planetensystem um einen Stern eingetragen.
        /// Für den Planeten wird ein neues Mondsystem angelegt.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Star">Zentralstern, der umkreist wird</param>
        /// <param name="semiMajorAxisLength">Länge der großen Halbachse</param>
        /// <param name="meanVelocityOfCirculation">mittlere Umlaufgeschwindigkeit</param>
        void CreatePlanet(string Name, NaturalCelesticalBodies.IStar Star, mko.Newton.Length semiMajorAxisLength, mko.Newton.Velocity meanVelocityOfCirculation);

        /// <summary>
        /// Liste der Monde
        /// </summary>
        NaturalCelesticalBodies.Repositories.IMoonsCo Moons { get; }

        /// <summary>
        /// Erzeugt einen Mond, fügt ihn der Liste aller Himmelskörper zu.
        /// Der Mond wird in einem Mondsystem um einen Planeten eingetragen.        
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Planet"></param>
        /// <param name="semiMajorAxisLength"></param>
        /// <param name="meanVelocityOfCirculation"></param>
        void CreateMoon(string Name, NaturalCelesticalBodies.IPlanet Planet, mko.Newton.Length semiMajorAxisLength, mko.Newton.Velocity meanVelocityOfCirculation);


        /// <summary>
        /// Liste aller Himmelskörpersysteme. Ein Himmelskörpersystem besteht aus einem
        /// Zentralkörper, der von anderen Himmelskörpern umlaufen wird.
        /// </summary>
        Repositories.ICelesticslBodySystemsCo CelesticalBodySystems { get; }



    }
}
