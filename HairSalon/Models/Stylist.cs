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
      cmd.CommandText = @"SELECT * FROM stylist;";
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
  }
}
