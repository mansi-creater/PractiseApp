using BLL.UserController;
using DAL.Model;
using PractiseApp.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace PractiseApp.Controllers
{
    public class StudentController : ApiController
    {
        private IUserControllerBLL _obj;
        public StudentController(IUserControllerBLL obj)
        {
            _obj = obj;
        }

      //  [BasicAuthentication]
        [Route("GetStudents")]
        [HttpGet]
        public IHttpActionResult GetStudents()
        {
            List<Student> stud = _obj.GetStudents();
            return Ok(stud);
        }

        [Route("GetStudentById")]
        [HttpGet]
        public IHttpActionResult GetStudentById(int id)
        {
            Student stud = _obj.GetStudentById(id);
            return Ok(stud);
        }

        [Route("AddStudent")]
        [HttpPost]
        public IHttpActionResult AddStudent(Student stud)
        {
            _obj.AddStudent(stud);
            return Ok("Student Added");
        }

        [Route("UpdateStudent")]
        [HttpPut]
        public IHttpActionResult UpdateStudent(int id, Student stud)
        {
            _obj.UdpateStudent(id, stud);
            return Ok("Student Updated");
        }

        [Route("DeleteStudent")]
        [HttpDelete]
        public IHttpActionResult DeleteStudent(int id)
        {
            _obj.DeleteStudent(id);
            return Ok("Student Deleted");
        }

        [Route("Pagination")]
        [HttpGet]
        public IHttpActionResult Pagination(int pageNumber = 1, int pageSize = 10)
        {
            pagination<Student> stud = _obj.Pagination(pageNumber, pageSize);
            return Ok(stud);
        }

  
        [Route("Login")]
        [HttpPost]
         public IHttpActionResult Login(string Email, string Password)
         {
            var result = ValidateUser.Login(Email, Password);
            if(result == true)
            {               
                return Ok(ValidateUser.GetToken());
            }
            else
            {
                throw new Exception("Id not found");
            }
        }


    }
}
