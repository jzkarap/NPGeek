using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class SurveyDAL : ISurveyDAL
    {
		private readonly string connectionString;

		public SurveyDAL(string databaseConnectionString)
		{
			connectionString = databaseConnectionString;
		}

		// Need an Insert to save user survey
		public bool SubmitSurvey(Survey survey)
		{
			try
			{
				// Create a new connection object
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					// Open the connection
					conn.Open();

					string sql = $@"INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @email, @state, @activityLevel);";
					SqlCommand cmd = new SqlCommand(sql, conn);
					cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
					cmd.Parameters.AddWithValue("@email", survey.Email);
					cmd.Parameters.AddWithValue("@state", survey.State);
					cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

					// Execute the command
					cmd.ExecuteNonQuery();
				}
			}
			catch (SqlException ex)
			{
				return false;
			}

			return true;

		}

		// Pull all survey responses
		public IList<SurveyResult> GetResults()
		{
			IList<SurveyResult> surveyResults = new List<SurveyResult>();

			try
			{
				// Create a new connection object
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					// Open the connection
					conn.Open();

					string sql = $@"SELECT park.parkCode, park.parkName, COUNT(survey_result.parkCode) AS Tally
						FROM survey_result
						INNER JOIN park ON survey_result.parkCode = park.parkCode
						GROUP BY park.parkCode, park.parkName
						ORDER BY COUNT(survey_result.parkCode) DESC, park.parkName ASC;";
					SqlCommand cmd = new SqlCommand(sql, conn);

					// Execute the command
					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						SurveyResult result = new SurveyResult();
						result.ParkCode = Convert.ToString(reader["parkCode"]);
						result.ParkName = Convert.ToString(reader["parkName"]);
						result.SurveyTally = Convert.ToInt32(reader["Tally"]);

						surveyResults.Add(result);
					}
				}
			}
			catch (SqlException ex)
			{
				throw;
			}

			return surveyResults;
		}

	}
}
