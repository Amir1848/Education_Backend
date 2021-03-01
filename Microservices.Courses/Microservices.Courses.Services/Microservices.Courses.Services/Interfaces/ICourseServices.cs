using Microservices.Courses.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Courses.Services.Interfaces
{
    public interface ICourseServices
    {
        public Task<bool> CreateCourse(CreateCourseDto model);
        public Task<bool> RemoveCourse(long id);

    }
}
