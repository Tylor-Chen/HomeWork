using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
//using HomeWork.Models;

namespace HomeWork.Controllers
{
    [Authorize]
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
            return db.Courses.Where(x => x.IsDeleted == false).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetTModelById(int id)
        {
            return db.Courses.Where(x => x.CourseId == id && x.IsDeleted == false).FirstOrDefault();
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public ActionResult<Course> PostTModel(Course model)
        {
            db.Courses.Add(model);
            db.SaveChanges();

            return Created("/api/Course/" + model.CourseId, model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public IActionResult PutTModel(int id, Course model)
        {
            var c = db.Courses.Find(id);
            c.Credits = model.Credits;
            c.Title = model.Title;
            c.DateModified = DateTime.Now;
            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Course> DeleteTModelById(int id)
        {
            var c = db.Courses.Find(id);
            c.IsDeleted = true;
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

        [HttpGet("Error")]
        public void Error()
        {
            throw new Exception("Test Error");
        }
    }
}