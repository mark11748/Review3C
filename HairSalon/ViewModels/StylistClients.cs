using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.ViewModels
{
  public class StylistClientsViewModel
  {
    private Stylist      _stylist;
    private List<Client> _clients = new List<Client>();

    public StylistClientsViewModel(int stylistId)
    {
      foreach (Stylist person in Stylist.GetAll())
      {
        if(person.GetId() == stylistId)
        {
          _stylist = person;
          break;
        }
      }
      foreach (Client person in Client.GetAll())
      {
        if(person.GetStylistId() == stylistId)
        {
          _clients.Add(person);
        }
      }
    }

    public Stylist GetStylist()
    {return _stylist;}
    public List<Client> GetClients()
    {return _clients;}
  }
}
