using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
    public class Client
    {
        private string _description;
        private string _dueDate;
        private int _id;
        private int _employeeId;

        public Client(string description, string dueDate, int employeeId = 0, int id = 0)
        {
            _description = description;
            _dueDate = dueDate;
            _employeeId = employeeId;
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
             bool descriptionEquality = this.GetDescription() == newClient.GetDescription();
             bool employeeEquality = this.GetEmployeeId() == newClient.GetEmployeeId();
             return (idEquality && descriptionEquality && employeeEquality);
           }
        }
        public override int GetHashCode()
        {
             return this.GetDescription().GetHashCode();
        }

        public string GetDescription()
        {
            return _description;
        }
        public string GetDueDate()
        {
          return _dueDate;
        }
        public int GetId()
        {
            return _id;
        }
        public int GetEmployeeId()
        {
            return _employeeId;
        }


    }
}
