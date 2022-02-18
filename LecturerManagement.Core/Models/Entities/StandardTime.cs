﻿using LecturerManagement.Core.Models.Base;
using System.Collections.Generic;

namespace LecturerManagement.Core.Models.Entities
{
    public class StandardTime : BaseEntity<string>
    {
        //[Key]
        //public string ID { get; set; }

        public string Name { get; set; }
        public int StandardHours { get; set; }
        public string Description { get; set; } = null;

        public ICollection<Lecturer> Lecturers { get; set; }
    }
}