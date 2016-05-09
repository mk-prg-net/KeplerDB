using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Runtime.Serialization;

namespace Kepler.WebApi.Models.PlanetSys
{
    [DataContract]
    public class MondClient : IMond
    {

        public MondClient() {
        }

        [DataMember]
        public double Masse_in_Erdmondmassen
        {
            get;
            set;
        }

        [DataMember]
        public double Aequatordurchmesser_in_km
        {
            get;
            set;
        }

        [DataMember]
        public double Polardurchmesser_in_km
        {
            get;
            set;
        }

        [DataMember]
        public double Oberflaechentemperatur_in_K
        {
            get;
            set;
        }

        [DataMember]
        public double Rotationsperiode_in_Stunden
        {
            get;
            set;
        }

        [DataMember]
        public double Fallbeschleunigung_in_meter_pro_sec
        {
            get;
            set;
        }

        [DataMember]
        public double Rotationsachsenneigung_in_Grad
        {
            get;
            set;
        }

        [DataMember]
        public string Name
        {
            get;
            set;
        }

        [DataMember]
        public double Masse_in_kg
        {
            get;
            set;
        }

        public IUmlaufbahn Umlaufbahn
        {
            get;
            set;
        }
    }
}