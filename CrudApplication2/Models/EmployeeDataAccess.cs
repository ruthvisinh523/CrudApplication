using Humanizer;
using Microsoft.Data.SqlClient;
using NuGet.Protocol.Plugins;
using System.Data;

namespace CrudApplication2.Models
{
    public class EmployeeDataAccess
    {

        string connectionString = "Data Source=LAPTOP-1B2K66Q1;Initial Catalog=EmployeeMnagment;Integrated Security=True;Trust Server Certificate=True";

        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Emp_Get", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    EmployeeModel employeeModel = new EmployeeModel();

                    employeeModel.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    employeeModel.FName = reader["FName"].ToString();
                    employeeModel.LName = reader["LName"].ToString();
                    employeeModel.Gender = reader["Gender"].ToString();
                    employeeModel.Age = Convert.ToInt32(reader["Age"]);
                    employeeModel.Email = reader["Email"].ToString();
                    employeeModel.ContectNo = reader["ContectNo"].ToString();
                    employeeModel.DOB = Convert.ToDateTime(reader["DOB"]);
                    employeeModel.CityName = reader["CityName"].ToString();
                    employeeModel.StateName = reader["StateName"].ToString();
                    employeeModel.IsActive = Convert.ToBoolean(reader["IsActive"]);

                    employees.Add(employeeModel);


                }
                con.Close();
                
                
            }
            return employees;

        }

        public void InsertEmployeeModel(EmployeeModel employeeModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Emp_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@FName", employeeModel.FName);
                cmd.Parameters.AddWithValue("@LName", employeeModel.LName);
                cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                cmd.Parameters.AddWithValue("@Age", employeeModel.Age);
                cmd.Parameters.AddWithValue("@Email", employeeModel.Email);
                cmd.Parameters.AddWithValue("@ContectNo", employeeModel.ContectNo);
                cmd.Parameters.AddWithValue("@DOB", employeeModel.DOB);
                cmd.Parameters.AddWithValue("@CityId", employeeModel.CityId);
                cmd.Parameters.AddWithValue("@StateId", employeeModel.StateId);
                cmd.Parameters.AddWithValue("@IsActive", employeeModel.IsActive);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public EmployeeModel GetEmployeebyId(int id)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Employee_GetByEmployeeId", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    

                    employeeModel.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    employeeModel.FName = reader["FName"].ToString();
                    employeeModel.LName = reader["LName"].ToString();
                    employeeModel.Gender = reader["Gender"].ToString();
                    employeeModel.Age = Convert.ToInt32(reader["Age"]);
                    employeeModel.Email = reader["Email"].ToString();
                    employeeModel.ContectNo = reader["ContectNo"].ToString();
                    employeeModel.DOB = Convert.ToDateTime(reader["DOB"]); ;
                    employeeModel.CityId = Convert.ToInt32(reader["CityId"]);
                    employeeModel.StateId = Convert.ToInt32(reader["StateId"]);
                    employeeModel.IsActive = Convert.ToBoolean(reader["IsActive"]);
                }

                con.Close();
            }

            return employeeModel;
        }

        public void UpdateEmployeeModel(EmployeeModel employeeModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("EMP_UpDate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", employeeModel.EmployeeId);
                cmd.Parameters.AddWithValue("@FName", employeeModel.FName);
                cmd.Parameters.AddWithValue("@LName", employeeModel.LName);
                cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                cmd.Parameters.AddWithValue("@Age", employeeModel.Age);
                cmd.Parameters.AddWithValue("@Email", employeeModel.Email);
                cmd.Parameters.AddWithValue("@ContectNo", employeeModel.ContectNo);
                cmd.Parameters.AddWithValue("@DOB", employeeModel.DOB);
                cmd.Parameters.AddWithValue("@CityId", employeeModel.CityId);
                cmd.Parameters.AddWithValue("@StateId", employeeModel.StateId);
                cmd.Parameters.AddWithValue("@IsActive", employeeModel.IsActive);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public void DeleteEmployee(int id)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Employee_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", id);

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();

            }
        }
    }
}
