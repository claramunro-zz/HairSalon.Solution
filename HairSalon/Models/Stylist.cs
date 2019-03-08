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
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT clients.* FROM stylists
            JOIN stylists_clients ON (stylists.id = stylists_clients.stylist_id)
            JOIN clients ON (stylists_clients.client_id = clients.id)
            WHERE stylists.id = @CategoryId;";
        MySqlParameter categoryIdParameter = new MySqlParameter();
        categoryIdParameter.ParameterName = "@CategoryId";
        categoryIdParameter.Value = _id;
        cmd.Parameters.Add(categoryIdParameter);
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        List<Client> clients = new List<Client>{};
        while(rdr.Read())
        {
          int clientId = rdr.GetInt32(0);
          string clientDescription = rdr.GetString(1);
          Client newClient = new Client(clientDescription, clientId);
          clients.Add(newClient);
        }
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return clients;
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


      public void Delete()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("DELETE FROM stylists WHERE id = @StylistId; DELETE FROM stylists_clients WHERE stylist_id = @StylistId;", conn);
        MySqlParameter stylistIdParameter = new MySqlParameter();
        stylistIdParameter.ParameterName = "@StylistId";
        stylistIdParameter.Value = this.GetId();
        cmd.Parameters.Add(stylistIdParameter);
        cmd.ExecuteNonQuery();
        if (conn != null)
        {
          conn.Close();
        }
      }


        public void AddClient(Client newClient)
            {
              MySqlConnection conn = DB.Connection();
              conn.Open();
              var cmd = conn.CreateCommand() as MySqlCommand;
              cmd.CommandText = @"INSERT INTO stylists_clients (stylist_id, client_id) VALUES (@StylistId, @ClientId);";
              MySqlParameter stylist_id = new MySqlParameter();
              stylist_id.ParameterName = "@StylistId";
              stylist_id.Value = _id;
              cmd.Parameters.Add(stylist_id);
              MySqlParameter client_id = new MySqlParameter();
              client_id.ParameterName = "@ClientId";
              client_id.Value = newClient.GetId();
              cmd.Parameters.Add(client_id);
              cmd.ExecuteNonQuery();
              conn.Close();
              if (conn != null)
              {
                conn.Dispose();
              }
            }


  }
}