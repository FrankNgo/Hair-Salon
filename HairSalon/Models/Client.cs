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
      cmd.CommandText = @"INSERT INTO `clients` (`clientName`, `stylistId`) VALUES (@clientName, @stylistId);";

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

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        int StylistId = rdr.GetInt32(2);
        Client newClient = new Client(clientName, clientId, StylistId);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.GetId() == newClient.GetId());
        bool clientNameEquality = (this.GetClientName() == newClient.GetClientName());
        bool StylistIdEquality = (this.GetStylistId() == newClient.GetStylistId());
        return (idEquality && clientNameEquality && StylistIdEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `clients` (`description`, `stylistId`) VALUES (@ClientName, @StylistId);";

      MySqlParameter clientName = new MySqlParameter();
      clientName.ParameterName = "@ClientName";
      clientName.Value = this._clientName;

      MySqlParameter StylistId = new MySqlParameter();
      StylistId.ParameterName = "@StylistId";
      StylistId.Value = this._stylistId;

      cmd.Parameters.Add(clientName);
      cmd.Parameters.Add(StylistId);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Client Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `clients` WHERE id = @thisId;";

      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int clientId = 0;
      string clientName = "";
      int stylistid = 0;

      while (rdr.Read())
      {
        clientId = rdr.GetInt32(0);
        clientName = rdr.GetString(1);
        stylistid = rdr.GetInt32(2);
      }

      Client foundClient = new Client(clientName, clientId, stylistid);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return foundClient;
    }
  }
}
