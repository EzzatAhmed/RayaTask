using Dijkstra.NET.ShortestPath;
using RayaTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RayaTask.Service
{
    public class ShortestPathService
    {
        private readonly List<MapRequest> _maps;
        public ShortestPathService(List<MapRequest> maps)
        {
            this._maps = maps;
        }
        //Get all locations & filter it from nearest to longest distence
        public List<MapResponse> GetShortestPathBetweenMultiLocation(List<MapRequest> mapRequests)
        {
            var res = new List<MapResponse>();
            var req = new List<MapRequest>();
            foreach (var item in mapRequests)
            {
                MapResponse mapResponse = new MapResponse();
                var distance = getDistanceFromLatLonInKm((decimal)item.PinLat, (decimal)item.PinLang, (decimal)item.UserLat, (decimal)item.UserLang);
                //response
                mapResponse.PinLat = item.PinLat;
                mapResponse.PinLang = item.PinLang;
                mapResponse.UserLang = item.UserLang;
                mapResponse.UserLat = item.UserLat;
                mapResponse.Distance = distance;
                res.Add(mapResponse);
               
            }
            res.OrderBy(x => x.Distance).ToList();
            return res;
            

        }
        //compare between two locations and get distance between them
        public decimal getDistanceFromLatLonInKm(decimal lat1,decimal lon1,decimal lat2,decimal lon2)
        {
            var R = 6371; // Radius of the earth in km
            var dLat = deg2rad((double)(lat2 - lat1));  // deg2rad below
            var dLon = deg2rad((double)(lon2 - lon1));
            var a =
              Math.Sin((double)(dLat / 2)) * Math.Sin((double)(dLat / 2)) +
              Math.Cos(deg2rad((double)lat1)) * Math.Cos(deg2rad((double)lat2)) *
              Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
              ;
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c; // Distance in km
            return (decimal)d;
        }
        //math eque
        public double deg2rad(double deg)
        {
            return deg * (Math.PI / 180);
        }
    }
}
