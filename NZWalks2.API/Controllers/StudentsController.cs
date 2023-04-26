using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks2.API.Controllers
{


    //https://locahost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //GET: api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "John", "Jane", "Mark", "Emily", "David" };

            return Ok(studentNames);
        }

    }
}
