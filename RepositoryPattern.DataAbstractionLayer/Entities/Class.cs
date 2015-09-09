using System;
using System.Collections;
using System.Collections.Generic;
using NodaTime;
using RepositoryPattern.Core;

namespace RepositoryPattern.DataAbstractionLayer.Entities
{
    public class Class : AuditedEntity<Tuple<int, DateTime>>
    {
        public Course Course { get; set; }
        public LocalDateTime StartDateTime { get; set; }
        public LocalDateTime EndDateTime { get; set; }

        public LocalTime StartTime
        {
            get { return new LocalTime(StartDateTime.Hour, StartDateTime.Minute); }
            set { StartDateTime = value.LocalDateTime; }
        }

        public LocalTime EndTime
        {
            get { return new LocalTime(EndDateTime.Hour, EndDateTime.Minute); }
            set { EndDateTime = value.LocalDateTime; }
        }
        
        public virtual IEnumerable<Student> Students { get; set; }
    }
}
