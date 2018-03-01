using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _firstName;
    private string _lastName;
    private int _id;

    public Stylist(string firstName, string lastName, int id = 0)
    {
      _firstName = firstName;
      _lastName = lastName;
      _id = id;
    }

    public string GetFirstName(){ return _firstName;}

    public string GetLastName(){ return _lastName;}

    public int GetId(){ return _id; }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylist = new List<Stylist>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string firstName = rdr.GetString(0);
        string lastName = rdr.GetString(1);
        int id = rdr.GetInt32(2);
        Stylist newStylist = new Stylist(firstName,lastName,id);
        allStylist.Add(newStylist);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylist;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `stylists` (`first_name`,`last_name`) VALUES (@FirstName, @LastName);";

      MySqlParameter firstName = new MySqlParameter();
      firstName.ParameterName = "@FirstName";
      firstName.Value = this._firstName;

      MySqlParameter lastName = new MySqlParameter();
      lastName.ParameterName = "@LastName";
      lastName.Value = this._lastName;

      cmd.Parameters.Add(firstName);
      cmd.Parameters.Add(lastName);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherStylist)
    {
      if(!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool firstNameEquality = (this.GetFirstName() == newStylist.GetFirstName());
        bool lastNameEquality = (this.GetLastName() == newStylist.GetLastName());
        bool idEquality = (this.GetId() == newStylist.GetId());
        return (firstNameEquality && lastNameEquality && idEquality);
      }
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";

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
      cmd.CommandText = @"DELETE FROM stylists WHERE id = @SylistId;";
      MySqlParameter stylistIdParameter = new MySqlParameter();
      stylistIdParameter.ParameterName = "@SylistId";
      stylistIdParameter.Value = this._id;

      cmd.Parameters.Add(stylistIdParameter);
      cmd.ExecuteNonQuery();

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }

    public static Stylist Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * from `stylists` WHERE id = @thisId;";

      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int stylistId = 0;
      string stylistFirstName = "";
      string stylistLastName = "";

      while (rdr.Read())
      {
        stylistId = rdr.GetInt32(2);
        stylistFirstName = rdr.GetString(0);
        stylistLastName = rdr.GetString(1);
      }

      Stylist foundStylist = new Stylist(stylistFirstName, stylistLastName, stylistId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundStylist;
    }

    public List<Client> GetClients()
    {
        List<Client> allMyClients = new List<Client> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM `clients` WHERE `stylist_id` = @StylistId;";

        MySqlParameter stylistId = new MySqlParameter();
        stylistId.ParameterName = "@StylistId";
        stylistId.Value = this._id;
        cmd.Parameters.Add(stylistId);

        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
            string clientFirstName = rdr.GetString(1);
            string clientLastName = rdr.GetString(2);
            int clientId = rdr.GetInt32(0);
            int clientStylistId = rdr.GetInt32(3);
            Client newClient = new Client(clientFirstName, clientLastName, clientId, clientStylistId);
            allMyClients.Add(newClient);
        }
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return allMyClients;
    }
  }
}
