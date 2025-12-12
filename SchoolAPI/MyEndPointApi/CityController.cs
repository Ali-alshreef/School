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

        // POST: api/City/Create
        [HttpPost("Create")]              // 3. يعمل مع طلبات POST
        public IActionResult CreateCity([FromBody] City newCity)
        {
            // 4. التحقق من صحة البيانات
            if (newCity == null)
            {
                return BadRequest("بيانات المدينة فارغة");
            }
            // 5. التحقق من الاسم
            if (string.IsNullOrWhiteSpace(newCity.Name))
            {
                return BadRequest("اسم المدينة مطلوب");
            }


            // 7. إضافة المدينة للقائمة
            db.Cities.Add(newCity);

            db.SaveChanges();

            // 8. إرجاع المدينة المضافة مع الرمز 201
            return CreatedAtAction(nameof(GetCity), new { id = newCity.Id }, newCity);
        }

        // GET: api/City/Get/{id}
        [HttpGet("Get/{id}")]
        public IActionResult GetCity(int id)
        {
            var city = db.Cities.FirstOrDefault(c => c.Id == id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }
    }
}
