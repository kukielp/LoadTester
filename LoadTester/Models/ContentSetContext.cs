using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace LoadTester.Models
{
  public class ContentSetContext
  {
    public string ConnectionString { get; set; }

    public ContentSetContext(string connectionString)
    {
      this.ConnectionString = connectionString;
    }

    private MySqlConnection GetConnection()
    {
      return new MySqlConnection(ConnectionString);
    }

    public List<ContentSet> GetAllContentSets()
    {
      List<ContentSet> list = new List<ContentSet>();

      using (MySqlConnection conn = GetConnection())
      {
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("SELECT contentSetId, categoryId, name, active FROM contentSet", conn);
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            list.Add(new ContentSet()
            {
              contentSetId = reader.GetInt32("contentSetId"),
              categoryId = reader.GetInt32("categoryId"),
              name = reader.GetString("name"),
			  active = reader.GetBoolean("active")
			

            });
          }
        }
      }

      return list;
    }
  }
}