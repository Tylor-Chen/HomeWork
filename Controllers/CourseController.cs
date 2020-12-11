using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWork.Models;
using Microsoft.AspNetCore.Mvc;
//using HomeWork.Models;

namespace HomeWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ContosoUniversityContext db;

        public CourseController(ContosoUniversityContext db)
        {
            this.db = db;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Course>> GetTModels()
        {
            return db.Courses.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetTModelById(int id)
        {
            return db.Courses.Find(id);
        }

        [HttpPost("")]
        public ActionResult<Course> PostTModel(Course model)
        {
            db.Courses.Add(model);
            db.SaveChanges();

            return Created("/api/Course/" + model.CourseId, model);
        }

        [HttpPut("{id}")]
        public IActionResult PutTModel(int id, Course model)
        {
            var c = db.Courses.Find(id);
            c.Credits = model.Credits;
            c.Title = model.Title;
            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Course> DeleteTModelById(int id)
        {
            var c = db.Courses.Find(id);
            db.Courses.Remove(c);
            db.SaveChanges();

            return Ok(c);
        }

        [HttpGet("CourseStudents")]
        public ActionResult<IEnumerable<VwCourseStudent>> GetCourseStudents()
        {
            return db.VwCourseStudents.ToList();
        }

        [HttpGet("CourseStudentCount")]
        public ActionResult<IEnumerable<VwCourseStudentCount>> GetCourseStudentCount()
        {
            return db.VwCourseStudentCounts.ToList();
        }
    }
}