using System.Collections.Generic;
using RepositoryPattern.DataAbstractionLayer.Entities;

namespace RepositoryPattern.DataAbstractionLayer.Services
{
    public interface ICourseDataService
    {
        IEnumerable<Course> GetCourses();
        Course GetCourse(int id);
    }
}
