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
        {
            return _name;
        }
        public int GetId()
        {
            return _id;
        }

    }
}
