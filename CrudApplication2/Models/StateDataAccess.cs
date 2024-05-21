using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CrudApplication2.Models
{
    public class StateDataAccess
    {

        string connectionString = "Data Source=LAPTOP-1B2K66Q1;Initial Catalog=EmployeeMnagment;Integrated Security=True;Trust Server Certificate=True";

        public IEnumerable<StateModel> GetAllState()
        {
            List<StateModel> lastSateModels = new List<StateModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("State_Get", con);
                cmd.CommandType = CommandType.StoredProcedure;


                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StateModel stateModel = new StateModel();

                    stateModel.StateId = Convert.ToInt32(reader["StateId"]);
                    stateModel.StateName = reader["StateName"].ToString();
                    stateModel.IsActive = Convert.ToBoolean(reader["IsActive"]);
                       
                    lastSateModels.Add(stateModel);


                } 
                con.Close();

            }
            return lastSateModels;
        }

        public void InsertStateModel(StateModel stateModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("State_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StateName", stateModel.StateName);
                cmd.Parameters.AddWithValue("@IsActive", stateModel.IsActive);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public StateModel GetStateById(int id)
        {
            StateModel stateModel = new StateModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("State_GetByStateId", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StateId", id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    stateModel.StateId = Convert.ToInt32(reader["StateId"]);
                    stateModel.StateName = Convert.ToString(reader["StateName"]);
                    stateModel.IsActive = Convert.ToBoolean(reader["IsActive"]);


                }
                con.Close();

            }
            return stateModel;
        }

        public void UpdateStateModel(StateModel stateModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("State_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StateId", stateModel.StateId);
                cmd.Parameters.AddWithValue("@StateName", stateModel.StateName);
                cmd.Parameters.AddWithValue("@IsActive", stateModel.IsActive);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public void DeleteStateById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Soft_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StateId", id);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        




    }




}
