using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtlapDolgozat
{
	public class EtlapService
	{
		MySqlConnection connection;

		public EtlapService()
		{
			MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
			builder.Server = "localhost";
			builder.Port = 3306;
			builder.UserID = "root";
			builder.Password = "";
			builder.Database = "etlapdb";

			connection = new MySqlConnection(builder.ConnectionString);
		}

		public List<Etel> GetAll()
		{
			List<Etel> etlap = new List<Etel>();
			OpenConnection();
			string sql = "SELECT * FROM etlap";
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = sql;
			using (MySqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					Etel etel = new Etel();
					etel.Id = reader.GetInt32("id");
					etel.Nev = reader.GetString("nev");
					etel.Leiras = reader.GetString("leiras");
					etel.Ar = reader.GetInt32("ar");
					etel.Kategoria = reader.GetString("kategoria");
					etlap.Add(etel);
				}
			}
			CloseConnection();
			return etlap;
		}

		private void CloseConnection()
		{
			if (connection.State == System.Data.ConnectionState.Open)
			{
				connection.Close();
			}
		}

		private void OpenConnection()
		{
			if (connection.State != System.Data.ConnectionState.Open)
			{
				connection.Open();
			}
		}
	}
}
