﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// giảng dạy
    /// </summary>
    public class Teaching
    {
        [ForeignKey("Lecturer")]
        public string LectureID { get; set; }
        [ForeignKey("Class")]
        public string ClassID { get; set; }
        [ForeignKey("Subject")]
        public string SubjectID { get; set; }
        public int NumberOfStudents { get; set; }
        public string SchoolYear { get; set; }
        public string? Description { get; set; }
        public Lecturer Lecturer { get; set; }
        public Class Class { get; set; }
        public Subject Subject { get; set; }
    }
}
