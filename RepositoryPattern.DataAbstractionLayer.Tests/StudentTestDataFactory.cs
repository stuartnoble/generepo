using System.Collections.Generic;
using RepositoryPattern.DataAbstractionLayer.Entities;

namespace RepositoryPattern.DataAbstractionLayer.Tests
{
    internal static class StudentTestDataFactory
    {
        public static IEnumerable<Student> GetTestData()
        {
            yield return CreateStudent(1,
                "Alan",
                "Davies"
                );
            
            yield return CreateStudent(2,
                "Stephen",
                "Fry"
                );
        }

        public static Student CreateStudent(int id,
            string firstName,
            string lastName)
        {
            return new Student
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
            };
        }
    }
}