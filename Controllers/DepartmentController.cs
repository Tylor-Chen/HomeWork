using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public ActionResult<Department> PostDepartment(Department model)
        {
            SqlParameter[] arySqlParameter = new SqlParameter[]
            {
                new SqlParameter("@Name", model.Name),
                new SqlParameter("@Budget", model.Budget),
                new SqlParameter("@StartDate", model.StartDate),
                new SqlParameter("@InstructorId", model.InstructorId)
            };

            model.DepartmentId = db.Database.ExecuteSqlRaw($"exec dbo.Department_Insert @Name, @Budget, @StartDate, @InstructorId ", arySqlParameter);

            return Created("/api/Department/" + model.DepartmentId, model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public IActionResult PutDepartment(int id, Department model)
        {
            SqlParameter[] arySqlParameter = new SqlParameter[]
            {
                new SqlParameter("@DepartmentId", id),
                new SqlParameter("@Name", model.Name),
                new SqlParameter("@Budget", model.Budget),
                new SqlParameter("@StartDate", model.StartDate),
                new SqlParameter("@InstructorId", model.InstructorId)
            };

            db.Database.ExecuteSqlRaw($"exec dbo.Department_Update @DepartmentId, @Name, @Budget, @StartDate, @InstructorID ", arySqlParameter);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Department> DeleteDepartmentById(int id)
        {
            var c = db.Departments.FromSqlRaw($"exec dbo.Department_Delete @DepartmentID = {id}");

            return Ok(c);
        }

        [HttpGet("DepartmentCourseCount")]
        public ActionResult<IEnumerable<VwDepartmentCourseCount>> GetDepartmentCourseCount()
        {
            return db.VwDepartmentCourseCounts.FromSqlRaw("SELECT * FROM dbo.vwDepartmentCourseCount").ToList();
        }
    }
}