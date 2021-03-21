using Microservices.Courses.Services.Dtos;
using Microservices.Courses.Services.Interfaces;
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
        private readonly ICourseServices _courseService;
        public CourseController(ICourseServices courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody]CreateCourseDto model)
        {
            if (ModelState.IsValid)
            {
                if(await _courseService.CreateCourse(model))
                {
                    return StatusCode(201);
                }
                else
                {
                    return StatusCode(478);
                }
            }
            return StatusCode(478);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCourse(long Id)
        {
            if(await _courseService.RemoveCourse(Id))
            {
                return StatusCode(204);
            }
            else
            {
                return StatusCode(478);
            }
        }

    }
}
