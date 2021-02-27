using Microservices.Courses.Services.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Courses.Controllers
{
    [ApiController]
    public class CourseController : Controller
    {
        [HttpPost]
        public IActionResult CreateCourse(CreateCourseDto model)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(ModelState);
            }
            
        
        
        
        
        }
    }
}
