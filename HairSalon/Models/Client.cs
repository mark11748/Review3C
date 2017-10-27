using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
    public class Client
    {
        private string _fname;
        private string _lname;
        private int _id;
        private int _stylistId;

        public Client(string fname, string lname, int stylistId = 0, int id = 0)
        {
            _fname = fname;
            _lname = lname;
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
             bool nameEquality = (this.GetFirstName()+ " " +this.GetLastName()) == (newClient.GetFirstName()+ " " +newClient.GetLastName());
             bool stylistEquality = this.GetStylistId() == newClient.GetStylistId();
             return (idEquality && nameEquality && stylistEquality);
           }
        }
        public override int GetHashCode()
        {
             return this.GetDescription().GetHashCode();
        }

        public string GetFirstName()
        {
            return _fname;
        }
        public string GetLastName()
        {
          return _lname;
        }
        public int GetId()
        {
            return _id;
        }
        public int GetStylistId()
        {
            return _stylistId;
        }


    }
}
