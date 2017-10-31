using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
    public class Client
    {
        private string _name;
        private int _id;
        private int _stylistId;

        public Client(string name, int stylistId)
        {
            _name = name;
            _stylistId = stylistId;
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
             bool idEquality = this.GetId() == newClient.GetId();
             bool nameEquality = this.GetName() == newClient.GetName();
             bool stylistEquality = this.GetStylistId() == newClient.GetStylistId();
             return (idEquality && nameEquality && stylistEquality);
           }
        }
        public override int GetHashCode()
        {
             return this.GetName().GetHashCode();
        }


        public string GetName()
        { return _name; }
        public void SetName(string name)
        { _name=name; }
        public int GetId()
        { return _id; }
        public void SetId(int id)
        { _id = id; }
        public int GetStylistId()
        { return _stylistId; }
        public void SetStylistId(int id)
        { _stylistId = id; }



        public static List<Client> GetAll()
        {
          List<Client> allClients = new List<Client>{};

          MySqlConnection conn = DB.Connection();
          conn.Open();

          MySqlCommand cmd = conn.CreateCommand();
          cmd.CommandText = @"SELECT * from Clients;";
          MySqlDataReader rdr = cmd.ExecuteReader();
          while(rdr.Read())
          {
            string name = rdr.GetString(0);
            int stylist = rdr.GetInt32(1);
            int id      = rdr.GetInt32(2);

            Client nextClient = new Client(name,stylist);
            nextClient.SetId(id);
            allClients.Add(nextClient);
          }
          conn.Close();
          if (conn != null)
          {conn.Dispose();}
          return allClients;
        }

        public void Save()
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          MySqlCommand cmd = conn.CreateCommand();
          cmd.CommandText = @"INSERT into `clients`  (name,stylist_id) VALUES (@clientName,@stylist_id);";
          MySqlParameter name = new MySqlParameter();
          name.ParameterName = "@clientName";
          name.Value = this.GetName();
          cmd.Parameters.Add(name);
          MySqlParameter stylist = new MySqlParameter();
          stylist.ParameterName = "@stylist_id";
          stylist.Value = this.GetStylistId();
          cmd.Parameters.Add(stylist);

          cmd.ExecuteNonQuery();
          _id = (int) cmd.LastInsertedId;

          conn.Close();
          if (conn != null)
          {conn.Dispose();}
        }

        public static Client Find(int id)
        {

          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand();
          cmd.CommandText = @"SELECT * FROM `clients` WHERE id = @clientId;";
          MySqlParameter clientId = new MySqlParameter();
          clientId.ParameterName = @"clientId";
          clientId.Value = id;
          cmd.Parameters.Add(clientId);
          MySqlDataReader rdr = cmd.ExecuteReader();

          string savedName = "";
          int savedStylist = 0;
          int savedId      = 0;

          while(rdr.Read())
          {
              savedName    = rdr.GetString(0);
              savedStylist = rdr.GetInt32(1);
              savedId      = rdr.GetInt32(2);
          }
          Client soughtClient = new Client(savedName, savedStylist);
          if(savedId > 0){soughtClient.SetId(savedId);}
          return soughtClient;
        }

        public static void DeleteAll()
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          MySqlCommand cmd = conn.CreateCommand();

          cmd.CommandText = @"DELETE FROM `clients`; ALTER TABLE `clients` AUTO_INCREMENT = 1;";
          cmd.ExecuteNonQuery();

          conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
        }
        public static void Delete(int id)
        {
          bool valid_Id = false;
          foreach (Client a in Client.GetAll())
          { if(a.GetId() == id){valid_Id = true;} }

          if(valid_Id)
          {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"DELETE FROM `clients` WHERE id=@clientId;";
            MySqlParameter clientId = new MySqlParameter();
            clientId.ParameterName  = "@clientId";
            clientId.Value = id;
            cmd.Parameters.Add(clientId);
            cmd.ExecuteNonQuery();

            conn.Close();
             if (conn != null)
             {
                 conn.Dispose();
             }
           }
        }
        public void Update(string name = null , int stylistId = 0)
        {
          if (name!=null)
          { this.SetName(name); }

          if (stylistId!=0)
          { this.SetStylistId(stylistId); }


          MySqlConnection conn = DB.Connection();
          conn.Open();

          MySqlCommand cmd = conn.CreateCommand();

          cmd.CommandText = @"UPDATE `clients` SET name = @newName, stylist_id = @newStylist WHERE id = @clientId;";

          MySqlParameter newName = new MySqlParameter();
          newName.ParameterName  = "@newName";
          newName.Value = this.GetName();
          cmd.Parameters.Add(newName);
          MySqlParameter newStylist = new MySqlParameter();
          newStylist.ParameterName  = "@newStylist";
          newStylist.Value = this.GetStylistId();
          cmd.Parameters.Add(newStylist);
          MySqlParameter clientId = new MySqlParameter();
          clientId.ParameterName  = "@clientId";
          clientId.Value = this.GetId();
          cmd.Parameters.Add(clientId);
          cmd.ExecuteNonQuery();

          conn.Close();
          if (conn != null)
          { conn.Dispose(); }
        }


    }
}
