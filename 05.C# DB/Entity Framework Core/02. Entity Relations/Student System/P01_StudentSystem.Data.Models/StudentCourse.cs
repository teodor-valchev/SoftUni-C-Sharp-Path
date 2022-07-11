using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        #region Relations
        public Student Student { get; set; }

        public Course Course { get; set; }
        #endregion
    }
}
