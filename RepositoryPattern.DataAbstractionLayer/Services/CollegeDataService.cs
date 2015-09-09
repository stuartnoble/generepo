using System;
using System.Collections.Generic;
using RepositoryPattern.Core;
using RepositoryPattern.DataAbstractionLayer.Entities;

namespace RepositoryPattern.DataAbstractionLayer.Services
{
    public class CollegeDataService : IStudentDataService, ICourseDataService
    {
        private readonly IKeyedEntityRepository<Student, int> _studentRepository;
        private readonly IKeyedEntityRepository<Course, int> _courseRepository;

        public CollegeDataService(IKeyedEntityRepository<Student, int> studentRepository, IKeyedEntityRepository<Course, int> courseRepository)
        {
            if (studentRepository == null) throw new ArgumentNullException(nameof(studentRepository));
            if (courseRepository == null) throw new ArgumentNullException(nameof(courseRepository));

            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _studentRepository.GetAll();
        }

        public Student GetStudent(int id)
        {
            return _studentRepository.GetById(id);
        }

        public void AddStudent(Student student)
        {
            _studentRepository.Create(student);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
        }

        public void DeleteStudent(Student student)
        {
            _studentRepository.Delete(student);
        }

        public IEnumerable<Course> GetCourses()
        {
            throw new NotImplementedException();
        }

        public Course GetCourse(int id)
        {
            throw new NotImplementedException();
        }
    }
}