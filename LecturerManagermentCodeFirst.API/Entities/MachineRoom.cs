﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// Phòng máy
    /// </summary>
    public class MachineRoom
    {
        public string ID { get; set; }
        [ForeignKey("Lecturer")]
        public string LecturerID { get; set; }
        public int QantityRoom { get; set; }
        public string SchoolYear { get; set; }
        public string? Description { get; set; }

        public Lecturer Lecturer { get; set; }
    }
}
