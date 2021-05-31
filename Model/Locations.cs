using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RayaTask.Model
{
     public class Locations
    {

        public class Location {
            public string LocationName { get; set; }

            public double Lang { get; set; }

            public double Lat { get; set; }

            public Location(string LocationName, double Lang, double Lat)
            {
                this.LocationName = LocationName;
                this.Lat = Lat;
                this.Lang = Lang;


            }
            public Location()
            {

            }
        }
   
        //Getting all static locations with their lang and lat values 
        public List<Location> GetLatlngValues()
        {
            List<Location> location = new List<Location>()
            {
               new Location {LocationName="NasrCity",Lang= 31.377033,Lat= 30.016893 },
               new Location {LocationName="Tahir",Lang= 31.377033,Lat= 31.235819 },
               new Location {LocationName="helioplies",Lang= 31.316091,Lat= 30.088850 },
               new Location {LocationName="fifthsettle",Lang= 31.430067,Lat= 30.001922 },
               new Location {LocationName="october",Lang= 30.921919,Lat= 29.952654 },
            };


                return location;
     
       
        }
    }
}
