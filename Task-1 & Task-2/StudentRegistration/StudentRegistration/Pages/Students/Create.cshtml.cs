using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace StudentRegistration.Pages.Students
{
    public class CreateModel : PageModel
    {
        public StudentInfo studentInfo = new StudentInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            studentInfo.FirstName = Request.Form["FirstName"];
            studentInfo.LastName = Request.Form["LastName"];
            studentInfo.FullName = Request.Form["FullName"];
            studentInfo.Password = Request.Form["Password"];
            studentInfo.Email = Request.Form["Email"];
            studentInfo.Phone = Request.Form["Phone"];
            studentInfo.Address = Request.Form["Address"];

            if(studentInfo.FirstName.Length == 0 || studentInfo.LastName.Length == 0 ||
                studentInfo.FullName.Length == 0 || studentInfo.Password.Length == 0 ||
                studentInfo.Email.Length == 0 || studentInfo.Phone.Length == 0 ||
                studentInfo.Address.Length == 0 ) 
            {
                errorMessage = "All the fields are required";
                return;
            }

            //save into the database
            try
            {
                string connectionString = "Data Source=.\\iqbal;Initial Catalog=StudentRegistration;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO students" +
                        "(FirstName,LastName,FullName,Password,Email,Phone,Address) VALUES" +
                        "(@FirstName,@LastName,@FullName,@Password,@Email,@Phone,@Address);";

                    using (SqlCommand command = new SqlCommand (sql, connection)) 
                    {
                        command.Parameters.AddWithValue("@FirstName", studentInfo.FirstName);
                        command.Parameters.AddWithValue("@LastName", studentInfo.LastName);
                        command.Parameters.AddWithValue("@FullName", studentInfo.FullName);
                        command.Parameters.AddWithValue("@Password", studentInfo.Password);
                        command.Parameters.AddWithValue("@Email", studentInfo.Email);
                        command.Parameters.AddWithValue("@Phone", studentInfo.Phone);
                        command.Parameters.AddWithValue("@Address", studentInfo.Address);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            studentInfo.FirstName = "";
            studentInfo.LastName = "";
            studentInfo.FullName = "";
            studentInfo.Password = "";
            studentInfo.Email = "";
            studentInfo.Phone = "";
            studentInfo.Address = "";
            successMessage = "New Student added";


        }
    }
}
