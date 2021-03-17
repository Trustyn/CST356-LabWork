using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<List<StudentModel>> GetAllStudents()
        {
            return Ok(_studentService.GetAllStudents());
        }

        [HttpGet("{studentId}")]
        public ActionResult<StudentModel> GetStudent(int studentId)
        {
            var studentModel = _studentService.GetStudentById(studentId);

            if (studentModel != null) {
                return Ok(studentModel);
            } else {
                return NotFound();
            }
        }

    }
}