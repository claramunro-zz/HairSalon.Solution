using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Specialty
    {
        private string _style;
        private int _id;

        public Specialty(string style, int id = 0)
        {
            _style = style;
            _id = id;
        }


        public string GetDescription()
        {
            return _style;
        }

        public void SetDescription(string newStyle)
        {
            _style = newStyle;
        }

        public int GetId()
        {
            return _id;
        }



        // public static List<Client> GetAll()
        // {
        //     List<Client> allClients = new List<Client> { };
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     var cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"SELECT * FROM clients;";
        //     var rdr = cmd.ExecuteReader() as MySqlDataReader;
        //     while (rdr.Read())
        //     {
        //         int clientId = rdr.GetInt32(0);
        //         string clientDescription = rdr.GetString(1);
        //         Client newClient = new Client(clientDescription, clientId);
        //         allClients.Add(newClient);
        //     }
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        //     return allClients;
        // }



        // public static Client Find(int id)
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     var cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"SELECT * FROM clients WHERE id = (@searchId);";
        //     MySqlParameter searchId = new MySqlParameter();
        //     searchId.ParameterName = "@searchId";
        //     searchId.Value = id;
        //     cmd.Parameters.Add(searchId);
        //     var rdr = cmd.ExecuteReader() as MySqlDataReader;
        //     int clientId = 0;
        //     string clientName = "";
        //     while (rdr.Read())
        //     {
        //         clientId = rdr.GetInt32(0);
        //         clientName = rdr.GetString(1);
        //     }
        //     Client newClient = new Client(clientName, clientId);
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        //     return newClient;
        // }


        // public List<Stylist> GetStylists()
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText =

        //     @"SELECT stylists.* FROM clients
        //     JOIN stylists_clients ON (clients.id = stylists_clients.client_id)
        //     JOIN stylists ON (stylists_clients.stylist_id = stylists.id)
        //     WHERE clients.id = @clientId;";

        //     MySqlParameter clientIdParameter = new MySqlParameter();
        //     clientIdParameter.ParameterName = "@clientId";
        //     clientIdParameter.Value = _id;
        //     cmd.Parameters.Add(clientIdParameter);
        //     MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        //     List<Stylist> stylists = new List<Stylist> { };
        //     while (rdr.Read())
        //     {
        //         int stylistId = rdr.GetInt32(0);
        //         string stylistDescription = rdr.GetString(1);
        //         Stylist newStylist = new Stylist(stylistDescription, stylistId);
        //         stylists.Add(newStylist);
        //     }
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        //     return stylists;
        // }



        // public override bool Equals(System.Object otherClient)
        // {
        //     if (!(otherClient is Client))
        //     {
        //         return false;
        //     }
        //     else
        //     {
        //         Client newClient = (Client)otherClient;
        //         bool idEquality = (this.GetId() == newClient.GetId());
        //         bool descriptionEquality = (this.GetDescription() == newClient.GetDescription());
        //         return (idEquality && descriptionEquality);
        //     }
        // }


        //  public void Save()
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     var cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"INSERT INTO clients (description) VALUES (@description);";
        //     MySqlParameter description = new MySqlParameter();
        //     description.ParameterName = "@description";
        //     description.Value = this._description;
        //     cmd.Parameters.Add(description);
        //     cmd.ExecuteNonQuery();
        //     _id = (int)cmd.LastInsertedId;
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        // }

        // public void Edit(string newDescription)
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     var cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"UPDATE clients SET description = @newDescription WHERE id = @searchId;";
        //     MySqlParameter searchId = new MySqlParameter();
        //     searchId.ParameterName = "@searchId";
        //     searchId.Value = _id;
        //     cmd.Parameters.Add(searchId);
        //     MySqlParameter description = new MySqlParameter();
        //     description.ParameterName = "@newDescription";
        //     description.Value = newDescription;
        //     cmd.Parameters.Add(description);
        //     cmd.ExecuteNonQuery();
        //     _description = newDescription;
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        // }



        // public void AddStylist(Stylist newStylist)
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     var cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"INSERT INTO stylists_clients (stylist_id, client_id) VALUES (@stylistId, @clientId);";
        //     MySqlParameter stylist_id = new MySqlParameter();
        //     stylist_id.ParameterName = "@stylistId";
        //     stylist_id.Value = newStylist.GetId();
        //     cmd.Parameters.Add(stylist_id);
        //     MySqlParameter client_id = new MySqlParameter();
        //     client_id.ParameterName = "@clientId";
        //     client_id.Value = _id;
        //     cmd.Parameters.Add(client_id);
        //     cmd.ExecuteNonQuery();
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        // }



        // public void Delete()
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     var cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"DELETE FROM clients WHERE id = @clientId; DELETE FROM stylists_clients WHERE client_id = @clientId;";
        //     MySqlParameter clientIdParameter = new MySqlParameter();
        //     clientIdParameter.ParameterName = "@clientId";
        //     clientIdParameter.Value = this.GetId();
        //     cmd.Parameters.Add(clientIdParameter);
        //     cmd.ExecuteNonQuery();
        //     if (conn != null)
        //     {
        //         conn.Close();
        //     }
        // }


        // public static void ClearAll()
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     var cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"DELETE FROM clients;";
        //     cmd.ExecuteNonQuery();
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        // }



        // //  public static void DeleteAll()
        // //   {
        // //       MySqlConnection conn = DB.Connection();
        // //       conn.Open();
        // //       var cmd = conn.CreateCommand() as MySqlCommand;
        // //       cmd.CommandText = @"DELETE FROM stylists;";
        // //       cmd.ExecuteNonQuery();
        // //       conn.Close();
        // //       if (conn != null)
        // //       {
        // //           conn.Dispose();
        // //       }
        // //   }





    }
}