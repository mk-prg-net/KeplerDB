//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 7.4.2017
//
//  Projekt.......: KeplerBI.Parser.RPN
//  Name..........: Composer.cs
//  Aufgabe/Fkt...: Erzeugt RPN Ausdrücke für KeplerBI auf Basis einer IFunctionName Tabelle
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

namespace KeplerBI.Parser.RPN
{
    public class Composer : mko.RPN.Composer
    {
        IFunctionNames fn;

        public Composer(IFunctionNames fn)
            : base(fn)
        {
            this.fn = fn;            
        }

        // Semantische Descriptorfunktionen in polnischer Notation
        public string semMin(string val)
        {
            return pn(fn.semMin, val);
        }

        public string semMax(string val)
        {
            return pn(fn.semMax, val);
        }

        public string semPattern(string val)
        {
            return pn(fn.semPattern, val);
        }

        public string semCount(string val)
        {
            return pn(fn.semCount, val);
        }

        public string semOrdeByDir(string val)
        {
            return pn(fn.semOrdeByDir, val);
        }


        // Semantische Deskriptorfunktionen in umgekehrt polnischer Notation
        public string rSemMin(string val)
        {
            return rpn(fn.semMin, val);
        }

        public string rSemMax(string val)
        {
            return rpn(fn.semMax, val);
        }

        public string rSemPattern(string val)
        {
            return rpn(fn.semPattern, val);
        }

        public string rSemCount(string val)
        {
            return rpn(fn.semCount, val);
        }

        public string rSemOrdeByDir(string val)
        {
            return rpn(fn.semOrdeByDir, val);
        }


        public string AlbedoRng(string beg, string end)
        {
            return pn(fn.AlbedoRng, semMin(beg), semMax(end));
        }

        public string rAlbedoRng(string beg, string end)
        {
            return rpn(fn.AlbedoRng, rSemMin(beg), rSemMax(end));
        }

        public string AU(string value)
        {
            return pn(fn.AU, value);
        }

        public string rAU(string value)
        {
            return rpn(fn.AU, value);            
        }

        public string ConfigColumn(string col)
        {
            return pn(fn.ConfigColumn, col);
        }

        public string rConfigColumn(string col)
        {
            return rpn(fn.ConfigColumn, col);            
        }

        public string DiameterRng(string beg, string end)
        {
            return pn(fn.DiameterRng, semMin(beg), semMax(end));
        }

        public string rDiameterRng(string beg, string end)
        {
            return rpn(fn.DiameterRng, rSemMin(beg), rSemMax(end));
        }

        public string EM(string value)
        {
            return pn(fn.EM, value);
        }

        public string rEM(string value)
        {
            return rpn(fn.EM, value);            
        }

        public string Kg(string value)
        {
            return pn(fn.Kg, value);
        }

        public string rKg(string value)
        {
            return rpn(fn.Kg, value);            
        }

        public string KM(string value)
        {
            return pn(fn.KM, value);
        }

        public string rKM(string value)
        {
            return rpn(fn.KM, value);            
        }

        public string MassRng(string beg, string end)
        {
            return pn(fn.MassRng, semMin(beg), semMax(end));
        }

        public string rMassRng(string beg, string end)
        {
            return rpn(fn.MassRng, rSemMin(beg), rSemMax(end));
        }

        public string Meter(string value)
        {
            return pn(fn.Meter, value);
        }

        public string rMeter(string value)
        {
            return rpn(fn.Meter, value);            
        }

        public string NameLike(string name)
        {
            return pn(fn.NameLike, semPattern(name));
        }

        public string rNameLike(string name)
        {
            return rpn(fn.NameLike, rSemPattern(name));            
        }

        public string OrderByAlbedo(string direction)
        {
            return pn(fn.OrderByAlbedo, semOrdeByDir(direction));
        }

        public string rOrderByAlbedo(string direction)
        {
            return rpn(fn.OrderByAlbedo, rSemOrdeByDir(direction));
        }

        public string OrderByDiameter(string direction)
        {
            return pn(fn.OrderByDiameter, semOrdeByDir(direction));
        }

        public string rOrderByDiameter(string direction)
        {
            return rpn(fn.OrderByDiameter, rSemOrdeByDir(direction));
        }

        public string OrderByMass(string direction)
        {
            return pn(fn.OrderByMass, semOrdeByDir(direction));
        }

        public string rOrderByMass(string direction)
        {
            return rpn(fn.OrderByMass, rSemOrdeByDir(direction));
        }

        public string OrderBySemiMajorAxisLength(string direction)
        {
            return pn(fn.OrderBySemiMajorAxisLength, semOrdeByDir(direction));
        }

        public string rOrderBySemiMajorAxisLength(string direction)
        {
            return rpn(fn.OrderBySemiMajorAxisLength, rSemOrdeByDir(direction));
        }

        public string SemiMajorAxisLengthRng(string beg, string end)
        {
            return pn(fn.SemiMajorAxisLengthRng, semMin(beg), semMax(end));
        }

        public string rSemiMajorAxisLengthRng(string beg, string end)
        {
            return rpn(fn.SemiMajorAxisLengthRng, rSemMin(beg), rSemMax(end));
        }

        public string Skip(string count)
        {
            return pn(fn.Skip, semCount(count));
        }

        public string rSkip(string count)
        {
            return rpn(fn.Skip, rSemCount(count));            
        }

        public string SM(string count)
        {
            return pn(fn.SM, semCount(count));
        }

        public string rSM(string count)
        {
            return rpn(fn.SM, rSemCount(count));
        }

        public string Take(string count)
        {
            return pn(fn.Take, semCount(count));
        }

        public string rTake(string count)
        {
            return rpn(fn.Take, rSemCount(count));
        }       

    }
}
