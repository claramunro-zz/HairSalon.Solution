using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
   private string _description;
   private int _id;
   private int _stylistId;

    public Client (string description, int stylistId, int id = 0)
      {
        _description = description;
        _stylistId = stylistId;
        _id = id;
      }


    public string GetDescription()
      {
        return _description;
      }

    public void SetDescription(string newDescription)
      {
        _description = newDescription;
      }

    public int GetId()
      {
          return _id;
      }

  public int GetCategoryId()
      {
        return _stylistId;
      }



    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientDescription = rdr.GetString(1);
        int clientStylistId = rdr.GetInt32(2);
        Client newClient = new Client(clientDescription, clientStylistId, clientId);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }



    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";
      cmd.ExecuteNonQuery();
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
    cmd.CommandText = @"SELECT * FROM clients WHERE id = (@searchId);";
    MySqlParameter searchId = new MySqlParameter();
    searchId.ParameterName = "@searchId";
    searchId.Value = id;
    cmd.Parameters.Add(searchId);
    var rdr = cmd.ExecuteReader() as MySqlDataReader;
    int clientId = 0;
    string clientName = "";
    int clientStylistId = 0;
    while(rdr.Read())
    {
      clientId = rdr.GetInt32(0);
      clientName = rdr.GetString(1);
      clientStylistId = rdr.GetInt32(2);
    }
    Client newClient = new Client(clientName, clientStylistId, clientId);
    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
    return newClient;
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
        bool descriptionEquality = (this.GetDescription() == newClient.GetDescription());
        bool stylistEquality = this.GetStylistId() == newClient.GetStylistId();
        return (idEquality && descriptionEquality && stylistEquality);
      }
    }




     public void Save()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO clients (description, stylist_id) VALUES (@description, @stylist_id);";
        MySqlParameter description = new MySqlParameter();
        description.ParameterName = "@description";
        description.Value = this._description;
        cmd.Parameters.Add(description);
        MySqlParameter stylistId = new MySqlParameter();
        stylistId.ParameterName = "@stylist_id";
        stylistId.Value = this._stylistId;
        cmd.Parameters.Add(_stylistId);
        cmd.ExecuteNonQuery();
        _id = (int) cmd.LastInsertedId;
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
      }

    public void Edit(string newDescription)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE clients SET description = @newDescription WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);
      MySqlParameter description = new MySqlParameter();
      description.ParameterName = "@newDescription";
      description.Value = newDescription;
      cmd.Parameters.Add(description);
      cmd.ExecuteNonQuery();
      _description = newDescription; // <--- This line is new!
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }




  }
}