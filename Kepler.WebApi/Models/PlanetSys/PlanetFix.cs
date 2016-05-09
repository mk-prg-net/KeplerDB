using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Runtime.Serialization;

namespace Kepler.WebApi.Models.PlanetSys
{
    [DataContract]
    public class PlanetFix // : Kepler.IPlanet
    {
        public PlanetFix() 
        {
            planet = new DB.Kepler.EF60.Himmelskoerper();
        }

        public PlanetFix(Kepler.IPlanet planet)
        {
            this.planet = planet;
        }
        IPlanet planet;

        [DataMember]
        public double Masse_in_Erdmassen
        {
            get
            {
                return planet.Masse_in_Erdmassen;
            }
            set
            {
                planet.Masse_in_Erdmassen = value;
            }
        }

        [DataMember]
        public IEnumerable<MondFix> Monde
        {
            get
            {
                return planet.Monde.Select(r => new MondFix(r)).ToArray();
            }
        }


        [DataMember]
        public double Aequatordurchmesser_in_km
        {
            get
            {
                return planet.Aequatordurchmesser_in_km;
            }
            set
            {
                planet.Aequatordurchmesser_in_km = value;
            }
        }

        [DataMember]
        public double Polardurchmesser_in_km
        {
            get
            {
                return planet.Polardurchmesser_in_km;
            }
            set
            {
                planet.Polardurchmesser_in_km = value;
            }
        }

        [DataMember]
        public double Oberflaechentemperatur_in_K
        {
            get
            {
                return planet.Oberflaechentemperatur_in_K;
            }
            set
            {
                planet.Oberflaechentemperatur_in_K = value;
            }
        }

        [DataMember]
        public double Rotationsperiode_in_Stunden
        {
            get
            {
                return planet.Rotationsperiode_in_Stunden;
            }
            set
            {
                planet.Rotationsperiode_in_Stunden = value;
            }
        }

        [DataMember]
        public double Fallbeschleunigung_in_meter_pro_sec
        {
            get
            {
                return planet.Fallbeschleunigung_in_meter_pro_sec;
            }
            set
            {
                planet.Fallbeschleunigung_in_meter_pro_sec = value;
            }
        }

        [DataMember]
        public double Rotationsachsenneigung_in_Grad
        {
            get
            {
                return planet.Rotationsachsenneigung_in_Grad;
            }
            set
            {
                planet.Rotationsachsenneigung_in_Grad = value;
            }
        }

        [DataMember]
        public string Name
        {
            get
            {
                return planet.Name;
            }
            set
            {
                planet.Name = value;
            }
        }

        [DataMember]
        public double Masse_in_kg
        {
            get
            {
                return planet.Masse_in_kg;
            }
            set
            {
                planet.Masse_in_kg = value;
            }
        }

        //public DB.Kepler.EF60.Umlaufbahn Umlaufbahn
        //{
        //    get
        //    {
        //        return (DB.Kepler.EF60.Umlaufbahn)planet.Umlaufbahn;
        //    }
        //    set
        //    {
        //        planet.Umlaufbahn = value;
        //    }
        //}
    }
}