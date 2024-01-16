using Lab3.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Routing;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lab3.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentController : ApiController
    {
        private ApplicationContext _context = new ApplicationContext();
        private string ControllerUrl = "api/students";


        [HttpGet]
        [Route("{id:int}.{type}")]
        [Route("~/api/students/{id:int}")]
        public IHttpActionResult GetStudent(int? id, string columns = "id, name, phone", string type = "json")
        {
            if (string.IsNullOrEmpty(type))
            {
                type = "json";
            }
            else if (type != "json" && type != "xml")
            {
                return Content(HttpStatusCode.InternalServerError, GetErrorLinks(ErrorNumber.ServerError, type), type.Contains("xml")
                    ? (MediaTypeFormatter)Configuration.Formatters.XmlFormatter
                    : Configuration.Formatters.JsonFormatter);
            }

            id = id ?? 0;
            var student = _context.Students.FirstOrDefault(x => x.Id == id);

            if (student == null)
            {
                return Content(HttpStatusCode.NotFound, GetErrorLinks(ErrorNumber.NotFound, type), type.Contains("xml")
                    ? (MediaTypeFormatter)Configuration.Formatters.XmlFormatter
                    : Configuration.Formatters.JsonFormatter);
            }
            var studentDto = InitializeStudentColumns(student, columns);
            studentDto.SelfLinks = GetSelfLinks(student.Id, type);
            var result = new SingleStudentResponseDto()
            {
                Student = studentDto,
                //GlobalLinks = GetGlobalLinks(type)
            };
            return Content(HttpStatusCode.Created, result, type.Contains("xml")
                ? (MediaTypeFormatter)Configuration.Formatters.XmlFormatter
                : Configuration.Formatters.JsonFormatter);
        }

        [HttpGet]
        [Route("getall.{type}")]
        [Route("~/api/students/getall")]
        public IHttpActionResult Get(
            int limit=100,
            int offset = 0,
            int minId = 0,
            int maxId = int.MaxValue,
            bool isSortByName = false,
            string columns = "id, name, phone",
            string like = null,
            string globalLike = null,
            string type = "json")
        {
            if (string.IsNullOrEmpty(type))
            {
                type = "json";
            }
            else if (type != "json" && type != "xml")
            {
                return Content(HttpStatusCode.InternalServerError, GetErrorLinks(ErrorNumber.ServerError, type), type.Contains("xml")
                    ? (MediaTypeFormatter)Configuration.Formatters.XmlFormatter
                    : Configuration.Formatters.JsonFormatter);
            }

            try
            {
                //limit = limit ?? int.MaxValue;
                columns = columns ?? "id, name, phone";
                type = type ?? "json";


                var studentsQuery = _context.Students.AsNoTracking()
                    .Where(x => x.Id > 0)
                    .Where(prop => prop.Id >= minId && prop.Id <= maxId)
                    .Skip(offset)
                    .Take(limit);

                studentsQuery = isSortByName
                    ? studentsQuery.OrderBy(prop => prop.Name)
                    : studentsQuery.OrderBy(prop => prop.Id);

                if (like != null)
                {
                    studentsQuery = studentsQuery.Where(prop => prop.Name.ToLower().Contains(like.ToLower()));
                }

                if (globalLike != null)
                {
                    studentsQuery = studentsQuery.Where(prop =>
                        (prop.Id.ToString()+ prop.Name + prop.Phone).ToLower().Contains(globalLike.ToLower()));
                }

                var students = studentsQuery.ToList();

                var result = new List<StudentDto>();
                foreach (var item in students)
                {
                    var studentDto = InitializeStudentColumns(item, columns);

                    studentDto.SelfLinks = GetSelfLinks(item.Id, type);
                    result.Add(studentDto);
                }

                var response = new StudentResponseDto()
                {
                    GlobalLinks = GetGlobalLinks(type),
                    Students = result
                };

                return Content(HttpStatusCode.Created, response, type.Contains("xml")
                    ? (MediaTypeFormatter)Configuration.Formatters.XmlFormatter
                    : Configuration.Formatters.JsonFormatter);
            }
            catch
            {
                return Content(HttpStatusCode.InternalServerError, GetErrorLinks(ErrorNumber.ServerError,type), type.Contains("xml")
                    ? (MediaTypeFormatter)Configuration.Formatters.XmlFormatter
                    : Configuration.Formatters.JsonFormatter);
            }

        }

        [HttpPost]
        public object PostStudent([FromBody] Student student, string type = "json")
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, GetErrorLinks(ErrorNumber.NotValidParams,type), type.Contains("xml")
                    ? (MediaTypeFormatter)Configuration.Formatters.XmlFormatter
                    : Configuration.Formatters.JsonFormatter);
            }

            _context.Students.Add(student);
            _context.SaveChanges();

            return Content(HttpStatusCode.Created, "Created", type.Contains("xml") 
                ? (MediaTypeFormatter)Configuration.Formatters.XmlFormatter 
                : Configuration.Formatters.JsonFormatter);
        }

        [HttpPut]
        [Route("{id:int}.{type}")]
        public object UpdateStudent([FromBody] Student student,int id, string type = "json")
        {
            student.Id = id;

            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, GetErrorLinks(ErrorNumber.NotValidParams,type), type.Contains("xml")
                    ? (MediaTypeFormatter)Configuration.Formatters.XmlFormatter
                    : Configuration.Formatters.JsonFormatter);
            }
            try
            {
                _context.Entry(student).State = EntityState.Modified;
                _context.SaveChanges();
                return Content(HttpStatusCode.OK, "Updated", type.Contains("xml")
                    ? (MediaTypeFormatter)Configuration.Formatters.XmlFormatter
                    : Configuration.Formatters.JsonFormatter);
            }
            catch 
            {
                return Content(HttpStatusCode.InternalServerError, GetErrorLinks(ErrorNumber.ServerError, type), type.Contains("xml")
                    ? (MediaTypeFormatter)Configuration.Formatters.XmlFormatter
                    : Configuration.Formatters.JsonFormatter);
            }
        }

        [HttpDelete]
        [Route("{id:int}.{type}")]
        public IHttpActionResult DeleteStudent(int id, string type = "json")
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return Content(HttpStatusCode.BadRequest, GetErrorLinks(ErrorNumber.NotFound, type), type.Contains("xml")
                    ? (MediaTypeFormatter)Configuration.Formatters.XmlFormatter
                    : Configuration.Formatters.JsonFormatter);
            }

            _context.Students.Remove(student);
            _context.SaveChanges();

            return Content(HttpStatusCode.OK,"Deleted", type.Contains("xml")
                ? (MediaTypeFormatter)Configuration.Formatters.XmlFormatter
                : Configuration.Formatters.JsonFormatter);
        }

        private List<Hateoas> GetSelfLinks(int id,string type)
        {
            var links = new List<Hateoas>()
            {
                new Hateoas
                {
                    Href = $"{ControllerUrl}/{id}.{type}",
                    Rel = "Get",
                    Method = "GET",
                },
                new Hateoas
                {
                    Href = $"{ControllerUrl}/{id}.{type}",
                    Rel = "Update",
                    Method = "PUT",
                },
                new Hateoas
                {
                    Href = $"{ControllerUrl}/{id}.{type}",
                    Rel = "Delete",
                    Method = "DELETE",
                }
            };
            return links;
        }

        private List<Hateoas> GetErrorLinks(ErrorNumber errorNumber,string type)
        {
            var links = new List<Hateoas>()
            {
                new Hateoas
                {
                    Href = $"api/error.{type}/{(int)errorNumber}",
                    Rel = "Get error",
                    Method = "GET",
                },
            };
            return links;
        }

        private List<Hateoas> GetGlobalLinks(string type)
        {
            var links = new List<Hateoas>()
            {
                new Hateoas
                {
                    Href = $"api/student.{type}",
                    Rel = "Create",
                    Method = "POST",
                },
            };
            return links;
        }

        private StudentDto InitializeStudentColumns(Student student,string columns)
        {
            var studentDto = new StudentDto();
            if (columns == null) 
                return studentDto;

            if (columns.Contains("id"))
            {
                studentDto.Id = student.Id;
            }
            if (columns.Contains("name"))
            {
                studentDto.Name = student.Name;
            }
            if (columns.Contains("phone"))
            {
                studentDto.Phone = student.Phone;
            }
            return studentDto;
        }
    }
}
