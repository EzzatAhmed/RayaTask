using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RayaTask.Model;
using RayaTask.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RayaTask.Model.Locations;

namespace RayaTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortestPath : ControllerBase
    {
        //Pathing user location and all locations to get nearest location and path to the user
        [HttpGet("~/GetMapResponses")]
        public List<MapResponse> GetMapResponses(List<MapRequest> mapRequests)
        {
            if (mapRequests.Count>0)
            {
                ShortestPathService shortestPathService = new ShortestPathService(mapRequests);
                var response = shortestPathService.GetShortestPathBetweenMultiLocation(mapRequests);
                return response;
            }
            else
            {
                //Dummy Object to test
                var response = new MapResponse();
                response.LocationName = "Ezzat";
                var res = new List<MapResponse>();
                res.Add(response);
                return res;
            }
        }

        //Getting all locations 
        [HttpGet("~/GetAllLocations")]
        public List<Location> GetAllLocations()
        {
            var l = new Locations();
            return l.GetLatlngValues();

        }


    }
}
