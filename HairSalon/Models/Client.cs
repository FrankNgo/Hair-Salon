using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    private string _clientFirstName;
    private string _clientLastName;
    private int _id;
    private int _stylistId;

    public Client(string clientFirstName, string clientLastName, int Id = 0, int stylistId = 0)
    {
      _clientFirstName = clientFirstName;
      _clientLastName = clientLastName;
      _id = Id;
      _stylistId = stylistId;
    }

    public string GetClientFirstName(){return _clientFirstName;}

    public string GetClientLastName(){return _clientLastName;}

    public int GetId() {return _id;}

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
       cmd.CommandText = @"DELETE FROM `clients` WHERE id = @thisId;";

       MySqlParameter thisId = new MySqlParameter();
       thisId.ParameterName = "@thisId";
       thisId.Value = _id;
       cmd.Parameters.Add(thisId);

       cmd.ExecuteNonQuery();
       conn.Close();
       if (conn != null)
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
        int clientStylistId = rdr.GetInt32(3);
        Client newClient = new Client(clientFirstName,clientLastName,clientId,clientStylistId);
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
      cmd.CommandText = @"INSERT INTO `clients` (`client_first_name`,`client_last_name`,`stylist_id`) VALUES (@ClientFirstName, @ClientLastName, @StylistId);";

      MySqlParameter clientFirstName = new MySqlParameter();
      clientFirstName.ParameterName = "@ClientFirstName";
      clientFirstName.Value = this._clientFirstName;

      MySqlParameter clientLastName = new MySqlParameter();
      clientLastName.ParameterName = "@ClientLastName";
      clientLastName.Value = this._clientLastName;

      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@StylistId";
      stylistId.Value = this._stylistId;


      cmd.Parameters.Add(clientFirstName);
      cmd.Parameters.Add(clientLastName);
      cmd.Parameters.Add(stylistId);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

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
        bool IdEquality = (this.GetId() == newClient.GetId());
        bool stylistIdEquality = (this.GetStylistId() == newClient.GetStylistId());
        return (clientFirstNameEquality && clientLastNameEquality && IdEquality && stylistIdEquality);
      }
    }
  }
}
