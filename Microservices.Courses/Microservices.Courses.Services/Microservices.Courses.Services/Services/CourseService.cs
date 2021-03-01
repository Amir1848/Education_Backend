using Microservices.Courses.DataLayer.Context;
using Microservices.Courses.DataLayer.Models;
using Microservices.Courses.Services.Dtos;
using Microservices.Courses.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Courses.Services.Services
{
    public class CourseService : ICourseServices
    {
        private readonly CourseDbContext _db;
        public CourseService(CourseDbContext db) {
            _db = db;
        }

        public async Task<bool> CreateCourse(CreateCourseDto model)
        {
            try
            {
                Course course = new Course
                {
                    Active = true,
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

            }
            catch (Exception exp)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> RemoveCourse(long id)
        {
            try
            {
                var course = await _db.Courses.FindAsync(id);
                if(course == null)
                {
                    return false;
                }

                course.Active = false;
                await _db.SaveChangesAsync();
            }
            catch (Exception exp)
            {
                return false;
            }
            return true;
        }

    }
}
