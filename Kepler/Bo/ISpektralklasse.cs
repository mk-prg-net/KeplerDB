using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler
{

    /// <summary>
    /// Spektralklassen der Sterne
    ///  Siehe https://de.wikipedia.org/wiki/Spektralklasse
    /// </summary>
    /// <remarks></remarks>
    public enum SpektralklasseID
    {
        O = 1,
        B = 2,
        A = 3,
        F = 4,
        G = 5,
        K = 6,
        M = 7,
        L = 8,
        T = 9,
        Y = 10,
        R = 11,
        N = 12,
        S = 13
    }

    /// <summary>
    /// Farben, die mit den Spektralklassen von Sternen korespondieren
    /// </summary>
    public enum Spektralklasse_Farbe
    {
        blau,
        blau_weiss,
        weiss,
        weiss_gelb,
        gelb,
        orange,
        rot_orange,
        rot,
        Infrarot,
    }

    public interface ISpektralklasse
    {
        SpektralklasseID SpektralklasseId { get; set; }
        Spektralklasse_Farbe Farbe { get; set; }
        string FarbeHtml { get;}
        double Tmin { get; set; }
        double Tmax { get; set; }
        double Masse_Hauptreihenstern_in_Sonnenmassen { get; set; }

    }
}
