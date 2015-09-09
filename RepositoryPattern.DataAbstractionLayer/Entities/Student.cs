using System;
using System.Collections.Generic;
using RepositoryPattern.Core;

namespace RepositoryPattern.DataAbstractionLayer.Entities
{
    public class Student : AuditedEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual IEnumerable<Class> Classes { get; set; }

        public string FullName =>
            $"{FirstName}{(!String.IsNullOrEmpty(FirstName) & !String.IsNullOrEmpty(LastName) ? " " : "")}{LastName}";
    }
}