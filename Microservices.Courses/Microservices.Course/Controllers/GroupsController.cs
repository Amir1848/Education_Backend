using Microservices.Courses.DataLayer.Models;
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
    public class GroupsController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateGroup(CreateGroupDto model)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(ModelState);
            }
            
        } 

    }
}
