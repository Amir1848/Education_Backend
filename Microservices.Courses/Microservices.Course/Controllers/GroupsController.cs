using Microservices.Courses.DataLayer.Models;
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
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;
        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateGroup(CreateGroupDto model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(478);
            }
            if(await _groupService.CreateGroup(model))
            {
                return StatusCode(201);
            }
            return StatusCode(478);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> RemoveGroup(long id)
        {
            if (await _groupService.RemoveGroup(id))
            {
                return StatusCode(204);
            }
            return StatusCode(478);
        }
        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            return new JsonResult(await _groupService.GetGroups());
        }

    }
}
