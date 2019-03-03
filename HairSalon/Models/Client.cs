using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Client
  {
   private string _description;
   // private int _id;

    public Client (string description)
      {
        _description = description;
        // _id = _instances.Count;
      }


    public string GetDescription()
      {
        return _description;
      }

    public void SetDescription(string newDescription)
      {
        _description = newDescription;
      }

    // public int GetId()
    //   {
    //     return _id;
    //   }

    public static List<Client> GetAll()
      {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM items;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string clientDescription = rdr.GetString(1);
        Client newClient = new Client(clientDescription, clientId);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      
      return allClients;
      }

    // public static void ClearAll()
    // {
    //   _instances.Clear();
    // }

    //  public static Client Find(int searchId)
    // {
    //   return _instances[searchId-1];
    // }


  }
}