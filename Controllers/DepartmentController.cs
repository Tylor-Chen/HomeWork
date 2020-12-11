using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using HomeWork.Models;

namespace HomeWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ContosoUniversityContext db;

        public DepartmentController(ContosoUniversityContext db)
        {
            this.db = db;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Department>> GetDepartments()
        {
            return db.Departments.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartmentById(int id)
        {
            return db.Departments.Find(id);
        }

        [HttpPost("")]
        public ActionResult<Department> PostDepartment(Department model)
        {
            db.Database.ExecuteSqlRaw($"exec dbo.Department_Insert @Name = {model.Name}, @Budget = {model.Budget}, @StartDate = {model.StartDate}, @InstructorID = {model.InstructorId}");

            return Created("/api/Department/" + model.DepartmentId, model);
        }

        [HttpPut("{id}")]
        public IActionResult PutDepartment(int id, Department model)
        {
            var c = db.Departments.Find(id);
            c.Name = model.Name;
            c.Budget = model.Budget;
            c.StartDate = model.StartDate;
            c.InstructorId = model.InstructorId;
            c.RowVersion = model.RowVersion;
            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Department> DeleteDepartmentById(int id, Department model)
        {
            db.Database.ExecuteSqlRaw($"exec dbo.Department_Delete @DepartmentID = {id}, @RowVersion = {model.RowVersion}");

            return Ok();
        }

        [HttpGet("DepartmentCourseCount")]
        public ActionResult<IEnumerable<VwDepartmentCourseCount>> GetDepartmentCourseCount()
        {
            return db.VwDepartmentCourseCounts.FromSqlRaw("SELECT * FROM dbo.vwDepartmentCourseCount").ToList();
        }
    }
}