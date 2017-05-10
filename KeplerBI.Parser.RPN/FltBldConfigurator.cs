//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 27.7.2016
//
//  Projekt.......: KeplerBI.Parser.RPN
//  Name..........: FltBldConfigurator.cs
//  Aufgabe/Fkt...: Konfiguriert einen FilteredSortedSetBuilder eines Repositories 
//                  mit den in RPN verfassten und korrekt eingeparsten Filterdefinitionen.
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
    /// <summary>
    /// Geparste Konfigurationskommandos werden auf einen Planets.FilteredSortedSetBuilder angewendet
    /// 
    /// </summary>
    public class FltBldConfigurator
    {
        ConfigDataToken[] configDatas;

        public FltBldConfigurator(Stack<mko.RPN.IToken> stack)
        {
            // Umkopieren, um richtige Ausführungsreihenfolge zu erhalten
            configDatas = stack.ToArray().Select(t => (ConfigDataToken)t).ToArray();
            Array.Reverse(configDatas);
        }

        public void Apply<TEntity>(KeplerBI.NaturalCelesticalBodies.Repositories.INCB_FilteredSortedSetBuilder<TEntity> bld)
            where TEntity : KeplerBI.NaturalCelesticalBodies.INaturalCelesticalBody
        {
            // FilteredSortedSetBuilder über Kommandos konfigurieren

            foreach (var data in configDatas)
            {
                if (data is DiameterRngData)
                {
                    var tdata = (DiameterRngData)data;
                    bld.defAequatorialDiameterRange(mko.Newton.Length.Meter(tdata.Min), mko.Newton.Length.Meter(tdata.Max));
                }
                else if (data is MassRngData)
                {
                    var tdata = (MassRngData)data;
                    bld.defMassRange(mko.Newton.Mass.EarthMasses(tdata.minEM), mko.Newton.Mass.EarthMasses(tdata.maxEM));
                }
                else if (data is OrderByMassData)
                {
                    var tdata = (OrderByMassData)data;
                    bld.OrderByMass(tdata.descending);
                }
                else if (data is OrderBySemiMajorAxisLengthData)
                {
                    var tdata = (OrderBySemiMajorAxisLengthData)data;
                    bld.OrderBySemiMajorAxisLength(tdata.descending);
                }
                else if (data is OrderByDiameter)
                {
                    var tdata = (OrderByDiameter)data;
                    bld.OrderByAequatorialDiameter(tdata.descending);
                }
                else if (data is SemiMajorAxisLengthRngData)
                {
                    var tdata = (SemiMajorAxisLengthRngData)data;
                    bld.defSemiMajorAxisLengthRange(mko.Newton.Length.Meter(tdata.Min), mko.Newton.Length.Meter(tdata.Max));
                }
                else if (data is NameLikeData)
                {
                    var tdata = (NameLikeData)data;
                    bld.defNameLike(tdata.Pattern);
                }
                else if (data is SkipData)
                {
                    var tdata = (SkipData)data;
                    bld.defSkip(tdata.count);
                }
                else if (data is TakeData)
                {
                    var tdata = (TakeData)data;
                    bld.defTake(tdata.count);
                }

            }
        }

        public void ApplyAstro(KeplerBI.NaturalCelesticalBodies.Repositories.IAsteroidsCo_FilteredSortedSetBuilder bld)
        {
            Apply(bld);

            foreach (var data in configDatas)
            {
                if (data is AlbedoRng)
                {
                    var tdata = (AlbedoRng)data;
                    bld.defAlbedoRange(tdata.min, tdata.max);
                }
                else if (data is OrderByAlbedo)
                {
                    var tdata = (OrderByAlbedo)data;
                    bld.OrderByAlbedo(tdata.descending);
                }

            }

        }


    }
}
