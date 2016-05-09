using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KBISpaceShips = KeplerBI.SpaceShips;

namespace KeplerBI.DB.Workflows
{
    class SpaceShipAssembler : KeplerBI.Workflows.CreateCelesticalBody.SpaceShipAssembler
    {
        protected virtual KeplerDBContext CreateORM()
        {
            return new KeplerDBContext();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SpaceShip"></param>
        /// <param name="Applications"></param>
        /// <returns></returns>
        public override void SetAreasOfApplication(KBISpaceShips.ISpaceShip SpaceShip, IEnumerable<KBISpaceShips.Application> Applications)
        {
            try
            {
                using (var ORM = CreateORM())
                {

                    // Prüfen, ob alle Anwendungen bereits erfasst sind, aufbauen einer Liste aus zu den Anwendungen korespondierenden
                    // Datensätzen 
                    var DBApplications = new List<SpaceShips.Application>();
                    foreach (var app in Applications)
                        if (!ORM.Applications.Any(r => r.ApplicationID == (int)app))
                            throw new ArgumentException("Die Anwendung " + app.ToString() + " wurde noch nicht erfasst.");
                        else
                            DBApplications.Add(ORM.Applications.Single(r => r.ApplicationID == (int)app));


                    SpaceShips.SpaceShip DBSpaceShip = (SpaceShips.SpaceShip)SpaceShip;

                    // Alle alten Anwendungen löschen
                    DBSpaceShip.Tasks.Clear();

                    // Neue Anwendungen setzen
                    DBSpaceShip.Tasks = DBApplications.Select(app => new SpaceShips.SpaceshipTask() { Application = app, SpaceShip = DBSpaceShip }).ToArray();

                    ORM.SaveChanges();                 
                }
            }
            catch (Exception ex)
            {
                throw new KeplerDBException(mko.TraceHlp.FormatErrMsg(this, "SetAreasOfApplication"), ex);
            }

        }

        public override void SetHomeland(KBISpaceShips.ISpaceShip SpaceShip, ICountry Homeland)
        {
            try
            {
                using (var ORM = CreateORM())
                {
                    SpaceShips.SpaceShip DBSpaceShip = (SpaceShips.SpaceShip)SpaceShip;

                    // Nur ein bereits in der DB definiertes Land darf eingetragen werden
                    if (ORM.Countries.Any(r => r.ISO_3166_1_Key == Homeland.ISO_3166_1_Key))
                    {
                        DBSpaceShip.Homeland = ORM.Countries.Single(r => r.ISO_3166_1_Key == Homeland.ISO_3166_1_Key);
                        
                    }
                    else;
                }
            }
            catch (Exception ex)
            {
                throw new KeplerDBException(mko.TraceHlp.FormatErrMsg(this, "SetHomeland"), ex);
            }
        }
    }
}
