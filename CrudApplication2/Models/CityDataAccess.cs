using Microsoft.Data.SqlClient;
using System.Data;

namespace CrudApplication2.Models
{
    public class CityDataAccess
    {
        string connectionString = "Data Source=LAPTOP-1B2K66Q1;Initial Catalog=EmployeeMnagment;Integrated Security=True;Trust Server Certificate=True";

        public IEnumerable<CityModel> GetallCity()
        {
            List<CityModel> ListStateModel = new List<CityModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("City_Get", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    CityModel cityModel = new CityModel();

                    cityModel.CityId = Convert.ToInt32(rdr["CityId"]);
                    cityModel.CityName = rdr["CityName"].ToString();
                    cityModel.StateId = Convert.ToInt32(rdr["StateId"]);
                    cityModel.StateName = rdr["StateName"].ToString();
                    cityModel.IsActive = Convert.ToBoolean(rdr["IsActive"]);

                    ListStateModel.Add(cityModel);

                }

                con.Close();
            }

            return ListStateModel;
        }

        public void InsertCityModel(CityModel CityModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("City_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CityName", CityModel.CityName);
                cmd.Parameters.AddWithValue("@StateId", CityModel.StateId);
                cmd.Parameters.AddWithValue("@IsActive", CityModel.IsActive);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public CityModel GetCitybyId(int id)
        {
            CityModel CityModel = new CityModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("City_GetByCityId", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CityId", id);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    CityModel.CityId = Convert.ToInt32(rdr["CityId"]);
                    CityModel.CityName = Convert.ToString(rdr["CityName"]);
                    CityModel.StateId = Convert.ToInt32(rdr["StateId"]);
                    CityModel.IsActive = Convert.ToBoolean(rdr["IsActive"]);
                }

                con.Close();
            }

            return CityModel;
        }

        public void UpdateCityModel(CityModel CityModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("City_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CityId", CityModel.CityId);
                cmd.Parameters.AddWithValue("@CityName", CityModel.CityName);
                cmd.Parameters.AddWithValue("@StateId", CityModel.StateId);
                cmd.Parameters.AddWithValue("@IsActive", CityModel.IsActive);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }


        }

        public void DeleteCity(int id)
        {
            CityModel CityModel = new CityModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("City_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CityId", id);

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();

            }
        }

    }
}

