using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentProfileRestApi.Data;
using StudentProfileRestApi.Models;
using StudentProfileRestApi.Models.StudentDetails;

namespace StudentProfileRestApi.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class StudentAPIController:ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<StudentDetails>> GetStudents()
        {
            return Ok(StudentStore.studentList);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<StudentDetails> GetStudentId(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var student = StudentStore.studentList.FirstOrDefault(u => u.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet(":name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<StudentDetails> GetStudentName(string name)
        {
 
            var student = StudentStore.studentList.FirstOrDefault(u => u.Name.ToLower() == name.ToLower());
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet("role/:role")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<StudentDetails> GetStudentByRole(int role)
        {
            if (role == 0)
            {
                return BadRequest();
            }
            var student = StudentStore.studentList.FirstOrDefault(u => u.Role == role);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet("name/:name/phone/:phone")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<StudentDetails> GetStudentByPhone(int phone)
        {
            if (phone == 0)
            {
                return BadRequest();
            }
            var student = StudentStore.studentList.FirstOrDefault(u => u.Phone == phone);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDetails> CreateStudent([FromBody]StudentDetails studentDetails)
        {
            if(studentDetails == null)
            {
                return BadRequest(studentDetails);
            }
            if (studentDetails.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            studentDetails.Id = StudentStore.studentList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            StudentStore.studentList.Add(studentDetails);

            return Ok(studentDetails);
        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<StudentDetails> DeleteStudent(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var student = StudentStore.studentList.FirstOrDefault(u => u.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            StudentStore.studentList.Remove(student);
            return NoContent();
        }


        [HttpPut("{id:int}")]
        public ActionResult UpdateStudent(int id,[FromBody]StudentDetails studentDetails)
        {
            if (studentDetails == null || id != studentDetails.Id)
            {
                return BadRequest();
            }
            var student = StudentStore.studentList.FirstOrDefault(u => u.Id == id);
            student.Name = studentDetails.Name;
            student.Role = studentDetails.Role;
            student.Phone = studentDetails.Phone;

            return NoContent();
        }
    }
}
