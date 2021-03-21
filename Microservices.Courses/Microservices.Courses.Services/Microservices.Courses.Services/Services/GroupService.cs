using Dapper;
using Microservices.Courses.DataLayer.Context;
using Microservices.Courses.DataLayer.Models;
using Microservices.Courses.Services.Dtos;
using Microservices.Courses.Services.Interfaces;
using Microsoft.Data.SqlClient;
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
        private readonly SqlConnection _db;
        public GroupService(SqlConnection db)
        {
            _db = db;
            _db.Open();
        }


        public async Task<bool> CreateGroup(CreateGroupDto model)
        {
            try
            {
                string GroupId = model.GroupId == 0 ? "NULL" : $"{model.GroupId}";
                await _db.QueryAsync($"insert into Groups values (N'{model.Name}',N'{model.Description}',1,{GroupId})");
            }
            catch (Exception exp)
            {
                return false;
            }
            return true;
        }

        public async Task<List<GroupDto>> GetGroups()
        {
            return _db.QueryAsync<GroupDto>("Exec SP_GetGroups").Result.ToList();
        }

        public async Task<bool> RemoveGroup(long id)
        {
            try
            {
                await _db.QueryAsync($"Exec SP_RemoveGroup {id}");
            }   
            catch (Exception exp)
            {
                return false;
            }
            return true;
        }
    }
}
