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
    public class PersonController : ControllerBase
    {
        private readonly ContosoUniversityContext db;

        public PersonController(ContosoUniversityContext db)
        {
            this.db = db;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Person>> GetPersons()
        {
            return db.People.Where(x => x.IsDeleted == false).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPersonById(int id)
        {
            return db.People.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public ActionResult<Person> PostPerson(Person model)
        {
            db.People.Add(model);
            db.SaveChanges();

            return Created("/api/Person/" + model.Id, model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public IActionResult PutPerson(int id, Person model)
        {
            var c = db.People.Find(id);
            c.LastName = model.LastName;
            c.FirstName = model.FirstName;
            c.HireDate = model.HireDate;
            c.EnrollmentDate = model.EnrollmentDate;
            c.Discriminator = model.Discriminator;
            c.DateModified = DateTime.Now;
            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Person> DeletePersonById(int id)
        {
            var c = db.People.Find(id);
            c.IsDeleted = true;
            db.SaveChanges();

            return Ok(c);
        }
    }
}