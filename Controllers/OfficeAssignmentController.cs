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
    public class OfficeAssignmentController : ControllerBase
    {
        private readonly ContosoUniversityContext db;

        public OfficeAssignmentController(ContosoUniversityContext db)
        {
            this.db = db;
        }
    }
}