using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
    public class Stylist
    {
        private string _name;
        private int _id;
        public Stylist(string name, int id = 0)
        {
            _name = name;
            _id = id;
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
                bool idEquality = this.GetId() == newStylist.GetId();
                bool nameEquality  = this.GetName() == newStylist.GetName();
                return (idEquality && nameEquality);
            }
        }
        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }

        public string GetName()
        { return _name; }
        public int GetId()
        { return _id; }

        public static List<Stylist> GetAll()
        {
          List<Stylist> allStylists = new List<Stylist>{};

          MySqlConnection conn = DB.Connection();
          conn.Open();

          MySqlCommand cmd = conn.CreateCommand();
          cmd.CommandText = @"SELECT * FROM `stylists`;";

          MySqlDataReader rdr = cmd.ExecuteReader();
          while (rdr.Read())
          {
            string name = rdr.GetString(0);
            int id      = rdr.GetInt32(1);
            allStylists.Add(new Stylist(name,id));
          }
          conn.Close();
          if (conn != null)
          {conn.Dispose();}

          return allStylists;
        }

        public void Save()
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          MySqlCommand cmd = conn.CreateCommand();

          cmd.CommandText = @"INSERT INTO `stylists` (`name`) VALUES (@StylistName);";
          MySqlParameter name = new MySqlParameter();
          name.ParameterName = "@StylistName";
          name.Value = this.GetName();
          cmd.Parameters.Add(name);

          cmd.ExecuteNonQuery();
          _id = (int) cmd.LastInsertedId;

          conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
        }

        public static void DeleteAll()
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          MySqlCommand cmd = conn.CreateCommand();

          cmd.CommandText = @"DELETE FROM `stylists`;";
          cmd.ExecuteNonQuery();
          
          conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
        }


    }
}
