using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _name;
    private int _id;

    public Stylist(string stylistName, int id = 0)
    {
      _name = stylistName;
      _id = id;
    }

     public override int GetHashCode()
        {
            return this.GetId().GetHashCode();
        }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

      public static void ClearAll()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM stylists;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
      }

        public static List<Stylist> GetAll()
      {
        List<Stylist> allStylists = new List<Stylist> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM stylists;";
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int StylistId = rdr.GetInt32(0);
          string StylistName = rdr.GetString(1);
          Stylist newStylist = new Stylist(StylistName, StylistId); // <-- This line now has two arguments
          allStylists.Add(newStylist);
        }
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return allStylists;
      }

  

            public static Stylist Find(int id)
            {
              MySqlConnection conn = DB.Connection();
              conn.Open();
              var cmd = conn.CreateCommand() as MySqlCommand;
              cmd.CommandText = @"SELECT * FROM stylists WHERE id = (@searchId);";
              MySqlParameter searchId = new MySqlParameter();
              searchId.ParameterName = "@searchId";
              searchId.Value = id;
              cmd.Parameters.Add(searchId);
              var rdr = cmd.ExecuteReader() as MySqlDataReader;
              int StylistId = 0;
              string StylistName = "";
              while(rdr.Read())
              {
                StylistId = rdr.GetInt32(0);
                StylistName = rdr.GetString(1);
              }
              Stylist newStylist = new Stylist(StylistName, StylistId);
              conn.Close();
              if (conn != null)
              {
                conn.Dispose();
              }
              return newStylist;
            }




     public List<Client> GetClients()
    {
      List<Client> allStylistClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylist_id;";
      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@stylist_id";
      stylistId.Value = this._id;
      cmd.Parameters.Add(stylistId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientDescription = rdr.GetString(1);
        int clientStylistId = rdr.GetInt32(2);
        Client newClient = new Client(clientDescription, clientStylistId, clientId);
        allStylistClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylistClients;
    }






    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = this.GetId().Equals(newStylist.GetId());
        bool nameEquality = this.GetName().Equals(newStylist.GetName());
        return (idEquality && nameEquality);
      }
    }

      public void Save()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO stylists (name) VALUES (@name);";
        MySqlParameter name = new MySqlParameter();
        name.ParameterName = "@name";
        name.Value = this._name;
        cmd.Parameters.Add(name);
        cmd.ExecuteNonQuery();
        _id = (int) cmd.LastInsertedId; // <-- This line is new!
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
      }

      //  public static void DeleteAll()
      //   {
      //       MySqlConnection conn = DB.Connection();
      //       conn.Open();
      //       var cmd = conn.CreateCommand() as MySqlCommand;
      //       cmd.CommandText = @"DELETE FROM stylists;";
      //       cmd.ExecuteNonQuery();
      //       conn.Close();
      //       if (conn != null)
      //       {
      //           conn.Dispose();
      //       }
      //   }




  }
}