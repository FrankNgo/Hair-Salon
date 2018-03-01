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
        return (firstNameEquality && lastNameEquality && rawDateEquality && idEquality);
      }
    }
  }
}
