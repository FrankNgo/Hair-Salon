using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    private string _clientName;
    private int _id;
    private int _stylistId;

    public Client (string clientName, int Id = 0, int stylistId = 0)
    {
      _clientName = clientName;
      _id = Id;
      _stylistId = stylistId;
    }
    public string GetClientName()
    {
      return _clientName;
    }

    public void SetClientName(string newClientName)
    {
      _clientName = newClientName;
    }
    public int GetId()
    {
      return _id;
    }
    public int GetStylistId()
    {
      return _stylistId;
    }
    public void SetStylistId(int id)
    {
      _stylistId = id;
    }

    public void Add()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `clients` (`clientName`, `stylist_id`) VALUES (@clientName, @stylistId);";

      MySqlParameter clientName = new MySqlParameter();
      clientName.ParameterName = "@clientName";
      clientName.Value = this._clientName;

      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@stylistId";
      stylistId.Value = this._stylistId;

      cmd.Parameters.Add(clientName);
      cmd.Parameters.Add(stylistId);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
