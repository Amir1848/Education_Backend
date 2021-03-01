using Microservices.Courses.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Courses.Services.Interfaces
{
    public interface IGroupService
    {
        public Task<bool> CreateGroup(CreateGroupDto model);
        public Task<List<GroupDto>> GetGroups();
        public Task<bool> RemoveGroup(long id);
    }
}
