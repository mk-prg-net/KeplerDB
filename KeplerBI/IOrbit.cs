using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI
{
    public interface IOrbit
    {       

        ICelestialBodyBase Satellite { get; }

     
        mko.Newton.Length SemiMajorAxis {
            get;
            set;             
        }

        
        mko.Newton.Velocity MeanVelocityOfCirculation {
            get;            
            set;            
        }

    }
}
