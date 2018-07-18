using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class ParkDAL : IParkDAL
    {
		private readonly string connectionString;

		public ParkDAL(string databaseConnectionString)
		{
			connectionString = databaseConnectionString;
		}

		public IList<Park> GetAllParks()
		{
			IList<Park> output = new List<Park>();

			try
			{
				// Create a new connection object
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					// Open the connection
					conn.Open();

					string sql = $"SELECT * FROM park order by parkCode";
					SqlCommand cmd = new SqlCommand(sql, conn);

					// Execute the command
					SqlDataReader reader = cmd.ExecuteReader();

					// Loop through each row
					while (reader.Read())
					{
						Park park = new Park();
						park.ParkCode = Convert.ToString(reader["parkCode"]);
						park.ParkName = Convert.ToString(reader["parkName"]);
						park.State = Convert.ToString(reader["state"]);
						park.Description = Convert.ToString(reader["parkDescription"]);

						output.Add(park);
					}
				}
			}
			catch (SqlException)
			{
				throw;
			}

			return output;
		}

		public Park GetPark(string parkCode)
		{
			Park output = new Park();

			try
			{
				// Create a new connection object
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					// Open the connection
					conn.Open();

					string sql = $"SELECT * FROM park WHERE parkCode = @code;";
					SqlCommand cmd = new SqlCommand(sql, conn);
					cmd.Parameters.AddWithValue("@code", parkCode);

					// Execute the command
					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						output.ParkCode = Convert.ToString(reader["parkCode"]);
						output.ParkName = Convert.ToString(reader["parkName"]);
						output.State = Convert.ToString(reader["state"]);
						output.Acreage = Convert.ToInt32(reader["acreage"]);
						output.Elevation = Convert.ToInt32(reader["elevationInFeet"]);
						output.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
						output.NumOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
						output.Climate = Convert.ToString(reader["climate"]);
						output.YearFounded = Convert.ToInt32(reader["yearFounded"]);
						output.AnnualVisitors = Convert.ToInt32(reader["annualVisitorCount"]);
						output.Quote = Convert.ToString(reader["inspirationalQuote"]);
						output.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
						output.Description = Convert.ToString(reader["parkDescription"]);
						output.EntryFee = Convert.ToDecimal(reader["entryFee"]);
						output.AnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
					}
				}
			}
			catch (SqlException ex)
			{
				throw;
			}

			return output;
		}
	}
}
