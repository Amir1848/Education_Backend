using Microservices.Courses.DataLayer.Context;
using Microservices.Courses.DataLayer.Models;
using Microservices.Courses.Services.Dtos;
using Microservices.Courses.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Courses.Services.Services
{
    public class GroupService : IGroupService
    {
        private readonly CourseDbContext _db;
        public GroupService(CourseDbContext db)
        {
            _db = db;
        }


        public async Task<bool> CreateGroup(CreateGroupDto model)
        {
            try
            {
                Group group = new Group
                {
                    Name = model.Name,
                    Description = model.Description
                };

                await _db.Groups.AddAsync(group);
                await _db.SaveChangesAsync();
            }catch(Exception exp)
            {
                return false;
            }
            return true;
        }

        public async Task<List<GroupDto>> GetGroups()
        {
            return await _db.Groups.Select(p => new GroupDto()
            {
                Description = p.Description,
                Id = p.Id,
                Name = p.Name
            }).ToListAsync();
        }

        public async Task<bool> RemoveGroup(long id)
        {
            var item = await _db.Groups.FindAsync(id);
            if(item == null)
            {
                return false;
            }
            try
            {
                item.Active = false;
                await _db.SaveChangesAsync();
            }
            catch(Exception exp)
            {
                return false;
            }
            return true;
        }
    }
}
