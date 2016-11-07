using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB
{
    public class DBUtil
    {


        public static void CreateDB(KeplerDBContext ORM)
        {

            ORM.Database.Delete();
            ORM.Database.Create();
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
        }
    }
}
