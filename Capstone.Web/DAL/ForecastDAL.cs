using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class ForecastDAL : IForecastDAL
    {
		private readonly string connectionString;

		public ForecastDAL(string databaseConnectionString)
		{
			connectionString = databaseConnectionString;
		}

		public IList<Forecast> GetForecastForPark(string parkCode)
		{
			IList<Forecast> forecasts = new List<Forecast>();

			try
			{
				// Create a new connection object
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					// Open the connection
					conn.Open();

					string sql = $"SELECT * FROM weather WHERE parkCode = @code;";
					SqlCommand cmd = new SqlCommand(sql, conn);
					cmd.Parameters.AddWithValue("@code", parkCode);

					// Execute the command
					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						Forecast forecast = new Forecast();
						forecast.ParkCode = Convert.ToString(reader["parkCode"]);
						forecast.DayOfForecast = Convert.ToInt32(reader["fiveDayForecastValue"]);
						forecast.LowTemp = Convert.ToInt32(reader["low"]);
						forecast.HighTemp = Convert.ToInt32(reader["high"]);
						forecast.Description = Convert.ToString(reader["forecast"]);

						forecasts.Add(forecast);
					}
				}
			}
			catch (SqlException ex)
			{
				throw;
			}

			return forecasts;
		}
	}
}
