using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//using HomeWork.Models;

namespace HomeWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly ContosoUniversityContext db;

        public EnrollmentController(ContosoUniversityContext db)
        {
            this.db = db;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Enrollment>> GetEnrollments()
        {
            return db.Enrollments.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Enrollment> GetEnrollmentById(int id)
        {
            return db.Enrollments.Find(id);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public ActionResult<Enrollment> PostEnrollment(Enrollment model)
        {
            db.Enrollments.Add(model);
            db.SaveChanges();

            return Created("/api/Enrollment/" + model.EnrollmentId, model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public IActionResult PutEnrollment(int id, Enrollment model)
        {
            var c = db.Enrollments.Find(id);
            c.CourseId = model.CourseId;
            c.StudentId = model.StudentId;
            c.Grade = model.Grade;
            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Enrollment> DeleteEnrollmentById(int id)
        {
            var c = db.Enrollments.Find(id);
            db.Enrollments.Remove(c);
            db.SaveChanges();

            return Ok(c);
        }
    }
}