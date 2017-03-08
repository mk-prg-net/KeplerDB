//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 23.11.2015
//
//  Projekt.......: DB.Kepler.EF60
//  Name..........: PlanetenCo.cs
//  Aufgabe/Fkt...: Container mit Planeten- Geschäftsobjekten
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

using System.Data.Entity;


namespace DB.Kepler.EF60.Container
{
    /// <summary>
    /// Container mit Planeten- Geschäftsobjekten
    /// </summary>
    public class PlanetenCo : global::Kepler.PlanetenCo<EF60.Himmelskoerper, int>, IDisposable        
    {
        KeplerDBEntities ctx;
        bool ctxIntern = true;

        public PlanetenCo()
        {
            ctx = new KeplerDBEntities();
        }

        public PlanetenCo(KeplerDBEntities ctx)
        {
            ctxIntern = false;
            this.ctx = ctx;
        }

        public void Dispose()
        {
            if (ctxIntern)
            {
                ctx.Dispose();
            }
        }

        public override void AddToCollection(EF60.Himmelskoerper entity)
        {
            ctx.HimmelskoerperTab.Add(entity);
        }

        public override void RemoveFromCollection(EF60.Himmelskoerper entity)
        {
            ctx.HimmelskoerperTab.Remove(entity);
        }

        public bool LazyLoading { get; set; }


        public override IQueryable<EF60.Himmelskoerper> BoCollection
        {
            get {
                //return ctx.HimmelskoerperTab;
                if (LazyLoading)
                    return ctx.HimmelskoerperTab.Where(r => r.HimmelskoerperTyp.ID == (int)global::Kepler.Bo.HimmelskoerperTypen.Planet);
                else
                    return ctx.HimmelskoerperTab.Where(r => r.HimmelskoerperTyp.ID == (int)global::Kepler.Bo.HimmelskoerperTypen.Planet)
                                                .Include(r => r.Sterne_Planeten_MondeTab)
                                                .Include(r => r.HimmelskoerperTyp)
                                                .Include(r => r.TrabantenUmlaufbahnen)
                                                .Include(r => r.TrabantenUmlaufbahnen.Select(rr => rr.Trabant))
                                                .Include(r => r.TrabantenUmlaufbahnen.Select(rr => rr.Trabant.Sterne_Planeten_MondeTab))
                                                .Include(r => r.Umlaufbahn)
                                                .Include(r => r.Umlaufbahn.Zentralobjekt);

            }
        }

        public override EF60.Himmelskoerper CreateBo()
        {
            return CreatePlanet();
        }

        private Himmelskoerper CreatePlanet()
        {
            var hk = ctx.HimmelskoerperTab.Create();
            hk.HimmelskoerperTyp = ctx.HimmelskoerperTypenTab.Single(r => r.ID == (int)global::Kepler.Bo.HimmelskoerperTypen.Planet);
            hk.Sterne_Planeten_MondeTab = ctx.Sterne_Planeten_MondeTab.Create();
            hk.Umlaufbahn = ctx.UmlaufbahnenTab.Create();
            return hk;
        }

        public override Himmelskoerper CreateBoAndAddToCollection()
        {
            var hk = CreatePlanet();
            ctx.HimmelskoerperTab.Add(hk);
            return hk;
        }

        public override Func<EF60.Himmelskoerper, bool> GetBoIDTest(int id)
        {
            return r => r.ID == id;
        }

        public override void SubmitChanges()
        {
            ctx.SaveChanges();
        }

        public override void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public override bool Any(int id)
        {
            return ctx.HimmelskoerperTypenTab.Single(r => r.ID == (int)global::Kepler.Bo.HimmelskoerperTypen.Planet).Himmelskoerper.Any();
        }
    }
}
