using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    private string _clientFirstName;
    private string _clientLastName;
    private int _clientId;
    private int _stylistId;

    public Client(string clientFirstName, string clientLastName, int clientId = 0, int stylistId = 0)
    {
      _clientFirstName = clientFirstName;
      _clientLastName = clientLastName;
      _clientId = clientId;
      _stylistId = stylistId;
    }

    public string GetClientFirstName(){return _clientFirstName;}

    public string GetClientLastName(){return _clientLastName;}

    public int GetClientId(){return _clientId;}

    public int GetStylistId(){return _stylistId;}

    public void SetStylistId(int id)
    {
        _stylistId = id;
    }


    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients WHERE id = @ClientId;";
      MySqlParameter clientIdParameter = new MySqlParameter();
      clientIdParameter.ParameterName = "@ClientId";
      clientIdParameter.Value = this._clientId;

      cmd.Parameters.Add(clientIdParameter);
      cmd.ExecuteNonQuery();

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string clientFirstName = rdr.GetString(0);
        string clientLastName = rdr.GetString(1);
        int clientId = rdr.GetInt32(2);
        int stylistId = rdr.GetInt32(3);
        Client newClient = new Client(clientFirstName,clientLastName,clientId,stylistId);
        allClients.Add(newClient);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `clients` (`client_first_name`,`client_last_name`) VALUES (@ClientFirstName, @ClientLastName);";

      MySqlParameter clientFirstName = new MySqlParameter();
      clientFirstName.ParameterName = "@ClientFirstName";
      clientFirstName.Value = this._clientFirstName;

      MySqlParameter clientLastName = new MySqlParameter();
      clientLastName.ParameterName = "@ClientLastName";
      clientLastName.Value = this._clientLastName;

      cmd.Parameters.Add(clientFirstName);
      cmd.Parameters.Add(clientLastName);

      cmd.ExecuteNonQuery();
      _clientId = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherClient)
    {
      if(!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool clientFirstNameEquality = (this.GetClientFirstName() == newClient.GetClientFirstName());
        bool clientLastNameEquality = (this.GetClientLastName() == newClient.GetClientLastName());
        bool clientIdEquality = (this.GetClientId() == newClient.GetClientId());
        bool stylistIdEquality = (this.GetStylistId() == newClient.GetStylistId());
        return (clientFirstNameEquality && clientLastNameEquality && clientIdEquality && stylistIdEquality);
      }
    }
  }
}
