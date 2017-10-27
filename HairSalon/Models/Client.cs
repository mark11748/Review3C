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

        public Client(string name, int stylistId = 0, int id = 0)
        {
            _name = name;
            _stylistId = stylistId;
            _id = id;
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

        public int GetId()
        {
            return _id;
        }
        public int GetStylistId()
        {
            return _stylistId;
        }


        public static List<Client> GetAll()
        {
          List<Client> allClients = new List<Client>{};
          return allClients;
        }

        public void Save()
        {

        }

        public static Client Find(int id=0)
        {
          Client soughtClient = new Client("PlaceHolder");
          return soughtClient;
        }

        public static void DeleteAll()
        {

        }


    }
}
