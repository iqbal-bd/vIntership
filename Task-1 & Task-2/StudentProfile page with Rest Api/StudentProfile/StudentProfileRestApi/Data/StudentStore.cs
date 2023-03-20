using StudentProfileRestApi.Models.StudentDetails;

namespace StudentProfileRestApi.Data
{
    public static class StudentStore
    {
        public static List<StudentDetails> studentList = new List<StudentDetails>
        {
            new StudentDetails { Id = 1,Name = "Kamran",Role = 101,Phone=01722233445},
            new StudentDetails { Id = 2,Name = "Ashraf",Role = 102,Phone=01344455666}
        };
    }
}
