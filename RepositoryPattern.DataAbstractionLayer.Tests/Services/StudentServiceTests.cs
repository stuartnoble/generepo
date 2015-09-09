using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using NSubstitute;
using NUnit.Framework;
using RepositoryPattern.Core;
using RepositoryPattern.DataAbstractionLayer.Entities;
using RepositoryPattern.DataAbstractionLayer.EntityFramework.Repositories;
using RepositoryPattern.DataAbstractionLayer.Services;

namespace RepositoryPattern.DataAbstractionLayer.Tests.Services
{
    [TestFixture]
    public class StudentServiceTests
    {
        #region Test Data
        private static List<Student> _studentTestData = StudentTestDataFactory.GetTestData().ToList();
        private const int ValidStudentId = 1;
        private const int InvalidStudentId = -1;
        #endregion

        [Test]
        public void Ctor_ValidArguments_ReturnsInstance()
        {
            Assert.DoesNotThrow(() => CreateStudentService());
        }

        [Test]
        public void GetAll_ReturnsAllStudents()
        {
            CollegeDataService collegeDataService = CreateStudentService();

            IEnumerable<Student> students = collegeDataService.GetStudents();

            Assert.AreEqual(_studentTestData.Count(), students.Count());
        }

        [Test]
        public void GetById_ValidStudentId_ReturnsStudent()
        {
            CollegeDataService collegeDataService = CreateStudentService();

            Student student = collegeDataService.GetStudent(ValidStudentId);

            Assert.IsNotNull(student);
            Assert.AreEqual(ValidStudentId, student.Id);
        }

        public void GetById_InvalidStudentId_ReturnsNull()
        {
            CollegeDataService collegeDataService = CreateStudentService();

            Student student = collegeDataService.GetStudent(InvalidStudentId);

            Assert.IsNull(student);
        }

        [Test]
        public void Create_ValidStudent_AddsStudentToCollection()
        {
            CollegeDataService collegeDataService = CreateStudentService();
            var newStudent = new Student()
            {
                Id = 100,
                FirstName = "Test",
                LastName = "Student",
            };
            
            collegeDataService.AddStudent(newStudent);

            CollectionAssert.Contains(_studentTestData, newStudent);
        }

        private CollegeDataService CreateStudentService()
        {
            IKeyedEntityRepository<Student, int> studentRepository = CreateMockStudentRepository();
            IKeyedEntityRepository<Course, int> courseRepository = CreateMockCourseRepository();
            
            return new CollegeDataService(studentRepository, courseRepository);
        }

        private static IKeyedEntityRepository<Student, int> CreateMockStudentRepository()
        {
            var studentRepository = Substitute.For<IKeyedEntityRepository<Student, int>>();

            studentRepository
                .GetAll()
                .Returns(_studentTestData);

            studentRepository
                .GetById(Arg.Any<int>())
                .Returns(_studentTestData.FirstOrDefault());

            studentRepository
                .When(sr => sr.Create(Arg.Any<Student>()))
                .Do(x => _studentTestData.Add((Student)x.Args()[0]));
            
            return studentRepository;
        }

        private static IKeyedEntityRepository<Course, int> CreateMockCourseRepository()
        {
            var courseRepository = Substitute.For<IKeyedEntityRepository<Course, int>>();

            return courseRepository;
        }
    }
}
