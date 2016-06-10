using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB
{
    public class DBUtil
    {


        public static void CreateDB()
        {
            using (var ORM = new KeplerDBContext())
            {
                ORM.Database.Delete();
                ORM.Database.Create();
                if (true)
                {
                    //foreach (var app in mko.Algo.ForEachEnumMember<KeplerBI.SpaceShips.Application>.Get())
                    //{
                    //    var dbApp = ORM.Applications.Create();
                    //    dbApp.ApplicationID = (int)app;
                    //    dbApp.Description = app.ToString();

                    //    ORM.Applications.Add(dbApp);
                    //}

                    foreach (var cbTypeId in mko.Algo.ForEachEnumMember<KeplerBI.DB.CelesticalBodyType>.Get())
                    {
                        var cbTypeDescr = ORM.CelesticalBodyTypes.Create();
                        cbTypeDescr.Type = cbTypeId;
                        cbTypeDescr.Name = cbTypeId.ToString();

                        ORM.CelesticalBodyTypes.Add(cbTypeDescr);
                    }

                    ORM.SaveChanges();

                    var UofW = new AstroCatalog(ORM);
                    Dataimport.CreateBasicInformations.DoIt(UofW);

                }
            }
        }
    }
}
