﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// loại môn
    /// </summary>
    public class SubjectType
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();
    }
}
