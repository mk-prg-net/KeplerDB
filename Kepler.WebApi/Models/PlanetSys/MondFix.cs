using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Runtime.Serialization;

namespace Kepler.WebApi.Models.PlanetSys
{
    [DataContract]
    public class MondFix : IMond
    {

        public MondFix() {
            mond = new DB.Kepler.EF60.Himmelskoerper();
        }

        public MondFix(Kepler.IMond mond)
        {
            this.mond = mond;
        }
        IMond mond;


        [DataMember]
        public double Masse_in_Erdmondmassen
        {
            get
            {
                return mond.Masse_in_Erdmondmassen;
            }
            set
            {
                mond.Masse_in_Erdmondmassen = value;
            }
        }

        [DataMember]
        public double Aequatordurchmesser_in_km
        {
            get
            {
                return mond.Aequatordurchmesser_in_km;
            }
            set
            {
                mond.Aequatordurchmesser_in_km = value;
            }
        }

        [DataMember]
        public double Polardurchmesser_in_km
        {
            get
            {
                return mond.Polardurchmesser_in_km;
            }
            set
            {
                mond.Polardurchmesser_in_km = value;
            }
        }

        [DataMember]
        public double Oberflaechentemperatur_in_K
        {
            get
            {
                return mond.Oberflaechentemperatur_in_K;
            }
            set
            {
                mond.Oberflaechentemperatur_in_K = value;
            }
        }

        [DataMember]
        public double Rotationsperiode_in_Stunden
        {
            get
            {
                return mond.Rotationsperiode_in_Stunden;
            }
            set
            {
                mond.Rotationsperiode_in_Stunden = value;
            }
        }

        [DataMember]
        public double Fallbeschleunigung_in_meter_pro_sec
        {
            get
            {
                return mond.Fallbeschleunigung_in_meter_pro_sec;
            }
            set
            {
                mond.Fallbeschleunigung_in_meter_pro_sec = value;
            }
        }

        [DataMember]
        public double Rotationsachsenneigung_in_Grad
        {
            get
            {
                return mond.Rotationsachsenneigung_in_Grad;
            }
            set
            {
                mond.Rotationsachsenneigung_in_Grad = value;
            }
        }

        [DataMember]
        public string Name
        {
            get
            {
                return mond.Name;
            }
            set
            {
                mond.Name = value;
            }
        }

        [DataMember]
        public double Masse_in_kg
        {
            get
            {
                return mond.Masse_in_kg;
            }
            set
            {
                mond.Masse_in_kg = value;
            }
        }

        public IUmlaufbahn Umlaufbahn
        {
            get
            {
                return mond.Umlaufbahn;
            }
            set
            {
                mond.Umlaufbahn = value;
            }
        }
    }
}