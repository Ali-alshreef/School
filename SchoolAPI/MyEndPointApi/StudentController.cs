using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolCore.Models;
using SchoolData.DataDB;

namespace SchoolAPI.MyEndPointApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolDB db;
        public StudentController(SchoolDB schoolDB)
        {
            db = schoolDB;
        }

        [HttpGet("GetStudents")]
        public List<Student> GetListstudents()
        {
            var cities = db.Students.ToList();
            return cities;
        }
    }
}
