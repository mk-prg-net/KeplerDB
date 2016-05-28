﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.RPN
{
    public class IntToken : IToken
    {
        public IntToken(int Value)
        {
            _Value = Value;
        }

        public bool IsFunctionName
        {
            get { return false; }
        }

        public bool IsInteger
        {
            get { return true; }
        }

        public bool IsBoolean
        {
            get { return false; }
        }

        public bool IsNummeric
        {
            get { return true; }
        }

        public string Value
        {
            get { return _Value.ToString(); }
        }

        int _Value;

        public int ValueAsInt
        {
            get
            {
                return _Value;
            }
        }

    }
}
