using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Config.Repositories
{
    public class ConfigStringsCo : KeplerBI.Config.Repositories.IConfigStringsCo
    {
        KeplerDBContext ctx;

        public ConfigStringsCo(KeplerDBContext ctx)
        {
            this.ctx = ctx;
        }

        public bool ExistsBo(string id)
        {
            return ctx.ConfigStrings.Any(r => r.Name == id);
        }

        public KeplerBI.Config.IConfigString GetBo(string id)
        {
            return ctx.ConfigStrings.Find(id);
        }
    }
}
