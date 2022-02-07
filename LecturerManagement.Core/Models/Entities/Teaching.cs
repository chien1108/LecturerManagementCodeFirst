﻿using LecturerManagement.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// giảng dạy
    /// </summary>
    public class Teaching : BaseEntity<int>
    {
        [ForeignKey("Lecturer")]
        public string LectureID { get; set; }

        [ForeignKey("Class")]
        public string ClassID { get; set; }

        [ForeignKey("Subject")]
        public string SubjectID { get; set; }

        public int NumberOfStudents { get; set; }
        public string SchoolYear { get; set; }
        public string Description { get; set; } = null;

        public Lecturer Lecturer { get; set; }
        public Class Class { get; set; }
        public Subject Subject { get; set; }
    }
}