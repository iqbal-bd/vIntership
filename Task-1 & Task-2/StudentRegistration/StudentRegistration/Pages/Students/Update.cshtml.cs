using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace StudentRegistration.Pages.Students
{
    public class UpdateModel : PageModel
    {
        public StudentInfo studentInfo = new StudentInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
            String id= Request.Query["id"];
            try
            {
                String connectionString = "Data Source=.\\iqbal;Initial Catalog=StudentRegistration;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM students WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StudentInfo studentInfo = new StudentInfo();
                                studentInfo.id = "" + reader.GetInt32(0);
                                studentInfo.FirstName = reader.GetString(1);
                                studentInfo.LastName = reader.GetString(2);
                                studentInfo.FullName = reader.GetString(3);
                                studentInfo.Password = reader.GetString(4);
                                studentInfo.Email = reader.GetString(5);
                                studentInfo.Phone = reader.GetString(6);
                                studentInfo.Address = reader.GetString(7);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
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

            if (studentInfo.FirstName.Length == 0 || studentInfo.LastName.Length == 0 ||
                studentInfo.FullName.Length == 0 || studentInfo.Password.Length == 0 ||
                studentInfo.Email.Length == 0 || studentInfo.Phone.Length == 0 ||
                studentInfo.Address.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            //save into the database
            try
            {
                string connectionString = "Data Source=.\\IQBAL;Initial Catalog=StudentRegistration;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE students" +
                        "SET FirstName=@FirstName,LastName=@LastName,FullName=@FullName" +
                        "Password=@Password,Email=@Email,Phone=@Phone,Address=@Address WHERE id=@id;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
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

            Response.Redirect("/Students/Index");


        }
    }
}
