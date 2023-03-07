using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace StudentRegistration.Pages.Students
{
    public class IndexModel : PageModel
    {
        public List <StudentInfo> listStudents = new List<StudentInfo> ();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\iqbal;Initial Catalog=StudentRegistration;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection (connectionString))
                {
                    connection.Open ();
                    String sql = "SELECT * FROM students";
                    using (SqlCommand command = new SqlCommand (sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader ())
                        {
                            while (reader.Read ())
                            {
                                StudentInfo studentInfo = new StudentInfo ();
                                studentInfo.id = "" + reader.GetInt32 (0);
                                studentInfo.FirstName = reader.GetString (1);
                                studentInfo.LastName = reader.GetString (2);
                                studentInfo.FullName = reader.GetString(3);
                                studentInfo.Password = reader.GetString (4);
                                studentInfo.Email = reader.GetString (5);
                                studentInfo.Phone = reader.GetString (6);
                                studentInfo.Address = reader.GetString(7);

                                listStudents.Add(studentInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
           
        }
    }

    public class StudentInfo
    {
        public String id;
        public String FirstName;
        public String LastName;
        public String FullName;
        public String Password;
        public String Email;
        public String Phone;
        public String Address;

    }
}
