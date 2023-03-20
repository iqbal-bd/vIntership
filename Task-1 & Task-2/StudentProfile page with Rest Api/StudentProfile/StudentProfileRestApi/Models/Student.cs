﻿namespace StudentProfileRestApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public int Phone { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
