using Microservices.Courses.DataLayer.Context;
using Microservices.Courses.DataLayer.Models;
using Microservices.Courses.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Courses.Services
{
    public class CourseService
    {
        private readonly CourseDbContext _db;

        public CourseService(CourseDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CreateCourse(CreateCourseDto model)
        {
            try
            {
                Course course = new Course()
                {
                    CreateDate = DateTime.Now,
                    Description = model.Description,
                    EndDate = model.EndDate,
                    Group = _db.Groups.Find(model.GroupId),
                    GroupId = model.GroupId,
                    Name = model.Name,
                    StartDate = model.StartDate
                };

                await _db.Courses.AddAsync(course);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }
    }
}
