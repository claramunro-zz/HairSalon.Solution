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

        public string GetStyle()
        {
            return _style;
        }

        public void SetStyle(string newStyle)
        {
            _style = newStyle;
        }

        public int GetId()
        {
            return _id;
        }



        public static List<Specialty> GetAll()
        {
            List<Specialty> allSpecialties = new List<Specialty> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int SpecialtyId = rdr.GetInt32(0);
                string SpecialtyStyle = rdr.GetString(1);
                Specialty newSpecialty = new Specialty(SpecialtyStyle, SpecialtyId);
                allSpecialties.Add(newSpecialty);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allSpecialties;
        }



        public static Specialty Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties WHERE id = (@searchId);";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int specialtyId = 0;
            string specialtyName = "";
            while (rdr.Read())
            {
                specialtyId = rdr.GetInt32(0);
                specialtyName = rdr.GetString(1);
            }
            Specialty newSpecialty = new Specialty(specialtyName, specialtyId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newSpecialty;
        }


        public List<Stylist> GetSpecialties()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText =

            @"SELECT stylists.* FROM specialties
            JOIN stylists_specialties ON (specialties.id = stylists_specialties.specialty_id)
            JOIN stylists ON (stylists_specialties.stylist_id = stylists.id)
            WHERE specialties.id = @specialtyId;";

            MySqlParameter specialtyIdParameter = new MySqlParameter();
            specialtyIdParameter.ParameterName = "@specialtyId";
            specialtyIdParameter.Value = _id;
            cmd.Parameters.Add(specialtyIdParameter);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            List<Stylist> stylists = new List<Stylist> { };
            while (rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistDescription = rdr.GetString(1);
                Stylist newStylist = new Stylist(stylistDescription, stylistId);
                stylists.Add(newStylist);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return stylists;
        }



        public override bool Equals(System.Object otherSpecialty)
        {
            if (!(otherSpecialty is Specialty))
            {
                return false;
            }
            else
            {
                Specialty newSpecialty = (Specialty)otherSpecialty;
                bool idEquality = (this.GetId() == newSpecialty.GetId());
                bool descriptionEquality = (this.GetStyle() == newSpecialty.GetStyle());
                return (idEquality && descriptionEquality);
            }
        }


         public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialties (style) VALUES (@style);";
            MySqlParameter style = new MySqlParameter();
            style.ParameterName = "@style";
            style.Value = this._style;
            cmd.Parameters.Add(style);
            cmd.ExecuteNonQuery();
            _id = (int)cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

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



        public void AddSpecialty(Specialty newSpecialty)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists_specialties (stylist_id, specialty_id) VALUES (@stylistId, @specialtyId);";
            MySqlParameter stylist_id = new MySqlParameter();
            stylist_id.ParameterName = "@stylistId";
            stylist_id.Value = _id;
            cmd.Parameters.Add(stylist_id);
            MySqlParameter specialty_id = new MySqlParameter();
            specialty_id.ParameterName = "@specialtyId";
            specialty_id.Value = _id;
            cmd.Parameters.Add(specialty_id);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }



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