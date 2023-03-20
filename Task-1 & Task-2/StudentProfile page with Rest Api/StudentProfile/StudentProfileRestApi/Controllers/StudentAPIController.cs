using Microsoft.AspNetCore.Mvc;
using StudentProfileRestApi.Models;

namespace StudentProfileRestApi.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class StudentAPIController:ControllerBase
    {
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student { Id = 1,Name = "Kamran",Role = 101,Phone=01722233445},
                new Student { Id = 2,Name = "Ashraf",Role = 102,Phone=01344455666}
            };
        }

    }
}
