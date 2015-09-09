using System;
using RepositoryPattern.Core;

namespace RepositoryPattern.DataAbstractionLayer.Entities
{
    public class Course : KeyedEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
