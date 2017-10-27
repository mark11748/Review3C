using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
    public class Employee
    {
        private string _name;
        private int _id;
        public Employee(string name, int id = 0)
        {
            _name = name;
            _id = id;
        }
        public override bool Equals(System.Object otherEmployee)
        {
            if (!(otherEmployee is Employee))
            {
                return false;
            }
            else
            {
                Employee newEmployee = (Employee) otherEmployee;
                return this.GetId().Equals(newEmployee.GetId());
            }
        }
        public override int GetHashCode()
        {
            return this.GetId().GetHashCode();
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
