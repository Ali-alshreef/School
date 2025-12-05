using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolCore.Models;
using SchoolData.DataDB;

namespace SchoolAPI.MyEndPointApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly SchoolDB db;
        public CityController( SchoolDB schoolDB)
        {
            db = schoolDB;
        }
        [HttpGet("GetCities")]
        public List<City> GetListCities()
        {
            var cities = db.Cities.ToList();
            return cities;
        }
    }
}
