using Microservices.Courses.DataLayer.Context;
using Microservices.Courses.DataLayer.Models;
using Microservices.Courses.Services.Dtos;
using Microservices.Courses.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Courses.Services.Services
{
    public class CourseService : ICourseServices
    {
        private readonly SqlConnection _db;
        public CourseService(SqlConnection db) {
            _db = db;
            _db.Open();
        }

        public async Task<bool> CreateCourse(CreateCourseDto model)
        {
            //try
            //{
            //    Course course = new Course
            //    {
            //        Active = true,
            //        CreateDate = DateTime.Now,
            //        Description = model.Description,
            //        EndDate = model.EndDate,
            //        Group = _db.Groups.Find(model.GroupId),
            //        GroupId = model.GroupId,
            //        Name = model.Name,
            //        StartDate = model.StartDate
            //    };
            //    await _db.Courses.AddAsync(course);
            //    await _db.SaveChangesAsync();

            //}
            //catch (Exception exp)
            //{
            //    return false;
            //}

            //return true;
            try
            {
                await _db.QueryAsync($"use Education_CourseMicroService Insert into Courses VALUES (N'{model.Name}', N'{model.Description}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}','{model.StartDate.ToString("yyyy-MM-dd HH:mm:ss.fff")}','{model.EndDate.ToString("yyyy-MM-dd HH:mm:ss.fff")}',1,{model.GroupId});");

            }catch(Exception exp)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> RemoveCourse(long id)
        {
            //try
            //{
            //    var course = await _db.Courses.FindAsync(id);
            //    if(course == null)
            //    {
            //        return false;
            //    }

            //    course.Active = false;
            //    await _db.SaveChangesAsync();
            //}
            //catch (Exception exp)
            //{
            //    return false;
            //}
            //return true;
            try
            {
                await _db.QueryAsync($"Exec SP_RemoveCourse {id}");
            }
            catch (Exception exp)
            {
                return false;
            }
            return true;
        }

    }
}
