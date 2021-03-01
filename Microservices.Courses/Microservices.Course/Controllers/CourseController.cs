using Microservices.Courses.Services.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Courses.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDto model)
        {
            if (ModelState.IsValid)
            {
                return new JsonResult(model);
            }
            return new JsonResult(model);
        }

    }
}
