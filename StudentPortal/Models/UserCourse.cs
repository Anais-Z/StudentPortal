﻿using Microsoft.EntityFrameworkCore;

namespace StudentPortal.Models
{
    public class UserCourse
    {
        public int UserId { get; set; }

        public int CourseId { get; set; }

        public int Grade { get; set; }

        public Course Course { get; set; }

        public User User { get; set; }


    }
}
