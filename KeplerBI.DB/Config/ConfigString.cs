﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Config
{
    public class ConfigString : KeplerBI.Config.IConfigString
    {
        public string Name
        {
            get;
            set;
        }

        public string Value
        {
            get;            
            set;
        }
    }
}