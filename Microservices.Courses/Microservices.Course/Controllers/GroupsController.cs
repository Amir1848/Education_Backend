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
                return new JsonResult(ModelState);
            }
            return new JsonResult(await _groupService.CreateGroup(model));
        }
        [HttpPost]
        public async Task<IActionResult> RemoveGroup([FromRoute]long id)
        {
            if(id != 0)
            {
                return new JsonResult(await _groupService.RemoveGroup(id));
            }
            return new JsonResult("Please write the value of id");
        }
        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            return new JsonResult(await _groupService.GetGroups());
        }

    }
}
